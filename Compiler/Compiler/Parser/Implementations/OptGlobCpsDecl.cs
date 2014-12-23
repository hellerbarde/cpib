using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  public class OptGlobCpsDecl : IOptGlobCpsDecl
  {
    #region IOptGlobCpsDecl implementation
    public ICpsDecl CpsDecl { get; set; }
    #endregion
  }
}

