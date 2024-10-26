// Фокус 1: Открытие занавеса
const curtain = document.getElementById('curtain');
const lampContainer = document.getElementById('lamp-container');

curtain.addEventListener('click', () => {
    curtain.classList.add('clicked');
    lampContainer.classList.remove('hidden');
});

// Фокус 2: Лампа и свет
const lamp = document.getElementById('lamp-image');
const light = document.getElementById('light');

const magic = document.getElementById('magic-show');

const rabbit = document.getElementById('rabbit');
const bird = document.getElementById('bird');
const hat = document.getElementById('hat');
const witch = document.getElementById('witch');

lamp.addEventListener('click', () => {
    light.classList.toggle('on');
    light.classList.remove('hidden');

    if (light.classList.contains('on')) {
        magic.classList.remove('hidden'); 
    } else {
        magic.classList.add('hidden');
    }
});
lamp.addEventListener('mousedown', () => {
    lamp.classList.add('pressed');
});

lamp.addEventListener('mouseup', () => {
    lamp.classList.remove('pressed');
});

lamp.addEventListener('mouseleave', () => {
    lamp.classList.remove('pressed');
});

rabbit.addEventListener('click', () => {
    rabbit.style.transform = 'translateY(100px)';
    rabbit.style.opacity = '0';
    bird.classList.remove('hidden');
    setTimeout(() => {
        rabbit.classList.add('hidden');
        bird.style.opacity = '1';
        bird.style.transform = 'translateY(-70px)';
    }, 500); 
});
bird.addEventListener('click', () => {
    bird.style.transform = 'translateY(70px)';
    bird.style.opacity = '0';
    rabbit.classList.remove('hidden');
    setTimeout(() => {
        bird.classList.add('hidden');
        rabbit.style.transform = 'translateY(0)';
        rabbit.style.opacity = '1';
    }, 500);
});

