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
      sb.AppendLine(string.Format("{0}[END] ASTProcFuncDecl(Ident: {1})", ind, Ident));
    }

    //TODO: Add additional code for function result
    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      int copies = 0;
      foreach (ASTParam param in Params)
      {
        if (param.OptMechmode == MechMode.COPY && (param.FlowMode == FlowMode.INOUT || param.FlowMode == FlowMode.OUT))
        {
          copies += param.Size();
        }
      }
      int decl_mem = 0;
      foreach (ASTCpsDecl decl in Declarations){
          decl_mem += decl.Size();
      }
      vm.Enter(loc++, copies + decl_mem, 0);
      //CopyIn of inout copy parameters
      foreach (ASTParam param in Params)
      {
        if (param.OptMechmode == MechMode.COPY && param.FlowMode == FlowMode.INOUT)
        {
          if (param.TypeOrArray.isArray) {
            for (int i = 0; i < param.TypeOrArray.dimensions[0]; i++) {
              vm.CopyIn(loc++, param.AddressLocation.Value+i, param.Address+i);
            }
          }
          else {
            vm.CopyIn(loc++, param.AddressLocation.Value, param.Address);
          }
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
          if (param.TypeOrArray.isArray) {
            for (int i = 0; i < param.TypeOrArray.dimensions[0]; i++) {
              vm.CopyOut(loc++, param.Address+i, param.AddressLocation.Value+i);
            }

          }
          else {
            vm.CopyOut(loc++, param.Address, param.AddressLocation.Value);
          }
        }
      }
      //Return
      vm.Return(loc++, Params.Count);
      return loc;
    }

    public override int Size()
    {
      int result = 0;
      foreach (ASTCpsDecl decl in Declarations){
        result += decl.Size();
      }
      foreach (ASTParam para in Params){
        result += para.Size();
      }
      return result;
    }
  }
}