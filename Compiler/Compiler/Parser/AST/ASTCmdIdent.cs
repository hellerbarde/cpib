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
      if (RValue.GetExpressionType(info).isArray) {
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
        if (RValue is ASTArrayLiteral) {
          foreach (ASTExpression expr in ((ASTArrayLiteral)RValue).Value) {
            loc = expr.GenerateCode(loc, vm, info);
            vm.LoadRel(loc++, startAdress++.Value);
            vm.Store(loc++);
          }
        }
        else if (RValue is ASTArrayAccess) {
          String ident = ((ASTArrayAccess)RValue).Ident;
          if (info.CurrentNamespace != null &&
              info.Namespaces.ContainsKey(info.CurrentNamespace) &&
              info.Namespaces[info.CurrentNamespace].ContainsIdent(ident)) {
            IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][ident];   
            ((ASTArrayAccess)RValue).GenerateCode(loc++, vm, info);
            int accessSize = ((ASTArrayAccess)RValue).GetExpressionType(info).dimensions.Aggregate<int>((u, v) => u * v);
            for (int i = accessSize - 1; i >= 0; i--) {
              vm.IntLoad(loc++, storage.Address + i);
              vm.Deref(loc++);
              vm.LoadRel(loc++, startAdress.Value + i);
              vm.Store(loc++);
            }
            loc = LValue.GenerateLValue(loc, vm, info);
          }
          else if (info.Globals.ContainsIdent(ident)) {
            IASTStoDecl storage = info.Globals[ident];   
            ((ASTArrayAccess)RValue).GenerateCode(loc++, vm, info);
            int accessSize = ((ASTArrayAccess)RValue).GetExpressionType(info).dimensions.Aggregate<int>((u, v) => u * v);
            Console.WriteLine("Global array " + ident);
            Console.WriteLine(accessSize);
            Console.WriteLine(((ASTArrayAccess)RValue).GetExpressionType(info).ToString());
            Console.WriteLine(LValue.ToString());
            for (int i = accessSize - 1; i >= 0; i--) {
              vm.IntLoad(loc++, storage.Address + i);
              vm.Deref(loc++);
              vm.LoadRel(loc++, startAdress.Value + i);
              vm.Store(loc++);
            }
            loc = LValue.GenerateLValue(loc, vm, info);
          }
          else {
            throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ident);
          }
        }
        else if (RValue is ASTIdent) {
          String ident = ((ASTIdent)RValue).Ident;
          if (info.CurrentNamespace != null &&
            info.Namespaces.ContainsKey(info.CurrentNamespace) &&
            info.Namespaces[info.CurrentNamespace].ContainsIdent(ident)) {
            IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][ident];
            int Adress = storage.Address;       
            vm.IntLoad(loc++, storage.Size() - 1);            
            vm.IntLoad(loc++, 0);     
            vm.IntLoad(loc++, Adress);
            vm.ArrayAccess(loc++);
            for (int i = storage.Size() - 1; i >= 0; i--) {
              vm.LoadRel(loc++, startAdress.Value + i);
              vm.Store(loc++);
            }
            loc = LValue.GenerateLValue(loc, vm, info);
          }
          else if (info.Globals.ContainsIdent(ident)) {
            IASTStoDecl storage = info.Globals[ident];
            int Adress = storage.Address;          
            vm.IntLoad(loc++, storage.Size() - 1);
            vm.IntLoad(loc++, 0);  
            vm.IntLoad(loc++, Adress);
            vm.ArrayAccess(loc++);
            for (int i = storage.Size() -1; i >= 0; i--) {
              vm.LoadRel(loc++, startAdress.Value + i);
              vm.Store(loc++);
            }
            loc = LValue.GenerateLValue(loc, vm, info);
          }
          else {
            throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ident);
          }
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