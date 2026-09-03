/*string value = "";

while (value != "exit")
{
    Console.Write("Введите первое число: ");
#if DEBUG
    Debug.WriteLine("Ввод первого числа");
#endif

#if RELEASE
    Trace.WriteLine("Дублирование сообщения");
#endif
    int firstNumber = int.Parse(Console.ReadLine());
    Console.Write("Введите второе число: ");
#if DEBUG
    Debug.WriteLine("Ввод второго числа");
#endif

#if RELEASE
    Trace.WriteLine("Дублирование сообщения");
#endif
    int secondNumber = int.Parse(Console.ReadLine());
    Console.WriteLine($"Сумма: {firstNumber + secondNumber}");
    value = Console.ReadLine().ToLower();
}

Console.Write("Введите цену: ");
double price = double.Parse(Console.ReadLine());
Console.Write("Введите скидку: ");
double discountRate = double.Parse(Console.ReadLine());
double CalculateDiscount(double price, double discountRate)
{
    Debug.Assert(price > 0);
    Debug.Assert(discountRate is > 0 and < 1);
    Debug.Assert(price * discountRate <= price);
    return price * discountRate;
}

Console.WriteLine(CalculateDiscount(price, discountRate));
*/

void Main()
{
    MethodA();
}
void MethodA()
{
    MethodB();
}
void MethodB()
{
    MethodC();
}
void MethodC()
{
    try
    { throw new DivideByZeroException(); }
    catch(Exception ex)
    { 
        File.WriteAllText( "trace.txt", ex.StackTrace);
    }
}

Main();