using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  class RepCmd : IRepCmd
  {
    public ICmd Cmd {
      get;
      set;
    }

    public IRepCmd repCmd {
      get;
      set;
    }
  }
}

