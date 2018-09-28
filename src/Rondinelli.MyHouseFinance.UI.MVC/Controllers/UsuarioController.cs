using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Util.Enum;

namespace Rondinelli.MyHouseFinance.UI.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }
        public void CarregarCombobox()
        {
            ViewBag.CategoriaPessoaLista = EnumCategoriaPessoa.GetList();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(_usuarioAppService.ObterTodos().ToList());
        }

        public ActionResult Criar()
        {
            CarregarCombobox();

            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public ActionResult Criar(UsuarioViewModel usuario)
        {
            try
            {
                CarregarCombobox();
                if (ModelState.IsValid)
                {                    
                    _usuarioAppService.Adicionar(usuario);
                    TempData["sucesso"] = EnumMensagem.SALVO.Description;
                }
                else
                {
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(usuario);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                return View(usuario);
            }
        }

        public ActionResult Editar(Guid id)
        {
            CarregarCombobox();
            var usuario = _usuarioAppService.ObterPorId(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            else
            {
                TempData["erro"] = EnumMensagem.NOT_FOUND.Description;
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult Editar(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioAppService.Atualizar(usuario);
                    TempData["sucesso"] = EnumMensagem.EDITADO.Description;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(usuario);
                }
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                return View(usuario);
            }
        }

        public ActionResult Deletar(Guid id)
        {
            try
            {
                _usuarioAppService.Deletar(id);
                TempData["sucesso"] = EnumMensagem.DELETADO.Description;
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
            }
            return RedirectToAction("Index");
        }
    }
}