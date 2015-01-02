
namespace Compiler
{
  public partial class ASTCpsDecl : IASTNode
    {
        public string Ident { get; set; }

        public ASTCpsDecl()
        {
            NextDecl = new ASTEmpty();
        }

        public IASTNode NextDecl { get; set; }

        public abstract int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);
    }
}