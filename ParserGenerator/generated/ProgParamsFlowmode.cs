using System;
using System.Text;

namespace Compiler
{
  public class ProgParamsFlowmode : IprogParams
  {
    public Token FLOWMODE { get; set; } 
  
    public Token CHANGEMODE { get; set; } 
  
    public Itypedident typedident { get; set; }
  
    public IrepProgParams repProgParams { get; set; }
  
    public ProgParamsFlowmode()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
