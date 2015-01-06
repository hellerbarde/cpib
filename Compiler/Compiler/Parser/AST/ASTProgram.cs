using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Compiler
{
  public class ASTProgram : IASTNode
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
      int memory_required = 0;
      foreach (String s in info.Globals){
        memory_required += info.Globals[s].Size();
      }
      vm.Alloc(loc++, memory_required);
      //Load input params
      foreach (ASTParam param in Params) {
        if (param.FlowMode == FlowMode.IN || param.FlowMode == FlowMode.INOUT) {
          //Load address where to save the input
          vm.IntLoad(loc++, param.Address);
          //Switch between types:

          if (param.TypeOrArray.isArray) {
            vm.ArrayInput(loc++, param.Ident, param.TypeOrArray.dimensions[0], param.TypeOrArray.Type);
          }
          else{
            switch (param.TypeOrArray.Type) {
              case Type.INT32:
                vm.IntInput(loc++, param.Ident);
                break;
              case Type.BOOL:
                vm.BoolInput(loc++, param.Ident);
                break;
              case Type.DECIMAL:
                vm.DecimalInput(loc++, param.Ident);
                break;
            }
          }
        }
      }
      //Generate main code
      foreach (ASTCpsCmd cmd in Commands) {
        loc = cmd.GenerateCode(loc, vm, info);
      }
      //Add output code
      foreach (ASTParam param in Params) {
        if (param.FlowMode == FlowMode.OUT || param.FlowMode == FlowMode.INOUT) {

          //Switch between types, with arrays being a special case:
          if (param.TypeOrArray.isArray){
            vm.IntLoad(loc++, (param.Size() - 1));
            vm.IntLoad(loc++, 0);
            vm.IntLoad(loc++, param.Address);
            vm.ArrayAccess(loc++);
            vm.ArrayOutput(loc++, param.Ident, param.Size());
            continue;
          }
          //Load output value for non-arrays
          vm.IntLoad(loc++, param.Address);
          vm.Deref(loc++);
          switch (param.TypeOrArray.Type) {
            case Type.INT32:
              vm.IntOutput(loc++, param.Ident);
              break;
            case Type.BOOL:
              vm.BoolOutput(loc++, param.Ident);
              break;
            case Type.DECIMAL:
              vm.DecimalOutput(loc++, param.Ident);
              break;
          }
        }
      }
      //Add stop as last command
      vm.Stop(loc++);
      //Generate functions/procedures
      foreach (string ident in info.ProcFuncs) {
        ASTProcFuncDecl procFunc = info.ProcFuncs[ident];
        procFunc.Address = loc;
        //Add calls, now that the function/procedure address is known
        if (info.Calls.ContainsKey(ident) && info.Calls[ident] != null) {
          foreach (int callLoc in info.Calls[ident]) {
            vm.Call(callLoc, procFunc.Address);
          }
        }
        //Change current namespace
        info.CurrentNamespace = ident;
        //Generate code for function/procedure
        loc = procFunc.GenerateCode(loc, vm, info);
        //Reset namespace
        info.CurrentNamespace = null;
      }
      return loc;
    }
  }
}