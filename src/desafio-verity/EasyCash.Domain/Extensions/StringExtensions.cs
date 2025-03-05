namespace EasyCash.Domain.Extensions;

public static class StringExtensions
{
    public static string ToOnlyNumbers(this string @string)
    {
        var result = string.Empty;

        foreach (var c in @string)
            if (char.IsNumber(c))
                result += c;

        return result;
    }
}

