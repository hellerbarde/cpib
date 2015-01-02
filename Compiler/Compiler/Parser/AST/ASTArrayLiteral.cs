using System.Collections.Generic;


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
  }
}