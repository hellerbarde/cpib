
namespace Compiler
{
  public partial class ASTCpsCmd : IASTNode
    {
        public ASTCpsCmd()
        {
            NextCmd = new ASTEmpty();
        }
        public IASTNode NextCmd { get; set; }
    }
}