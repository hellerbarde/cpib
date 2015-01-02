
namespace Compiler
{
  public partial class ASTIdent : ASTExpression
  {
    public string Ident { get; set; }

    public IASTNode OptInitOrExprListOrArrayAccess { get; set; }

    public bool IsInit { get; set; }

    public bool IsArrayAccess {
      get;
      set;
    }

    public override string ToString()
    {
      return string.Format("{0}{1}", IsInit ? "init " : "", Ident);
    }
  }
}