using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public partial class ASTStoDecl : ASTCpsDecl, IASTStoDecl
  {
    //public string Ident { get; set; }

    public ASTTypeOrArray TypeOrArray { get; set; }

    public Type Type { get; set; }

    public ChangeMode Changemode { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1} : {2}", Changemode, Ident, TypeOrArray);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      var ind = String.Concat(Enumerable.Repeat(" ", level));
      sb.AppendLine(string.Format("{0}ASTStoDecl({1} {2} : {3})", ind, Changemode, Ident, TypeOrArray));
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      return loc;
    }
  }
}