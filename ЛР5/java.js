let clickCount = 0
document.querySelector('.button-class').addEventListener('click', () => {
    clickCount++
    console.log("Кнопка тронута", clickCount, "раз")
})