using System;
using System.Text;

namespace Compiler
{
  public class FactorIdent : Ifactor
  {
    public Token IDENT { get; set; } 
  
    public IoptInitParamsOrArrayAccess optInitParamsOrArrayAccess { get; set; }
  
    public FactorIdent()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
