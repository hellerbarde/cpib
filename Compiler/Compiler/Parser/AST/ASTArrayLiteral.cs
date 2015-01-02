using System.Collections.Generic;
using System;


namespace Compiler
{
  public partial class ASTArrayLiteral : ASTExpression
  {
    public ASTArrayLiteral()
    {
      this.Value = new List<ASTExpression>();
    }

    public List<ASTExpression> Value { get; set; }

    public override string ToString()
    {
      return Value.ToString();
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new NotImplementedException();
      //vm.IntLoad(loc++, Value); // TODO TODO TODO
      //return loc;
    }
      
    public override Type GetExpressionType(CheckerInformation info)
    {
      throw new NotImplementedException(); // TODO TODO
      //return Type.INT32;
    }

  }
}