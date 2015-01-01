
namespace Compiler
{
    public class ASTCpsDecl : IASTNode
    {
        public ASTCpsDecl()
        {
            NextDecl = new ASTEmpty();
        }

        public IASTNode NextDecl { get; set; }
    }
}