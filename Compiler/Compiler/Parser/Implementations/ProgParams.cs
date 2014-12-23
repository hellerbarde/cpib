using System;

namespace Compiler
{
  public class ProgParams : IProgParams
  {
    public Token Flowmode {
      get;
      set;
    }

    public Token Changemode {
      get;
      set;
    }

    public ITypedIdent TypedIdent {
      get;
      set;
    }

    public IRepProgParams repProgParams {
      get;
      set;
    }

    public ProgParams()
    {
    }
  }
}

