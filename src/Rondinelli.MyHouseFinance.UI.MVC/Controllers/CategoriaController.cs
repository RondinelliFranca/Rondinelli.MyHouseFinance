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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }
        
        public ActionResult Index()
        {
            return View(_categoriaAppService.ObterTodos().ToList());
        }

        public ActionResult Criar()
        {            
            return View(new CategoriaViewModel());
        }

        [HttpPost]
        public ActionResult Criar(CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaAppService.Adicionar(categoria);
                    TempData["sucesso"] = EnumMensagem.SALVO.Description;                    
                }
                else
                {
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(categoria);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                return View(categoria);
            }
        }


        public ActionResult Editar(Guid id)
        {            
            var categoria = _categoriaAppService.ObterPorId(id);
            if (categoria != null)
            {
                return View(categoria);
            }
            else
            {
                TempData["erro"] = EnumMensagem.NOT_FOUND.Description;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Editar(CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoria = _categoriaAppService.Atualizar(categoria);
                    TempData["sucesso"] = EnumMensagem.EDITADO.Description;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(categoria);
                }
            }
            catch (Exception e)
            {
                TempData["erro"] = e.Message;
                return View(categoria);
            }
        }

        public ActionResult Deletar(Guid id)
        {
            try
            {
                //Implementar o validar exclusão

                _categoriaAppService.Deletar(id);
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