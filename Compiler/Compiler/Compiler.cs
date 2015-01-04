using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler
{
  class Compiler
  {
    static void Main(string[] args)
    {
      try {
        Console.WriteLine("args: (" + String.Join(",",args)+")");
        var scanner = new Scanner();
        var list = scanner.Scan(new System.IO.StreamReader("test02.iml"));
        //Console.WriteLine("[" + String.Join(",\n", list) + "]");
        var parser = new Parser(list);
        IProgram cst = parser.parseprogram();
        //Console.WriteLine(program);
        var ast = cst.ToAbstractSyntax();
        //Console.WriteLine(ast.ToString());
        if(!(ast is ASTProgram))
        {
          throw new IVirtualMachine.InternalError("Generation of Abstract Syntax Tree failed.");
        }
        ASTProgram program = (ASTProgram)ast;

        var stringbuilder = new StringBuilder();
        program.printAST(0, stringbuilder);
        //Console.Write(stringbuilder.ToString());
        //return;
        //Checker
        CheckerInformation info = new CheckerInformation();
        ScopeChecker contextChecker = new ScopeChecker();
        contextChecker.Check(program, info);
        //Code Generator
        IVirtualMachine vm = new VirtualMachine(1000, 1000);
        program.GenerateCode(0, vm, info);
        Console.WriteLine(vm.ToString());
        Console.WriteLine();
        //Execution
        vm.Execute();
      } catch (Exception ex) {
        Console.WriteLine("Failed: " + ex.Message);
        Console.WriteLine(ex.StackTrace);
        throw;
      }
    }
  }
}
