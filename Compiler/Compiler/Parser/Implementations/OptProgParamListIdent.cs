using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListIDENT : IOptProgParamList
  {
    public IProgParam progparam { get; set; }
  
    public IRepProgParamList repprogparamlist { get; set; }
  
    public OptProgParamListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
