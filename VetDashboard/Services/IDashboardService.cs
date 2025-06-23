using VetDashboard.Models.DTOs; // Não se esqueça deste using!

namespace VetDashboard.Services
{
    public interface IDashboardService
    {
        // Métodos para os cards
        Task<int> GetTotalConsultasAsync();
        Task<int> GetTotalAnimaisAsync();
        Task<decimal> GetReceitaTotalAsync();
        Task<int> GetAgendamentosHojeAsync();

        // Métodos para os gráficos
        Task<List<ChartDataDto>> GetConsultasPorMesAsync();
        Task<List<ChartDataDto>> GetAtendimentosPorEspecialidadeAsync();
        Task<List<ChartDataDto>> GetProntuariosPorMesAsync();
        Task<List<ChartDataDto>> GetCustosInsumosAsync(); // Manteremos este, mesmo que a lógica seja de exemplo por enquanto
    }
}