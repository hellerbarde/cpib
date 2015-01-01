using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListCHANGEMODE : IOptProgParamList
  {
    public IProgParam progparam { get; set; }
  
    public IRepProgParamList repprogparamlist { get; set; }
  
    public OptProgParamListCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
