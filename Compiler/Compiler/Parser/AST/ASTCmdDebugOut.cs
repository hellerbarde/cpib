using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTCmdDebugOut : ASTCpsCmd
  {
    public ASTExpression Expr { get; set; }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTCmdDebugOut()", ind));
      sb.AppendLine(string.Format("{0}[Expr]:", ind));
      Expr.printAST(level + 1, sb);
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      loc = Expr.GenerateCode(loc, vm, info);

      int Adress = 0;
      if (Expr.GetExpressionType(info).isArray){
        if (Expr is ASTIdent){
          String ident = ((ASTIdent)Expr).Ident;
          if (info.CurrentNamespace != null &&
              info.Namespaces.ContainsKey(info.CurrentNamespace) &&
              info.Namespaces[info.CurrentNamespace].ContainsIdent(ident)) {
            IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][ident];
            Adress = storage.Address;
            vm.IntLoad(loc++, 0);            
            vm.IntLoad(loc++, storage.Size()-1);
            vm.IntLoad(loc++, Adress);
            vm.ArrayAccess(loc++);
            vm.ArrayOutput(loc++, ident, storage.Size());
            return loc;
          }
          else if (info.Globals.ContainsIdent(ident)) {
            IASTStoDecl storage = info.Globals[ident];
            Adress = storage.Address;
            vm.IntLoad(loc++, 0);            
            vm.IntLoad(loc++, storage.Size()-1);
            vm.IntLoad(loc++, Adress);
            vm.ArrayAccess(loc++);
            vm.ArrayOutput(loc++, ident, storage.Size());
            return loc;
          }
          else {
            throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ident);
          }

        }
      }

      switch (Expr.GetExpressionType(info).Type) {
        case Type.INT32:
          vm.IntOutput(loc++, "DEBUGOUT");
          break;
        case Type.BOOL:
          vm.DecimalOutput(loc++, "DEBUGOUT");
          break;
        case Type.DECIMAL:
          vm.BoolOutput(loc++, "DEBUGOUT");
          break;
      }
      return loc;
    }
  }
}