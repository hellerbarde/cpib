using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Compiler
{
  public partial class ASTProgram : IASTNode
  {
    public string Ident { get; set; }

    public IList<ASTParam> Params { get; set; }

    public List<ASTCpsDecl> Declarations { get; set; }

    public List<ASTCpsCmd> Commands { get; set; }

    public override string ToString()
    {
      return string.Format("Program {0}", Ident);
    }

    public void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTProgram({1})", ind, Ident));

      sb.AppendLine(string.Format("{0}[Params]:", ind));
      foreach (var a in Params) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Declarations]:", ind));
      foreach (var a in Declarations) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Commands]:", ind));
      foreach (var a in Commands) {
        a.printAST(level + 1, sb);
      }
    }

    public int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
        //Allocate global storage
        vm.Alloc(loc++, info.Globals.Count);
        //Load input params
        int address = 0;
        foreach (string ident in info.Globals)
        {
            IASTStoDecl decl = info.Globals[ident];
            if (decl is ASTParam)
            {
                ASTParam param = (ASTParam)decl;
                if (param.FlowMode == FlowMode.IN || param.FlowMode == FlowMode.INOUT)
                {
                    //Load address where to save the input
                    vm.IntLoad(loc++, address);
                    //Switch between types:
            switch (param.TypeOrArray.Type)
                    {
                        case Type.INT32:
                            vm.IntInput(loc++, ident);
                            break;
                        case Type.BOOL:
                            vm.BoolInput(loc++, ident);
                            break;
                        case Type.DECIMAL:
                            vm.DecimalInput(loc++, ident);
                            break;
                    }
                }
            }
            address++;
        }
        //Generate main code
        foreach (ASTCpsCmd cmd in Commands)
        {
            loc = cmd.GenerateCode(loc, vm, info);
        }
        //Add stop as last command
        vm.Stop(loc++);
        //Generate functions/procedures
        foreach (string ident in info.ProcFuncs)
        {
            //Add calls, now that the function/procedure address is known
            if (info.Calls.ContainsKey(ident) && info.Calls[ident] != null)
            {
                foreach (int callLoc in info.Calls[ident])
                {
                    vm.Call(callLoc, loc); //loc is the address of the function/procedure
                }
            }
            //loc = info.ProcFuncs[ident].GenerateCode(loc, vm, info);
        }
        return loc;
    }
  }
}
