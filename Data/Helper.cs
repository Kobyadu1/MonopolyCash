using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyCash.Data
{
    public class Helper
    {
    public string generateKey()
    {
        return RandomString(6);  
    }
    private static string RandomString(int length)
    {
        const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
        var builder = new StringBuilder();

        for (var i = 0; i < length; i++)
        {
            Random rand = new Random();
            var c = pool[rand.Next(0, pool.Length)];
            builder.Append(c);
        }

        return builder.ToString();
    }
}
}
