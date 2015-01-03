using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public partial class ASTType : IASTNode
  {
    public Type Type { get; set; }

    public IASTNode Expr { get; set; }

    public override string ToString()
    {
      return string.Format("{0}({1})", Type, Expr);
    }

    public void printAST(int level, StringBuilder sb)
    {
      throw new NotImplementedException();
    }

    public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}