public class Customer
{
    private string _name = null!;

    public int Id { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
    public string Name { get => _name; set => _name = String.IsNullOrEmpty(value) ? _name : value; }

    public void PrintCustomerInfo() 
        => Console.WriteLine($"Имя заказчика: {Name}{Environment.NewLine}Email заказчика: {Email}");
}
