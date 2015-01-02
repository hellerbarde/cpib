using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compiler.Helpers;

namespace Compiler
{
    public class TextState : State
    {
        private StringBuilder text;
        public TextState(string start) { text = new StringBuilder(start); }
        public override void Handle(Scanner scanner, char data)
        {
            if (Char.IsLetterOrDigit(data) && data <= 'z') { text.Append(data); }
            else
            {
                string token = text.ToString();
<<<<<<< HEAD:Compiler/Compiler/Scanner/State/TextState.cs
        if (scanner.Keywords.ContainsKey(token)) { scanner.AddToken(scanner.Keywords[token]()); }
=======
                if (scanner.Keywords.ContainsKey(token)) { scanner.AddToken(scanner.Keywords[token].DeepClone()); }
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/State/TextState.cs
                else { scanner.AddToken(new IdentToken(token)); }
                scanner.CurrentState = new DefaultState();
                scanner.CurrentState.Handle(scanner, data);
            }
        }
    }
}
