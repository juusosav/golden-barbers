window.chartHelper = {
    charts: {},

    create: function (canvasId, type, labels, data, label) {
        console.log('Creating chart', canvasId, labels, data);
        const ctx = document.getElementById(canvasId).getContext('2d');
        console.log('Canvas element:', ctx);

        if (this.charts[canvasId]) {
            this.charts[canvasId].destroy();
        }

        this.charts[canvasId] = new Chart(ctx, {
            type: type,
            data: {
                labels: labels,
                datasets: [{
                    label: label,
                    data: data,
                    backgroundColor: 'rgba(255, 215, 0, 0,5)',
                    borderColor: 'rgba(255, 215, 0, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }
};