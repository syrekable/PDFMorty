using System.Text.RegularExpressions;

namespace PDFMorty.Validation
{
    public static class PasswordValidator
    {
        public static bool Validate(string password)
        {
            /*
             * the password shall consist of:
                -at least one lower
                -at least one uppercase letter, 
                -at least one digit,
                -at least one symbol from [.,*]
                -at least 8 and at most 20 characters
            */
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[,.*])(?!.*\s).{8,20}$");
        }
    }
}