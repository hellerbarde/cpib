using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  public interface IProgram
  {
    Token Ident { get; set; }

    ICmd Cmd {
      get;
      set;
    }

    IRepCmd RepCmd {
      get;
      set;
    }

    IOptGlobCpsDecl OptGlobCpsDecl {
      get;
      set;
    }

    IProgParamList ProgParamList { get; set; }
  }
}

