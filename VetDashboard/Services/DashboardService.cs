using Microsoft.EntityFrameworkCore;
using VetDashboard.Models.Entities;
using VetDashboard.Models.DTOs;
using VetDashboard.Services;

namespace VetDashboard.Services
{
    // A classe agora "assina o contrato" da interface
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalConsultasAsync()
        {
            return await _context.Agendamentos.CountAsync();
        }

        public async Task<int> GetTotalAnimaisAsync()
        {
            return await _context.Pacientes.CountAsync();
        }

        public async Task<decimal> GetReceitaTotalAsync()
        {
            // CORRIGIDO: Agora soma a coluna ValorReceita da sua tabela Valores
            return await _context.Valors.SumAsync(v => v.ValorReceita);
        }

        public async Task<int> GetAgendamentosHojeAsync()
        {
            return await _context.Agendamentos.CountAsync(ag => ag.DataAgendamento.Date == DateTime.Today);
        }

        public async Task<List<ChartDataDto>> GetConsultasPorMesAsync()
        {
            var seisMesesAtras = DateTime.Now.AddMonths(-6);
            return await _context.Agendamentos
                .Where(ag => ag.DataAgendamento >= seisMesesAtras)
                .GroupBy(ag => new { Ano = ag.DataAgendamento.Year, Mes = ag.DataAgendamento.Month })
                .Select(g => new ChartDataDto
                {
                    Label = g.Key.Mes.ToString() + "/" + g.Key.Ano.ToString(),
                    Count = g.Count()
                })
                .OrderBy(dto => dto.Label)
                .ToListAsync();
        }

        public async Task<List<ChartDataDto>> GetAtendimentosPorEspecialidadeAsync()
        {
            // Usando os nomes corretos que já descobrimos
            return await _context.Prontuarios
                .Where(p => p.IdVeterinarioNavigation != null && p.IdVeterinarioNavigation.Especialidade != null)
                .GroupBy(p => p.IdVeterinarioNavigation.Especialidade)
                .Select(g => new ChartDataDto
                {
                    Label = g.Key,      // A especialidade (ex: "Clínico Geral")
                    Count = g.Count()   // A contagem de atendimentos
                })
                .ToListAsync();
        }

        public async Task<List<ChartDataDto>> GetProntuariosPorMesAsync()
        {
            var seisMesesAtras = DateTime.Now.AddMonths(-6);
            return await _context.Prontuarios
                // CORRIGIDO: Usando o nome real da sua coluna de data
                .Where(p => p.DataConsulta >= seisMesesAtras)
                .GroupBy(p => new { Ano = p.DataConsulta.Year, Mes = p.DataConsulta.Month })
                .Select(g => new ChartDataDto
                {
                    Label = g.Key.Mes.ToString() + "/" + g.Key.Ano.ToString(),
                    Count = g.Count()
                })
                .OrderBy(dto => dto.Label)
                .ToListAsync();
        }

        public async Task<List<ChartDataDto>> GetCustosInsumosAsync()
        {
            // Esta consulta vai buscar os 5 itens de maior custo no estoque
            return await _context.ItemEstoques // Usando a tabela correta
                                               // Filtra para garantir que só consideramos itens que têm um custo definido
                .Where(item => item.PrecoCusto.HasValue)

                // Ordena pelo PrecoCusto para pegar os mais caros
                .OrderByDescending(item => item.PrecoCusto.Value)

                // Pega apenas os 5 primeiros para o gráfico não ficar muito cheio
                .Take(5)

                .Select(item => new ChartDataDto
                {
                    // Usa a propriedade correta para o nome do produto
                    Label = item.NomeProduto,

                    // Usa a propriedade correta para o valor de custo
                    Value = item.PrecoCusto.Value
                })
                .ToListAsync();
        }
    }
}