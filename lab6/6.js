function openColumn(columnNumber) {
    document.querySelectorAll('.column').forEach(column => {
        column.style.display = 'block';
        column.style.width = '10%';
        const img = column.querySelector('img');
        img.style.display = 'none';
        img.style.height = '70%';
        img.style.width = '70%';

    });

    const column = document.getElementById('column' + columnNumber);
    const img = column.querySelector('img');
    column.style.width = '90%';
    img.style.display = 'block';
}
function openBoth() {
    document.querySelectorAll('.column').forEach(column => {
        column.style.display = 'block';
        column.style.width = '50%';
        const img = column.querySelector('img');
        img.style.display = 'block';
        img.style.width='90%';
        img.style.height = '70%';
    });
}
