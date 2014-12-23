using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Compiler
    {
        static void Main(string[] args)
        {
            try
            {
                Scanner scanner = new Scanner();
                var list = scanner.Scan(new System.IO.StreamReader("test03.iml"));
                Console.WriteLine("[" + String.Join(", ", list) + "]");
                Parser parser = new Parser(list);
                IProgram program = parser.parse();
                Console.WriteLine(program.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed: " + ex.Message);
            }
        }
    }
}
