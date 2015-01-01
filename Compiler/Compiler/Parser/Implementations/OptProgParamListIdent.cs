using System;
using System.Text;

namespace Compiler
{
  public partial class OptProgParamListIDENT : IOptProgParamList
  {
    public IProgParam ProgParam { get; set; }
  
    public IRepProgParamList RepProgParamList { get; set; }
  
    public OptProgParamListIDENT()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
