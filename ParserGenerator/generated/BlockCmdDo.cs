using System;
using System.Text;

namespace Compiler
{
  public class BlockCmdDo : IblockCmd
  {
    public Token DO { get; set; } 
  
    public Icmd cmd { get; set; }
  
    public IrepCmd repCmd { get; set; }
  
    public IendBlock endBlock { get; set; }
  
    public BlockCmdDo()
    {
    }

    public override String ToString()
    {
      return ("TBD");
    }
  }
}
