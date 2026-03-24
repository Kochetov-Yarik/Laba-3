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

    //ЗАВДАННЯ 2
    public int PaymentId
    {
        get { return _paymentId; }
    }

    public string Type
    {
        get { return _type; }
    }
    public decimal Amount
    {
        get { return _amount; }
    }
    public Payment(int paymentId, decimal amount, string type)
    {
        _paymentId = paymentId;
        _amount = amount;
        _type = type;
    }
    public void SaveToJson(string filePath)
    {
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
        System.IO.File.WriteAllText(filePath, json);
        Console.WriteLine($"\nДані збережено у файл: {filePath}");
    }
    public static Payment LoadFromJson(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            var data = Newtonsoft.Json.Linq.JObject.Parse(json);
            int loadedId = (int)data["PaymentId"];
            decimal loadedAmount = (decimal)data["Amount"];
            string loadedType = (string)data["Type"];
            return new Payment(loadedId, loadedAmount, loadedType);
        }
        return null;
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string fileName = "payment.json";
        Console.WriteLine("1 - Створити платежі та зберегти у файл");
        Console.WriteLine("2 - Зчитати існуючий платіж з JSON файлу");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("\n Створення платежів ");
            Payment payment1 = new Payment(1686.70m, "Оплата гуртожитку");
            Payment payment2 = new Payment("Переказ на карту");

            Console.WriteLine(payment1.ToString());
            Console.WriteLine(payment2.ToString());

            Console.WriteLine("\n Зміна суми ");
            payment2.ChangeAmount(400.40m);
            Console.WriteLine("Після поповнення: " + payment2.ToString());

            Console.WriteLine($"\nВсього в системі створено нових платежів: {Payment.TotalPayments()}");

            Console.WriteLine("\n Збереження ");
            payment1.SaveToJson(fileName);
        }
        else if (choice == "2")
        {
            Console.WriteLine("\n Завантаження з файлу ");

            Payment loadedPayment = Payment.LoadFromJson(fileName);

            if (loadedPayment != null)
            {
                Console.WriteLine("Дані успішно відновлено!");
                Console.WriteLine(loadedPayment.ToString());
            }
        }
        else
        {
            Console.WriteLine("\nПомилка: Неправильний вибір. Натисніть Enter для виходу.");
        }

        Console.ReadLine();
    }
}
