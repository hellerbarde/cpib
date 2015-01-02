using System.Collections.Generic;


namespace Compiler
{
  public partial class ASTArrayLiteral : IASTNode
  {
    public ASTArrayLiteral(List<int> value)
    {
      this.Value = value;
    }

    public List<int> Value { public get; set; }

    public override string ToString()
    {
      return Value.ToString();
    }
  }
}