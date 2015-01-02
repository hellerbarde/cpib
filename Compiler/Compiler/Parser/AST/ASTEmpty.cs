namespace Compiler
{
  public partial class ASTEmpty:IASTNode
    {
        public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info) { return loc; }
    }
}