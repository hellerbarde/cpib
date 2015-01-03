using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public abstract class ASTCpsCmd : IASTNode
  {
    public ASTCpsCmd()
    {
      NextCmd = new ASTEmpty();
    }

    public abstract void printAST(int level, StringBuilder sb);

    public IASTNode NextCmd { get; set; }

    public abstract int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);
  }
}