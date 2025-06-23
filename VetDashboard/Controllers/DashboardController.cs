using Microsoft.AspNetCore.Mvc;
using VetDashboard.Services;

namespace VetDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // --- ENDPOINTS DA API COMPLETOS ---

        [HttpGet]
        public async Task<JsonResult> GetTotalConsultas()
        {
            var total = await _dashboardService.GetTotalConsultasAsync();
            return Json(new { total = total });
        }

        [HttpGet]
        public async Task<JsonResult> GetTotalAnimais()
        {
            var total = await _dashboardService.GetTotalAnimaisAsync();
            return Json(new { total = total });
        }

        [HttpGet]
        public async Task<JsonResult> GetReceitaTotal()
        {
            var receita = await _dashboardService.GetReceitaTotalAsync();
            return Json(new { receita = receita.ToString("N2") });
        }

        [HttpGet]
        public async Task<JsonResult> GetAgendamentosHoje()
        {
            var total = await _dashboardService.GetAgendamentosHojeAsync();
            return Json(new { total = total });
        }

        [HttpGet]
        public async Task<JsonResult> GetConsultasPorMes()
        {
            var data = await _dashboardService.GetConsultasPorMesAsync();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetAtendimentosPorEspecialidade()
        {
            var data = await _dashboardService.GetAtendimentosPorEspecialidadeAsync();
            return Json(data);
        }
        [HttpGet]
        public async Task<JsonResult> GetProntuariosPorMes()
        {
            var data = await _dashboardService.GetProntuariosPorMesAsync();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetCustosInsumos()
        {
            var data = await _dashboardService.GetCustosInsumosAsync();
            return Json(data);
        }
    }
}