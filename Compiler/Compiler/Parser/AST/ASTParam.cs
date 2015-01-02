using System;

namespace Compiler
{
  public partial class ASTParam : IASTNode, IASTStoDecl
  {
    public ASTParam()
    {
      NextParam = new ASTEmpty();
    }

    public IASTNode NextParam { get; set; }

    public ASTTypeOrArray TypeOrArray { get; set; }

    public Type Type { get; set; }

    public string Ident { get; set; }

    public FlowMode? FlowMode { get; set; }

    public ChangeMode? OptChangemode { get; set; }

    public MechMode? OptMechmode { get; set; }

    public override string ToString()
    {
      return String.Format("{0} {1} {2} {3}", this.OptChangemode, this.FlowMode, this.TypeOrArray, this.Ident);
    }

    public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      return loc;
    }
  }
}