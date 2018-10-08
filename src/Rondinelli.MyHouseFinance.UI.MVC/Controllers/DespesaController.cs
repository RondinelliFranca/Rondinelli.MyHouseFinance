using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Util.Enum;

namespace Rondinelli.MyHouseFinance.UI.MVC.Controllers
{
    public class DespesaController : Controller
    {
        private readonly IDespesaAppService _despesaAppService;

        public DespesaController(IDespesaAppService despesaAppService)
        {
            _despesaAppService = despesaAppService;
        }

        public void CarregarCombobox()
        {
            ViewBag.TipoPagamentoLista = EnumTipoPagamento.GetList();
            ViewBag.ResponsavelLista = UsuarioViewModel.ListarTodos();
            ViewBag.CategoriaLista = CategoriaViewModel.ListarTodos();
            ViewBag.ResposavelListaMulti = new MultiSelectList(UsuarioViewModel.ListarTodos(), "Id", "Nome");
        }

        // GET: Despesa
        public ActionResult Index()
        {
            var todos = _despesaAppService.ObterTodos().ToList();
            return View(todos);
        }

        public ActionResult Criar()
        {
            CarregarCombobox();
            return View(new DespesaViewModel());
        }

        [HttpPost]
        public ActionResult Criar(DespesaViewModel despesa)
        {
            try
            {                
                if (ModelState.IsValid)
                {                   
                    _despesaAppService.Adicionar(despesa);
                    TempData["sucesso"] = EnumMensagem.SALVO.Description;                                        
                }
                else
                {
                    CarregarCombobox();
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(despesa);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                CarregarCombobox();
                TempData["erro"] = e.Message;
                return View(despesa);
            }
        }

        public ActionResult Editar(Guid id)
        {
            CarregarCombobox();
            var despesa = _despesaAppService.ObterPorId(id);
            if (despesa != null)
            {
                return View(despesa);
            }
            else
            {
                TempData["erro"] = EnumMensagem.NOT_FOUND.Description;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Editar(DespesaViewModel despesa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    despesa = _despesaAppService.Atualizar(despesa);
                    TempData["sucesso"] = EnumMensagem.EDITADO.Description;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["erro"] = String.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
                    return View(despesa);
                }
            }
            catch (Exception e)
            {
                CarregarCombobox();
                TempData["erro"] = e.Message;
                return View(despesa);
            }
        }

        public ActionResult Deletar(Guid id)
        {
            try
            {
                //Implementar o validar exclusão

                _despesaAppService.Deletar(id);
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