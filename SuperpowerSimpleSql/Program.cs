using System;
using Superpower;

namespace SuperpowerSimpleSql
{
    class Program
    {
        static int Main()
        {
            try
            {
                var tokenizer = new SqlTokenizer();
                var tokens = tokenizer.Tokenize("select 1 + 23, 456");

                Console.WriteLine("Tokens:");
                foreach (var token in tokens)
                    Console.WriteLine(token);

                Console.WriteLine();

                var result = SqlParser.SelectClause.Parse(tokens);
                Console.WriteLine("Result:");
                Console.WriteLine(result);
                Console.WriteLine();
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return 1;
            }
        }
    }
}
