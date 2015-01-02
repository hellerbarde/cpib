using System.Collections.Generic;

using Compiler._02Parser.AST;

namespace Compiler
{
    public class ASTIf : ASTCpsCmd
    {
        public IASTNode Condition { get; set; }

        public List<ASTCpsCmd> TrueCommands { get; set; }

        public List<ASTCpsCmd> FalseCommands { get; set; }

        public override string ToString()
        {
            if (this.FalseCommands is ASTEmpty)
            {
                return string.Format(@"if {0} then
    {1}
endif", Condition, this.TrueCommands);
            }
            else
            {
                return string.Format(@"if {0} then", Condition);
            }
        }

        public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            throw new System.NotImplementedException();
        }
    }
}