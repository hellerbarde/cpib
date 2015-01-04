using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTStoDecl : ASTCpsDecl, IASTStoDecl
  {
    public ASTTypeOrArray TypeOrArray { get; set; }

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
      throw new IVirtualMachine.InternalError("ASTStoDecl.GenerateCode was called. This should never happen!");
    }

    public override int Size()
    {
      if (this.TypeOrArray.isArray) {
        int memoryRequired = this.TypeOrArray.dimensions.Aggregate<int>((aggregate, next) => aggregate * next);
        return memoryRequired;  
      }
      else {
        return 1;
      }

    }

  }
}