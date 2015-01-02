using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace Compiler
{
  public class ContextException : Exception
  {
    public ContextException(String message) : base(message)
    {

    }
  }


}