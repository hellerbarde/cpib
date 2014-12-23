using System;

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
  }
}

