using System;

namespace Aplicacao_CNAB.CNABBL
{
    public class Utils
    {
        public Boolean PermiteNumeros(String str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^\d$");
        }

        public Boolean PermiteAlphanumericos(String str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, "^[a-zA-Z0-9]*$");
        }
    }
}