using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public partial class ASTParam : IASTNode, IASTStoDecl
  {
    public ASTParam()
    {
      NextParam = new ASTEmpty();
    }

    public string Ident { get; set; }

    public IASTNode NextParam { get; set; }

    public ASTTypeOrArray TypeOrArray { get; set; }

    public Type Type { get; set; }

    public FlowMode? FlowMode { get; set; }

    public ChangeMode? OptChangemode { get; set; }

    public MechMode? OptMechmode { get; set; }

    public override string ToString()
    {
      return String.Format("{0} {1} {2} {3}", this.OptChangemode, this.FlowMode, this.TypeOrArray, this.Ident);
    }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTParam({1} {2} {3} {4})", ind, OptChangemode, FlowMode, TypeOrArray, Ident));
    }

    public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      return loc;
    }
  }
}