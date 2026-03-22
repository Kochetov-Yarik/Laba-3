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
        _amount = amount;
    }
    public Payment(string type) : this(0m, type)
    {
    }
}
