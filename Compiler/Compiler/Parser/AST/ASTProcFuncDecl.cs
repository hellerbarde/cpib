using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public partial class ASTProcFuncDecl : ASTCpsDecl
  {
    //public string Ident { get; set; }

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
      foreach (var a in Declarations) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[OptGlobImps]:", ind));
      foreach (var a in OptGlobImps) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Params]:", ind));
      foreach (var a in Params) {
        a.printAST(level + 1, sb);
      }
      sb.AppendLine(string.Format("{0}[Commands]:", ind));
      foreach (var a in Commands) {
        a.printAST(level + 1, sb);
      }
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}