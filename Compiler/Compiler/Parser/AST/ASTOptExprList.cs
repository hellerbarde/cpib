
namespace Compiler
{
    public class ASTOptExprList : IASTNode
    {
        public IASTNode Expr { get; set; }

        public IASTNode RepExpr { get; set; }
    }
}