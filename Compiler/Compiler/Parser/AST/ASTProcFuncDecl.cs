using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public class ASTProcFuncDecl : ASTCpsDecl
  {
    public List<ASTCpsDecl> Declarations { get; set; }

    public List<ASTGlobalParam> OptGlobImps { get; set; }

    public IList<ASTParam> Params { get; set; }

    public List<ASTCpsCmd> Commands { get; set; }

    public bool IsFunc { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1}", IsFunc ? "func" : "proc", Ident);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTProcFuncDecl(Ident: {1})", ind, Ident));
      sb.AppendLine(string.Format("{0}[Declarations]:", ind));
      foreach (var a in Declarations)
      {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[OptGlobImps]:", ind));
      foreach (var a in OptGlobImps)
      {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Params]:", ind));
      foreach (var a in Params)
      {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Commands]:", ind));
      foreach (var a in Commands)
      {
        a.printAST(level + 1, sb);
      }
    }

    //TODO: Add additional code for function result
    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      int copies = 0;
      foreach (ASTParam param in Params)
      {
        if (param.OptMechmode == MechMode.COPY && (param.FlowMode == FlowMode.INOUT || param.FlowMode == FlowMode.OUT))
        {
          ++copies;
        }
      }
      vm.Enter(loc++, copies + Declarations.Count, 0);
      //CopyIn of inout copy parameters
      foreach (ASTParam param in Params)
      {
        if (param.OptMechmode == MechMode.COPY && param.FlowMode == FlowMode.INOUT)
        {
          vm.CopyIn(loc++, param.AddressLocation.Value, param.Address);
        }
      }
      //Generate body
      foreach (ASTCpsCmd cmd in Commands)
      {
        loc = cmd.GenerateCode(loc, vm, info);
      }
      //CopyOut of inout copy and out copy parameters
      foreach (ASTParam param in Params)
      {
        if (param.OptMechmode == MechMode.COPY && (param.FlowMode == FlowMode.INOUT || param.FlowMode == FlowMode.OUT))
        {
          vm.CopyOut(loc++, param.Address, param.AddressLocation.Value);
        }
      }
      //Return
      vm.Return(loc++, Params.Count);
      return loc;
    }
  }
}