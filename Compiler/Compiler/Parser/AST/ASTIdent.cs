using System;
using System.Text;
using System.Linq;

namespace Compiler
{
  public class ASTIdent : ASTExpression
  {
    public string Ident { get; set; }

    public IASTNode OptInitOrExprListOrArrayAccess { get; set; }

    public bool IsInit { get; set; }

    public bool IsArrayAccess {
      get;
      set;
    }

    public override string ToString()
    {
      return string.Format("{0}{1}", IsInit ? "init " : "", Ident);
    }

    public override void printAST(int level, StringBuilder sb)
    {
      string ind = String.Concat(Enumerable.Repeat(" ", level));

      sb.AppendLine(string.Format("{0}ASTIdent(Ident: {1} )[some missing things here, like array access and function params]", ind, Ident)); //TODO some missing stuff here
    }

    public override int GenerateLValue(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      //TODO: Could also be a function call! (Phil: not really... This is the LValue.)
      if (info.CurrentNamespace != null &&
          info.Namespaces.ContainsKey(info.CurrentNamespace) &&
          info.Namespaces[info.CurrentNamespace].ContainsIdent(Ident)) {
        IASTStoDecl storage = info.Namespaces[info.CurrentNamespace][Ident];
        if (storage is ASTStoDecl || (storage is ASTParam && ((ASTParam)storage).OptMechmode == MechMode.COPY)) {
          //Local Identifier or parameter with mechmode COPY

          if (this.IsArrayAccess) {
            ((ASTArrayAccess)this).Accessor[0].Start.GenerateCode(loc, vm, info);
            vm.LoadRel(loc++, storage.Address);
            vm.IntAdd(loc++);
          }
          else {
            vm.LoadRel(loc++, storage.Address);
          }
        }
        else if (storage is ASTParam) {
          //TODO: What should happen if OptMechmode == null?
          //Load parameter with mechmode REF
          if (this.IsArrayAccess) {
            ((ASTArrayAccess)this).Accessor[0].Start.GenerateCode(loc, vm, info);
            vm.LoadRel(loc++, storage.Address);
            vm.IntAdd(loc++);
            //vm.LoadRel(loc++, storage.Address); //Relative Address to fp
          }
          else {
            vm.LoadRel(loc++, storage.Address); //Relative Address to fp
          }
          vm.Deref(loc++); //Deref to get global Address
          //With another Deref the value is loaded
        }
        else {
          //Should never happen as long as no new type is added
          throw new IVirtualMachine.InternalError("Unknown Identifier Type");
        }
      }
      else if (info.Globals.ContainsIdent(Ident)) {
        IASTStoDecl storage = info.Globals[Ident];
        vm.IntLoad(loc++, storage.Address);
      }
      else {
        throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + Ident);
      }
      return loc;
    }

    public override int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      //TODO: Could also be a function call!
      loc = GenerateLValue(loc, vm, info);
      vm.Deref(loc++);
      return loc;
    }

    public override ASTTypeOrArray GetExpressionType(CheckerInformation info)
    {
      //TODO: Could also be a function call!
      if (info.CurrentNamespace != null &&
          info.Namespaces.ContainsKey(info.CurrentNamespace) &&
          info.Namespaces[info.CurrentNamespace].ContainsIdent(Ident)) {
        return info.Namespaces[info.CurrentNamespace].GetIdent(Ident).TypeOrArray;
      }

      if (info.Globals.ContainsIdent(Ident)) {

        return info.Globals.GetIdent(Ident).TypeOrArray;
      }

      throw new NotImplementedException();
    }
  }
}