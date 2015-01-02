namespace Compiler
{
  public partial class ASTExpression : IASTNode
    {
        public ASTExpression()
        {
            NextExpression = new ASTEmpty();
        }

        public IASTNode NextExpression { get; set; }
        public abstract int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);

        public abstract Type GetExpressionType(CheckerInformation info);
    }
}