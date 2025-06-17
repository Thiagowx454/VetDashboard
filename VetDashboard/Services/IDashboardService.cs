using VetDashboard.Models.DTOs;
using VetDashboard.Models.ViewModels;

namespace VetDashboard.Services
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardDataAsync();
        Task<List<ConsultasPorMesDto>> GetConsultasPorMesAsync(int ano);
        Task<List<ReceitaPorVeterinarioDto>> GetReceitaPorVeterinarioAsync();
        Task<List<AnimaisPorEspecieDto>> GetAnimaisPorEspecieAsync();
    }
}