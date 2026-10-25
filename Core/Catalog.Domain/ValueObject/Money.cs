namespace Catalog.Domain.ValueObject;

public record Money
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    private Money(decimal amount, string currency)
    {
        if (amount <= 0)
        {
            throw new AggregateException("Amount must be greater than zero");
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new AggregateException("Currency cannot be empty");
        }
        
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, string currency="USD")
    {
        return new Money(amount, currency);
    }

    public static Money operator +(Money left, Money right) //=> 3+4
    {
        if (left.Currency != right.Currency)
        {
            throw new AggregateException("Cannot add money with different currencies");
        }
        return new Money(left.Amount + right.Amount, left.Currency);
    }
    public static Money operator -(Money left, Money right) //=> 3+4
    {
        if (left.Currency != right.Currency)
        {
            throw new AggregateException("Cannot add money with different currencies");
        }
        return new Money(left.Amount - right.Amount, left.Currency);
    }
    public static Money operator *(Money money,decimal mul) //=> 3+4
    {
        return new Money(money.Amount * mul, money.Currency);
    }
    
    public override string ToString()=> $"{Amount} {Currency}";
};
