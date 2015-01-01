using System;
using System.Text;

namespace Compiler
{
  public partial class OptParamListCHANGEMODE : IOptParamList
  {
    public IParam Param { get; set; }
  
    public IRepParamList RepParamList { get; set; }
  
    public OptParamListCHANGEMODE()
    {
    }

    public override String ToString()
    {
      return ("lalalal");
    }
  }
}
