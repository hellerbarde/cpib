
namespace Compiler
{
  public partial class ASTIntLiteral : ASTExpression
    {
        public ASTIntLiteral(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}