using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTParam : IASTNode, IASTStoDecl
  {
    public ASTParam()
    {
      NextParam = new ASTEmpty();
      AddressLocation = null;
    }

    public bool isInitialized { get; set; }

    public string Ident { get; set; }

    public IASTNode NextParam { get; set; }

    public ASTTypeOrArray TypeOrArray { get; set; }
    //public Type Type { get; set; }
    public int Address { get; set; }

    /// <summary>
    /// Location where the address of this identifier is stored.
    /// This is only used for: out copy and inout copy parameters
    /// </summary>
    public int? AddressLocation { get; set; }

    public FlowMode? FlowMode { get; set; }

    public ChangeMode? OptChangemode { get; set; }

    public MechMode? OptMechmode { get; set; }

    public virtual int Size()
    {
      if (this.TypeOrArray.isArray) {
        int memoryRequired = this.TypeOrArray.dimensions.Aggregate<int>((u, v) => u * v);
        return memoryRequired;  
      }
      else {
        return 1;
      }
            
    }

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
      throw new IVirtualMachine.InternalError("ASTParam.GenerateCode was called. This should never happen!");
    }
  }
}