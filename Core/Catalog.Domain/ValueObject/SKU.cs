using System.Text.RegularExpressions;

namespace Catalog.Domain.ValueObject;

public class SKU
{
    private static readonly Regex skuRegex = new (@"^[A-Z0-9-_]+$", RegexOptions.Compiled);
    public string Value { get; init; }


    private SKU(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SKU value cannot be null or whitespace.", nameof(value));
        if (!skuRegex.IsMatch(value))
            throw new ArgumentException("SKU value must consist of only alphanumeric characters.");
        Value = value;
    }

    public static SKU create(string value)
    {
        return new SKU(value);
    }
}