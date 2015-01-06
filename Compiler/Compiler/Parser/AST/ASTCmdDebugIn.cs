using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTCmdDebugIn : ASTCpsCmd
  {
    public ASTIdent Ident { get; set; }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdDebugIn()", ind));
      sb.AppendLine(string.Format("{0}[Expr]:", ind));
      Ident.printAST(level + 1, sb);
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Ident.GenerateLValue(loc, vm, info);
      IASTStoDecl storage;
      if (info.CurrentNamespace != null && info.Namespaces.ContainsKey(info.CurrentNamespace) &&
        info.Namespaces[info.CurrentNamespace].ContainsIdent(Ident.Ident)) {
        storage = info.Namespaces[info.CurrentNamespace][Ident.Ident];
      }
      else if (info.Globals.ContainsIdent((Ident.Ident))) {
        storage = info.Globals[Ident.Ident];
      }
      else {
        throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + Ident.Ident);
      }
      if (!Ident.IsInit && !storage.isInitialized) {
        throw new CheckerException("To write into uninitialized variable " + Ident.Ident + " an init is required"); 
      }
      else if (Ident.IsInit && storage.isInitialized) {
        throw new CheckerException("Variable " + Ident.Ident + " is being initialized again!");
      }
      else if (Ident.IsInit && !storage.isInitialized) {
        storage.isInitialized = true;
      } 
      if (Ident.GetExpressionType(info).isArray) {
        vm.ArrayInput(loc++, "DEBUGIN", Ident.GetExpressionType(info).dimensions[0], Ident.GetExpressionType(info).Type);
        return loc;
      }
      switch (Ident.GetExpressionType(info).Type) {
        case Type.INT32:
          vm.IntInput(loc++, "DEBUGIN");
          break;
        case Type.BOOL:
          vm.BoolInput(loc++, "DEBUGIN");
          break;
        case Type.DECIMAL:
          vm.DecimalInput(loc++, "DEBUGIN");
          break;
      }
      return loc;
    }
  }
}