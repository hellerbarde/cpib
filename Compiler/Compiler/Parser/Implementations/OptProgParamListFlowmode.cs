using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListFLOWMODE : IOptProgParamList
  {
    public IProgParam progparam { get; set; }
  
    public IRepProgParamList repprogparamlist { get; set; }
  
    public OptProgParamListFLOWMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
