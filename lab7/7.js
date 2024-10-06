function getRandomPosition(size) {
    const x = Math.floor(Math.random() * (window.innerWidth - size));
    const y = Math.floor(Math.random() * (window.innerHeight - size));
    return { x, y };
}
function getRandomSize() {
    return Math.floor(Math.random() * (151)) + 30;
}
function addFigures(type) {
    const count = parseInt(document.getElementById('count').value);
    if (count <= 0) {
        alert("Too few figures, let`s have more");
    }
    else if (count >= 10) {
        alert("Too many figures, let`s have less");
    }
    else {
        for (let i = 0; i < count; i++) {
            const figure = document.createElement('div');
            figure.classList.add('figure', type);

            const size = getRandomSize();
            figure.style.width = `${size}px`;
            figure.style.height = `${size}px`;
            if (type === 'triangle') {
                figure.style.borderLeft = `${size / 2}px solid transparent`;
                figure.style.borderRight = `${size / 2}px solid transparent`;
                figure.style.borderBottom = `${size}px solid blue`;
            }
            else if (type === 'circle') {
                figure.style.borderRadius = `50%`;
            }
            const position = getRandomPosition(size);
            figure.style.left = `${position.x}px`;
            figure.style.top = `${position.y}px`;

            figure.addEventListener('click', function () {
                if (type == 'triangle') {
                    figure.style.borderBottom = `${size}px solid yellow`;
                }
                else {
                    figure.style.backgroundColor = 'yellow';
                }
            });

            figure.addEventListener('dblclick', function () {
                this.remove();
            });

            document.body.appendChild(figure);
        }
    }
}
