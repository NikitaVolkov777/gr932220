function openPopup(newsNumber) {
    document.querySelectorAll('.popup').forEach(popup => {
        popup.style.display = 'none';
    });
    const popup = document.getElementById('popup' + newsNumber);
    popup.style.display = 'block';
    document.querySelectorAll('.news').forEach(news => {
        news.style.opacity = '0.3';
    });
    document.addEventListener('click', function (event) {
        if (!popup.contains(event.target) && !event.target.closest('button')) {
            closePopup();
        }
    });
}

function closePopup() {
    document.querySelectorAll('.popup').forEach(popup => {
        popup.style.display = 'none';
    });
    document.querySelectorAll('.news').forEach(news => {
        news.style.opacity = '1';
    });
    document.removeEventListener('click', closePopup);
}
