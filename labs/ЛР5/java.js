try {
    let clickCount = 0
    document.querySelector('.button-class').addEventListener('click', () => {
        clickCount++
        console.log("Кнопка тронута", clickCount, "раз")
        console.warn("Сейчас пойдёт цикл")
        for (let i = 0; i < 100; i++) {
            console.log(i);
        }
    })
  console.error("Произошла ошибка: ???");
} catch (error) {
  console.error("Произошла ошибка:", error.message);
}