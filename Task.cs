class Payment
{
    private readonly int _paymentId;
    private decimal _amount;
    private string _type;
    private static int _totalPayments;
    public Payment(decimal amount, string type)
    {
        _totalPayments++;
        _paymentId = _totalPayments;
        _type = type;
        ChangeAmount(amount);
    }
    public Payment(string type) : this(0m, type)
    {
    }
    public void ChangeAmount(decimal newAmount)
    {
        if (newAmount >= 0)
        {
            _amount = newAmount;
        }
        else
        {
            Console.WriteLine("Сума не може бути від'ємною!");
        }
    }
    public bool IsLarge(decimal limit)
    {
        return _amount > limit;
    }
     public static int TotalPayments()
    {
        return _totalPayments;
    }
    public override string ToString()
    {
        return $"Платіж №{_paymentId} | Тип: {_type} | Сума: {_amount} грн.";
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("--- Створення платежів ---");
        Payment payment1 = new Payment(1686.70m, "Оплата гуртожитку");
        Payment payment2 = new Payment("Переказ за карту");

        Console.WriteLine(payment1.ToString());
        Console.WriteLine(payment2.ToString());

        Console.WriteLine("\n--- Зміна суми ---");

        payment2.ChangeAmount(400.40m);
        Console.WriteLine("Після поповнення: " + payment2.ToString());

        Console.Write("\nСпроба встановити -50 грн: \n");
        payment2.ChangeAmount(-50m);

        Console.WriteLine("\n--- Перевірка чи великий платіж ---");

        decimal limit = 1000m;
        Console.WriteLine($"Чи {payment1.ToString()} більший за {limit}? {payment1.IsLarge(limit)}");
        Console.WriteLine($"Чи {payment2.ToString()} більший за {limit}? {payment2.IsLarge(limit)}");

        Console.WriteLine($"\nВсього в системі створено платежів: {Payment.TotalPayments()}");

        Console.ReadLine();
    }
}
