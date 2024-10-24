using System.Text.RegularExpressions;

public class EmailValidator
{
    public static bool IsValidEmail(string email)
    {
        // reasonable comment example: 
        // Simple email validation pattern
        // This pattern checks for valid characters,
        // the "@" symbol, domain names, and top-level domains (TLDs).

        // Examples of matching strings:
        // somebody@gmail.com
        // someone@yahoo.fr
        //
        // Examples of non-matching strings:
        // somebody@gmail
        // @yahoo.fr
        string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

        return Regex.IsMatch(email, pattern);
    }
}
