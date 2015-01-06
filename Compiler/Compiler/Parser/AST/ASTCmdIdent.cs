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
      IASTStoDecl lstorage;
      IASTStoDecl rstorage;
      if (info.CurrentNamespace != null && info.Namespaces.ContainsKey(info.CurrentNamespace) &&
        info.Namespaces[info.CurrentNamespace].ContainsIdent(((ASTIdent)LValue).Ident)) {
        
        // get the storage declaration if it's in the local namespace
        lstorage = info.Namespaces[info.CurrentNamespace][((ASTIdent)LValue).Ident];
        
      }
      else if (info.Globals.ContainsIdent(((ASTIdent)LValue).Ident)) {
        // get the storage declaration if it's in the Global namespace
        lstorage = info.Globals[((ASTIdent)LValue).Ident];
      }
      else {
        // If it's not in any namespaces, the IML source code is wrong.
        throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ((ASTIdent)LValue).Ident);
      }
      // Now we have the storage declaration and thus the startAddress

      if (RValue.GetExpressionType(info).isArray) {
        //int? startAdress = null;
        // if it's a literal, just write it in.
        if (RValue is ASTArrayLiteral) {
          int startAdress = lstorage.Address;
          foreach (ASTExpression expr in ((ASTArrayLiteral)RValue).Value) {
            loc = expr.GenerateCode(loc, vm, info);
            vm.LoadRel(loc++, startAdress++);
            vm.Store(loc++);

          }
          return loc;
        }

        // If it's an array access, we need to handle it differently
        if (RValue is ASTArrayAccess) {
          String ident = ((ASTArrayAccess)RValue).Ident;
          int accessSize;

          if (info.CurrentNamespace != null &&info.Namespaces.ContainsKey(info.CurrentNamespace) &&
                info.Namespaces[info.CurrentNamespace].ContainsIdent(ident)) {
            rstorage = info.Namespaces[info.CurrentNamespace][ident];   
            loc = RValue.GenerateCode(loc, vm, info);
            accessSize = ((ASTArrayAccess)RValue).GetExpressionType(info).dimensions.Aggregate<int>((u, v) => u * v);
          }
          else if (info.Globals.ContainsIdent(ident)) {
            rstorage = info.Globals[ident];   
            loc = RValue.GenerateCode(loc, vm, info);
            accessSize = ((ASTArrayAccess)RValue).GetExpressionType(info).dimensions.Aggregate<int>((u, v) => u * v);
          }
          else 
            throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + ident);

          //loc = RValue.GenerateCode(loc, vm, info);

          if (LValue is ASTArrayAccess) {
            vm.LoadRel(loc++, lstorage.Address);
            loc = (LValue as ASTArrayAccess).Accessor[0].Start.GenerateCode(loc, vm, info);
            vm.IntAdd(loc++);
          }
          else {
            //vm.LoadRel(loc++, lstorage.Address);
            loc = LValue.GenerateLValue(loc, vm, info);
          }
          //loc = ((ASTArrayAccess)LValue).Accessor[0].Start.GenerateCode(loc, vm, info);


          vm.Store(loc++);
//          for (int i = accessSize - 1; i >= 0; i--) {
//            vm.LoadRel(loc++, startAdress.Value + i);
//            vm.Store(loc++);
//          }
          return loc;
        }

        // TODO
      }
      else {
        loc = RValue.GenerateCode(loc, vm, info);
        if (LValue is ASTArrayAccess) {
          vm.LoadRel(loc++, lstorage.Address);
          loc = (LValue as ASTArrayAccess).Accessor[0].Start.GenerateCode(loc, vm, info);
          vm.IntAdd(loc++);
        }
        else {
          //vm.LoadRel(loc++, lstorage.Address);
          loc = LValue.GenerateLValue(loc, vm, info);
        }
        vm.Store(loc++);
      }
      return loc;
    }
  }
}