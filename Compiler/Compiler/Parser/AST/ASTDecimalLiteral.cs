
namespace Compiler
{
  public partial class ASTDecimalLiteral : IASTNode
    {
        public ASTDecimalLiteral(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}m", this.Value);
        }
    }
}