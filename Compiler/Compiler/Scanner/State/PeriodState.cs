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
      if (data == '.') {
        scanner.AddToken(scanner.Keywords[".."]);
        scanner.CurrentState = new DefaultState();
        scanner.CurrentState.Handle(scanner, data);
      }
      else {
        throw new LexicalException("Found '.'; '..' expected.");
      }
    }
  }
}
