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
