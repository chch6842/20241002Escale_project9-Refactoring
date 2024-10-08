


const recommendedValues = {
    Grains: 300,
    Protein: 200,
    Dairy: 300,
    Vegetables: 400,
    Fruits: 300,
    OilsNuts: 50
};

const userValues = {
    Grains: {},
    Protein: {},
    Dairy: {},
    Vegetables: {},
    Fruits: {},
    OilsNuts: {}
};

const ctx = document.getElementById('foodChart').getContext('2d');
let foodChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: [],
        datasets: []
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                title: {
                    display: true,
                    text: '份量 (克)'
                }
            },
            x: {
                title: {
                    display: true,
                    text: '日期'
                }
            }
        }
    }
});

function updateChart() {
    const startDate = document.getElementById('startDate').value;
    const endDate = document.getElementById('endDate').value;
    const selectedItems = Array.from(document.querySelectorAll('.food-checkbox:checked')).map(checkbox => checkbox.value);

    if (!startDate || !endDate) {
        alert('請選擇起始和結束日期');
        return;
    }

    const start = new Date(startDate);
    const end = new Date(endDate);

    const labels = [];
    let dateCursor = new Date(start);

    while (dateCursor <= end) {
        labels.push(dateCursor.toISOString().split('T')[0]);
        dateCursor.setDate(dateCursor.getDate() + 1);
    }

    const datasets = selectedItems.map(item => {
        const data = labels.map(date => userValues[item][date] || 0);
        const color = getRandomColor();
        return {
            label: `${item} - 使用者`,
            data: data,
            borderColor: color,
            fill: false
        };
    });

    const recommendedDatasets = selectedItems.map(item => {
        const data = Array(labels.length).fill(recommendedValues[item]);
        const color = getRandomColor();
        return {
            label: `${item} - 建議`,
            data: data,
            borderColor: hexToRgbA(color, 0.5),
            backgroundColor: hexToRgbA(color, 0.2),
            fill: true
        };
    });

    foodChart.data.labels = labels;
    foodChart.data.datasets = datasets.concat(recommendedDatasets);
    foodChart.update();

    updateAnalysis(selectedItems, startDate, endDate);
}

function updateAnalysis(selectedItems, startDate, endDate) {
    const analysisElement = document.getElementById('analysis');
    analysisElement.innerHTML = '';

    const start = new Date(startDate);
    const end = new Date(endDate);

    selectedItems.forEach(item => {
        let userTotal = 0;
        let dateCursor = new Date(start);

        while (dateCursor <= end) {
            const dateString = dateCursor.toISOString().split('T')[0];
            userTotal += userValues[item][dateString] || 0;
            dateCursor.setDate(dateCursor.getDate() + 1);
        }

        const days = Math.ceil((end - start) / (1000 * 60 * 60 * 24)) + 1;
        const recommendedTotal = recommendedValues[item] * days;
        const difference = userTotal - recommendedTotal;
        let analysisText = '';

        if (difference > 0) {
            analysisText = `${item} 超出建議份量 ${difference} 克`;
        } else if (difference < 0) {
            analysisText = `${item} 缺少建議份量 ${Math.abs(difference)} 克`;
        } else {
            analysisText = `${item} 剛好達到建議份量`;
        }

        const dailyPercentage = ((userTotal - recommendedTotal) / recommendedTotal) * 100;
        analysisText += `，總對比：${dailyPercentage.toFixed(2)}%`;

        const paragraph = document.createElement('p');
        paragraph.textContent = analysisText;
        analysisElement.appendChild(paragraph);
    });
}

function submitData() {
    console.log('analysis.js loaded');

    const inputDate = document.getElementById('RecordDate').value;

    if (!inputDate) {
        alert('請選擇日期');
        return;
    }

    userValues.Grains[inputDate] = parseInt(document.getElementById('Grains').value) || 0;
    userValues.Protein[inputDate] = parseInt(document.getElementById('Protein').value) || 0;
    userValues.Dairy[inputDate] = parseInt(document.getElementById('Dairy').value) || 0;
    userValues.Vegetables[inputDate] = parseInt(document.getElementById('Vegetables').value) || 0;
    userValues.Fruits[inputDate] = parseInt(document.getElementById('Fruits').value) || 0;
    userValues.OilsNuts[inputDate] = parseInt(document.getElementById('OilsNuts').value) || 0;

    alert('資料已儲存');
}

function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function hexToRgbA(hex, alpha) {
    let r = parseInt(hex.slice(1, 3), 16);
    let g = parseInt(hex.slice(3, 5), 16);
    let b = parseInt(hex.slice(5, 7), 16);

    return `rgba(${r},${g},${b},${alpha})`;
}

document.addEventListener('DOMContentLoaded', () => {
    const today = new Date().toISOString().split('T')[0];
    document.getElementById('startDate').value = today;
    document.getElementById('endDate').value = today;
});
