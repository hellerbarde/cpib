using System;
using System.Collections.Generic;

namespace Compiler
{
  class Compiler
  {
    static void Main(string[] args)
    {
      try {
        Console.WriteLine("args: " + args);
        var scanner = new Scanner();
        var list = scanner.Scan(new System.IO.StreamReader("test04.iml"));
        Console.WriteLine("[" + String.Join(",\n", list) + "]");
        var parser = new Parser(list);
        IProgram program = parser.parseprogram();
        //Console.WriteLine(program);
        var ast = program.ToAbstractSyntax();
        Console.WriteLine(ast.ToString());
      } catch (Exception ex) {
        Console.WriteLine("Failed: " + ex.Message);
        Console.WriteLine(ex.StackTrace);
      }
    }
  }
}
