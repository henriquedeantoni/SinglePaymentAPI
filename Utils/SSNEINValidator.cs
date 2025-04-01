using System.Text.RegularExpressions;

namespace SinglePaymentAPI.Utils;

public static class SSNEINValidator
{
    private static readonly Regex ssnRegex = new(@"^\d{9}$");
    private static readonly Regex einRegex = new(@"^\d{9}$");

    public static bool IsSsn(string ssn)
    {
        if (!ssnRegex.IsMatch(ssn))
            return false;

        // Verifica prefixos inválidos para SSN
        string prefix = ssn.Substring(0, 3);
        string[] invalidSsnPrefixes = { "000", "666", "900", "999" };

        return !invalidSsnPrefixes.Contains(prefix);
    }

    public static bool IsEin(string ein)
    {
        return einRegex.IsMatch(ein);
    }

    public static bool IsValidSsnEin(string input)
    {
        return IsSsn(input) || IsEin(input);
    }
    public static string RemoveNonDigits(string input)
    {
        return Regex.Replace(input, @"\D", ""); // Remove tudo que não for número
    }

    public static string FormatSsn(string ssn)
    {
        return IsSsn(ssn) ? $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}" : ssn;
    }

    public static string FormatEin(string ein)
    {
        return IsEin(ein) ? $"{ein.Substring(0, 2)}-{ein.Substring(2, 7)}" : ein;
    }
}
