document.addEventListener('DOMContentLoaded', function () {

    const mockData = {
        kpis: {
            totalConsultas: 1482,
            totalAnimais: 351,
            receitaMensal: 28550.75,
            agendamentosHoje: 12
        },
        consultasPorMes: {
            labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun'],
            data: [180, 210, 250, 220, 280, 310]
        },
        animaisPorEspecie: {
            labels: ['Cães', 'Gatos', 'Aves', 'Roedores', 'Outros'],
            data: [180, 110, 25, 21, 15]
        },
        // DADO NOVO
        receitaPorTipoAnimal: {
            labels: ['Cães', 'Gatos', 'Aves', 'Outros'],
            data: [6500, 4800, 1200, 2500]
        },
        // DADO NOVO
        custosInsumos: {
            labels: ['Vacinas', 'Medicamentos', 'Seringas', 'Equip. Cirúrgico', 'Gaze'],
            data: [4500, 3200, 800, 5000, 450]
        }
    };

    document.getElementById('total-consultas').textContent = mockData.kpis.totalConsultas;
    document.getElementById('total-animais').textContent = mockData.kpis.totalAnimais;
    document.getElementById('receita-mensal').textContent = `R$ ${mockData.kpis.receitaMensal.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`;
    document.getElementById('agendamentos-hoje').textContent = mockData.kpis.agendamentosHoje;

    Chart.defaults.font.family = "'Nunito', -apple-system,system-ui,BlinkMacSystemFont,'Segoe UI',Roboto,'Helvetica Neue',Arial,sans-serif";
    Chart.defaults.color = '#858796';

    const consultasMensalCtx = document.getElementById('consultasMensalChart').getContext('2d');
    new Chart(consultasMensalCtx, {
        type: 'line',
        data: {
            labels: mockData.consultasPorMes.labels,
            datasets: [{ label: "Consultas", data: mockData.consultasPorMes.data, borderColor: '#4e73df', backgroundColor: 'rgba(78, 115, 223, 0.05)', tension: 0.3, fill: true }]
        },
        options: { maintainAspectRatio: false, scales: { y: { beginAtZero: false } }, plugins: { legend: { display: false } } }
    });

    const animaisEspecieCtx = document.getElementById('animaisEspecieChart').getContext('2d');
    new Chart(animaisEspecieCtx, {
        type: 'doughnut',
        data: {
            labels: mockData.animaisPorEspecie.labels,
            datasets: [{ data: mockData.animaisPorEspecie.data, backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#f6c23e', '#858796'], }]
        },
        options: { maintainAspectRatio: false, cutout: '80%', plugins: { legend: { position: 'bottom', labels: { padding: 15 } } } }
    });

    const receitaTipoAnimalCtx = document.getElementById('receitaPetChart').getContext('2d');
    new Chart(receitaTipoAnimalCtx, {
        type: 'bar',
        data: {
            labels: mockData.receitaPorTipoAnimal.labels,
            datasets: [{
                label: 'Receita (R$)',
                data: mockData.receitaPorTipoAnimal.data,
                backgroundColor: '#4e73df',
            }]
        },
        options: {
            maintainAspectRatio: false,
            scales: { y: { beginAtZero: true } },
            plugins: { legend: { display: false } }
        }
    });

    const custosInsumosCtx = document.getElementById('custosInsumosChart').getContext('2d');
    new Chart(custosInsumosCtx, {
        type: 'bar',
        data: {
            labels: mockData.custosInsumos.labels,
            datasets: [{ label: 'Custo (R$)', data: mockData.custosInsumos.data, backgroundColor: '#f6c23e', }]
        },
        options: { maintainAspectRatio: false, indexAxis: 'y', scales: { x: { beginAtZero: true } }, plugins: { legend: { display: false } } }
    });
});