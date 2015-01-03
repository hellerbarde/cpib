using System.Text;
using System;
using System.Linq;

namespace Compiler
{
  public class ASTCmdIdent : ASTCpsCmd
  {
    public ASTExpression LValue { get; set; }

    public ASTExpression RValue { get; set; }

    public override string ToString()
    {
      return string.Format("{0} := {1}", LValue, RValue);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdIdent()", ind));
      sb.AppendLine(string.Format("{0}[LValue]:", ind));
      LValue.printAST(level + 1, sb);
      sb.AppendLine(string.Format("{0}[RValue]:", ind));
      RValue.printAST(level + 1, sb);
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      if (RValue is ASTArrayLiteral) {
        int? startAdress = null;
        if (info.CurrentNamespace != null &&
          info.Namespaces.ContainsKey(info.CurrentNamespace) &&
          info.Namespaces[info.CurrentNamespace].ContainsIdent(((ASTIdent)LValue).Ident)) {
          IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][((ASTIdent)LValue).Ident];
          startAdress = storage.Address;
        }
        else if (info.Globals.ContainsIdent(((ASTIdent)LValue).Ident)) {
          IASTStoDecl storage = info.Globals[((ASTIdent)LValue).Ident];
          startAdress = storage.Address;
        }
        else {
          throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ((ASTIdent)LValue).Ident);
        }
        foreach (ASTExpression expr in ((ASTArrayLiteral)RValue).Value) {
          loc = expr.GenerateCode(loc, vm, info);
          vm.LoadRel(loc++, startAdress++.Value);
          vm.Store(loc++);
        }
      }
      else {
        loc = RValue.GenerateCode(loc, vm, info);
        loc = LValue.GenerateLValue(loc, vm, info);
        vm.Store(loc++);
      }
      return loc;
    }
  }
}