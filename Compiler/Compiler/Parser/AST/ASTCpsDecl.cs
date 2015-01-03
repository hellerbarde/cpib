using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public abstract class ASTCpsDecl : IASTNode, IASTDecl
  {
    public ASTCpsDecl()
    {
      NextDecl = new ASTEmpty();
    }

    public string Ident { get; set; }

    public IASTNode NextDecl { get; set; }

    public abstract void printAST(int level, StringBuilder sb);

    public abstract int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);
  }
}