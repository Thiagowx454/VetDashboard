using Microsoft.EntityFrameworkCore;
using VetDashboard.Data;
using VetDashboard.Models.DTOs;
using VetDashboard.Models.ViewModels;

namespace VetDashboard.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            var hoje = DateTime.Today;
            var inicioMes = new DateTime(hoje.Year, hoje.Month, 1);
            var inicioAno = new DateTime(hoje.Year, 1, 1);

            return new DashboardViewModel
            {
                TotalConsultas = await _context.Consultas.CountAsync(),
                TotalAnimais = await _context.Animais.CountAsync(),
                TotalVeterinarios = await _context.Veterinarios.CountAsync(),
                ConsultasHoje = await _context.Consultas
                    .Where(c => c.DataConsulta.Date == hoje)
                    .CountAsync(),
                ConsultasEsteMes = await _context.Consultas
                    .Where(c => c.DataConsulta >= inicioMes)
                    .CountAsync(),
                ReceitaMensal = await _context.Consultas
                    .Where(c => c.DataConsulta >= inicioMes)
                    .SumAsync(c => c.Valor),
                ReceitaTotal = await _context.Consultas
                    .Where(c => c.DataConsulta >= inicioAno)
                    .SumAsync(c => c.Valor),
                ConsultasPorMes = await GetConsultasPorMesAsync(hoje.Year),
                ReceitaPorVeterinario = await GetReceitaPorVeterinarioAsync(),
                AnimaisPorEspecie = await GetAnimaisPorEspecieAsync()
            };
        }

        public async Task<List<ConsultasPorMesDto>> GetConsultasPorMesAsync(int ano)
        {
            var meses = new string[] {
                "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            };

            var consultas = await _context.Consultas
                .Where(c => c.DataConsulta.Year == ano)
                .GroupBy(c => c.DataConsulta.Month)
                .Select(g => new ConsultasPorMesDto
                {
                    Mes = meses[g.Key - 1], // Array é base 0, mês é base 1
                    Quantidade = g.Count(),
                    Receita = g.Sum(x => x.Valor)
                })
                .ToListAsync();

            return consultas;
        }

        public async Task<List<ReceitaPorVeterinarioDto>> GetReceitaPorVeterinarioAsync()
        {
            return await _context.Consultas
                .Include(c => c.Veterinario)
                .GroupBy(c => c.Veterinario.Nome)
                .Select(g => new ReceitaPorVeterinarioDto
                {
                    NomeVeterinario = g.Key,
                    Receita = g.Sum(x => x.Valor),
                    TotalConsultas = g.Count()
                })
                .OrderByDescending(x => x.Receita)
                .ToListAsync();
        }

        public async Task<List<AnimaisPorEspecieDto>> GetAnimaisPorEspecieAsync()
        {
            return await _context.Animais
                .GroupBy(a => a.Especie)
                .Select(g => new AnimaisPorEspecieDto
                {
                    Especie = g.Key,
                    Quantidade = g.Count()
                })
                .OrderByDescending(x => x.Quantidade)
                .ToListAsync();
        }
    }
}