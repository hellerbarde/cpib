
namespace Compiler
{
  public partial class ASTRelOpr : ASTExpression
    {
        public ASTRelOpr()
        {
            Term = new ASTEmpty();
            RepTerm = new ASTEmpty();
        }
        public Operators Operator { get; set; }

        public IASTNode Term { get; set; }

        public IASTNode RepTerm { get; set; }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", Term, Operator, RepTerm);
        }
    }
}