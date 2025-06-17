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

        public async Task<IActionResult> Index()
        {
            try
            {
                var dashboardData = await _dashboardService.GetDashboardDataAsync();
                return View(dashboardData);
            }
            catch (Exception ex)
            {
                // Para debug - depois você pode remover
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetConsultasPorMes(int ano = 0)
        {
            if (ano == 0) ano = DateTime.Now.Year;
            var data = await _dashboardService.GetConsultasPorMesAsync(ano);
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetReceitaPorVeterinario()
        {
            var data = await _dashboardService.GetReceitaPorVeterinarioAsync();
            return Json(data);
        }
    }
}