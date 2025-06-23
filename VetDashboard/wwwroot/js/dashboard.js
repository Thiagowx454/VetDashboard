// A função principal que roda quando a página carrega
document.addEventListener('DOMContentLoaded', function () {
    // Chama uma função para carregar cada parte do dashboard
    carregarKPIs();
    carregarGraficoConsultasPorMes();
    carregarGraficoAnimaisPorEspecie();
    carregarGraficoReceitaPorTipoAnimal();
    carregarGraficoCustos();
});

// --- FUNÇÕES PARA CARREGAR OS DADOS DOS CARDS (KPIs) ---
function carregarKPIs() {
    // Total de Consultas
    fetch('/Dashboard/GetTotalConsultas')
        .then(response => response.json())
        .then(data => { document.getElementById('total-consultas').textContent = data.total; });

    // Total de Animais
    fetch('/Dashboard/GetTotalAnimais')
        .then(response => response.json())
        .then(data => { document.getElementById('total-animais').textContent = data.total; });

    // Receita do Mês
    fetch('/Dashboard/GetReceitaTotal')
        .then(response => response.json())
        .then(data => { document.getElementById('receita-mensal').textContent = `R$ ${data.receita}`; });

    // Agendamentos Hoje
    fetch('/Dashboard/GetAgendamentosHoje')
        .then(response => response.json())
        .then(data => { document.getElementById('agendamentos-hoje').textContent = data.total; });
}


// --- FUNÇÕES PARA RENDERIZAR OS GRÁFICOS ---

function carregarGraficoConsultasPorMes() {
    fetch('/Dashboard/GetConsultasPorMes')
        .then(response => response.json())
        .then(data => {
            const ctx = document.getElementById('consultasMensalChart').getContext('2d');
            new Chart(ctx, {
                type: 'line',
                data: {
                    labels: data.map(item => item.label),
                    datasets: [{ label: "Consultas", data: data.map(item => item.count), borderColor: '#4e73df', tension: 0.3 }]
                },
                options: { maintainAspectRatio: false, scales: { y: { beginAtZero: true } }, plugins: { legend: { display: false } } }
            });
        });
}

function carregarGraficoAnimaisPorEspecie() {
    // CORRIGIDO: Chamando a nova URL da API
    fetch('/Dashboard/GetAtendimentosPorEspecialidade')
        .then(response => response.json())
        .then(data => {
            // O ID do canvas continua o mesmo para não precisarmos mudar o HTML
            const ctx = document.getElementById('animaisEspecieChart').getContext('2d');
            new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: data.map(item => item.label), // As especialidades
                    datasets: [{
                        data: data.map(item => item.count), // A contagem de atendimentos
                        backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#f6c23e', '#858796']
                    }]
                },
                options: {
                    maintainAspectRatio: false,
                    cutout: '80%',
                    plugins: {
                        legend: {
                            position: 'bottom',
                            labels: { padding: 15 }
                        }
                    }
                }
            });
        });
}

function carregarGraficoReceitaPorTipoAnimal() { // O nome da função não precisa mudar
    // CORRIGIDO: Chamando a nova URL correta da API
    fetch('/Dashboard/GetProntuariosPorMes')
        .then(response => response.json())
        .then(data => {
            const ctx = document.getElementById('receitaPetChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: data.map(item => item.label), // Meses (ex: "6/2025")
                    datasets: [{
                        label: 'Nº de Prontuários',
                        data: data.map(item => item.count), // Contagem de prontuários
                        backgroundColor: '#4e73df'
                    }]
                },
                options: { maintainAspectRatio: false, scales: { y: { beginAtZero: true, ticks: { stepSize: 1 } } }, plugins: { legend: { display: false } } }
            });
        });
}
function carregarGraficoCustos() {
    fetch('/Dashboard/GetCustosInsumos')
        .then(response => response.json())
        .then(data => {
            const ctx = document.getElementById('custosInsumosChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: data.map(item => item.label),
                    datasets: [{ label: 'Custo (R$)', data: data.map(item => item.value), backgroundColor: '#f6c23e' }]
                },
                options: { maintainAspectRatio: false, indexAxis: 'y', scales: { x: { beginAtZero: true } }, plugins: { legend: { display: false } } }
            });
        });
}