
namespace Compiler
{
  public partial class ASTOptInit : IASTNode
    {
        public string Ident { get; set; }

        public IASTNode NextInit { get; set; }
    }
}