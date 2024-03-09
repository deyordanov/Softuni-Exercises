document.querySelector('#confirm-back-btn').addEventListener('click', (e) => getBackToPersonalData(e));

function getBackToPersonalData(e) {
    e.preventDefault();
    changeContent('guest-details-form-content');
}


document.querySelector('#confirm-reservation').addEventListener('click', (e) => showThanksPage(e));

function showThanksPage(e) {
    e.preventDefault();
    changeContent('thank-you-content');
}
