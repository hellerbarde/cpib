using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
  public class PeriodState : State
  {

    public override void Handle(Scanner scanner, char data)
    {
      scanner.CurrentState = new DefaultState();
      if (data == '.') {
        scanner.AddToken(scanner.Keywords[".."](0));
        //scanner.CurrentState = new DefaultState();
        //scanner.CurrentState.Handle(scanner, data);
      }
      else {
        throw new LexicalException("Found '"+data+"'; '..' expected.");
      }
    }
  }
}
