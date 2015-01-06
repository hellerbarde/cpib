using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTArrayAccess : ASTIdent
  {
    public ASTArrayAccess()
    {
      Accessor = new List<ASTSliceExpr>();
    }
    //public string Ident { get; set; }
    public List<ASTSliceExpr> Accessor { get; set; }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      //TODO: Could also be a function call!
      loc = GenerateLValue(loc, vm, info);
      vm.ArrayAccess(loc++);
      return loc;
    }

    public override int GenerateLValue(int loc, IVirtualMachine vm, CheckerInformation info){
      ASTSliceExpr access = Accessor.First();
      if (access.End is ASTEmpty){
        vm.IntLoad(loc++, 0);
      } 
      else {
        loc = access.End.GenerateCode(loc, vm, info);
      }
      loc = access.Start.GenerateCode(loc, vm, info);
      if (info.CurrentNamespace != null &&
        info.Namespaces.ContainsKey(info.CurrentNamespace) &&
        info.Namespaces[info.CurrentNamespace].ContainsIdent(Ident)) {
        IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][Ident];        
        vm.IntLoad(loc++, storage.Address);
        //vm.IntAdd(loc++);
      }
      else if (info.Globals.ContainsIdent(Ident)) {
        IASTStoDecl storage = info.Globals[Ident];
        vm.IntLoad(loc++, storage.Address);
        //vm.IntAdd(loc++);
      }
      else {
        throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + Ident);
      }
      return loc;
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTArrayAccess(Ident: {1})", ind, Ident));
      sb.AppendLine(string.Format("{0}[Accessor]:", ind));
      foreach (var a in Accessor) {
        a.printAST(level + 1, sb);
      }
    }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
    {
      var type = new ASTTypeOrArray();
      if (info.CurrentNamespace != null) {
        type.Type = info.Namespaces[info.CurrentNamespace][Ident].TypeOrArray.Type;
      } else {
        type.Type = info.Globals[Ident].TypeOrArray.Type;
      }
      if (Accessor.First().End is ASTEmpty){
        type.dimensions.Add(1);
      }
      type.isArray = true;
      return type;
    }
  }
}

