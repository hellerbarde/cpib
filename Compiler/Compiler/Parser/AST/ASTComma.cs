
namespace Compiler
{
  public partial class ASTComma : IASTNode
    {
        public IASTNode Expr { get; set; }

        public IASTNode RepExpr { get; set; }
    }
}