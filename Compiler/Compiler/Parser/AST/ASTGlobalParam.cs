using System.Text;
using System;
using System.Linq;

namespace Compiler
{
    public class ASTGlobalParam : IASTNode
    {
        public ASTGlobalParam()
        {
            NextParam = new ASTEmpty();
        }

        public IASTNode NextParam { get; set; }

        public string Ident { get; set; }

        public ChangeMode? OptChangemode { get; set; }

        public FlowMode? FlowMode { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FlowMode, OptChangemode, Ident);
        }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTGlobalParam({1}, {2}, {3})", ind, FlowMode, OptChangemode, Ident));
    }

        public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
        {
            throw new IVirtualMachine.InternalError("ASTGlobalParam.GenerateCode was called. This should never happen!");
        }
    }
}