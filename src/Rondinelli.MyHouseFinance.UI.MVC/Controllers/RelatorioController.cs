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
    public class RelatorioController : Controller
    {
        private readonly IRelatorioAppService _relatorioAppService;
        public RelatorioController(IRelatorioAppService relatorioAppService)
        {
            _relatorioAppService = relatorioAppService;
        }
        public void CarregarCombobox()
        {
            ViewBag.TipoPagamentoLista = EnumTipoPagamento.GetList();
            ViewBag.ResponsavelLista = UsuarioViewModel.ListarTodos();
            ViewBag.CategoriaLista = CategoriaViewModel.ListarTodos();
        }
        // GET: Relatorio
        public ActionResult Index()
        {
            CarregarCombobox();
            return View();
        }

        public JsonResult GraficoPorDespesas(string mesReferencia)
        {
            var lista = _relatorioAppService.GerarGraficoPorDespesas(mesReferencia);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraficoPagamento(string mesReferencia, string usuario)
        {
            var lista = _relatorioAppService.GerarGraficoPagamento(mesReferencia, usuario);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}