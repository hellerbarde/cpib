
namespace Compiler
{
  public partial class ASTBoolLiteral : IASTNode
    {
        public ASTBoolLiteral(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}