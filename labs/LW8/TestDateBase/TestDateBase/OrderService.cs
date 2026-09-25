using Microsoft.EntityFrameworkCore;

public class OrderService
{
    private int _minPriceForDiscount = 10000;
    private double _discountPercent = 0.1;
    private double _tax = 0.2;
    private double _discount = 0;

    private readonly AppDbContext _dbContext;

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }

    public void PrintOrderDetails(int orderId)
    {
        var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
        if (order is null)
        {
            Console.WriteLine("Заказа нет.");
            return;
        }

        PrintOrderInfo(order);
    }

    private static void PrintOrderInfo(Order order)
    {
        PrintOrderId(order);
        PrintOrderPrice(order);
        PrintExpressOrNot(order);
        order.Customer.PrintCustomerInfo();
    }

    private static void PrintExpressOrNot(Order order)
        => Console.WriteLine($"Экспресс-доставка: {(order.IsExpress ? "Да" : "Нет")}");


    private static void PrintOrderPrice(Order order)
        => Console.WriteLine($"Цена заказа: {order.TotalPrice}");


    private static void PrintOrderId(Order order)
        => Console.WriteLine($"Id заказа: {order.Id}");


    public double CalculateFinalPrice(Order order)
    {
        CountDiscount(order);
        var finalPrice = CountFinalPrice(order);
        return finalPrice;
    }

    private double CountFinalPrice(Order order) =>
         order.TotalPrice - _discount + (order.TotalPrice * _tax);

    private void CountDiscount(Order order)
    {
        _discount = (order.TotalPrice > _minPriceForDiscount) 
            ? order.TotalPrice * _discountPercent 
            : 0;
    }

}