
namespace Compiler
{
  public partial class ASTOptExprList : IASTNode
    {
        public IASTNode Expr { get; set; }

        public IASTNode RepExpr { get; set; }
    }
}