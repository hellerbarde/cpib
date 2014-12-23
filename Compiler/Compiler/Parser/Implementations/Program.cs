using System;
using System.Text;

namespace Compiler
{
  public class Program : IProgram
  {
    #region IProgram implementation

    public Token Ident { get; set;}

    public ICmd Cmd { get; set; }

    public IRepCmd RepCmd { get; set;}

    public IOptGlobCpsDecl OptGlobCpsDecl { get; set; }

    public IProgParamList ProgParamList { get; set; }

    #endregion

    public Program()
    {
    }

    public override String ToString(){
//      StringBuilder sb = new StringBuilder("This is a program called " + ((IdentToken)Ident).Value);
//      sb.AppendLine(ProgParamList.ToString)
//      return (sb.ToString());
      return ("This is a program called " + ((IdentToken)Ident).Value);
    }
  }
}

