using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
  public class ScopeChecker : Checker
  {
    private void ObtainNamespaceInformation(ASTProgram root, CheckerInformation info)
    {
      int globalAddress = 0;
      //Add global parameters
      foreach (ASTParam param in root.Params) {
        param.Address = globalAddress;
        globalAddress += param.Size();
        if (param.FlowMode == FlowMode.IN || param.FlowMode == FlowMode.INOUT){
          param.isInitialized = true;
        }
        info.Globals.addDeclaration(param);
      }
      //Add Global Variables, Functions and Procedures
      //And add local variables and parameters of the Function and Procedures
      foreach (ASTCpsDecl declaration in root.Declarations) {
        if (declaration is ASTStoDecl) {
          //Add global storage identifier
          declaration.Address = globalAddress;
          globalAddress += declaration.Size();
          info.Globals.addDeclaration((ASTStoDecl)declaration);
        }
        else if (declaration is ASTProcFuncDecl) {
          ASTProcFuncDecl procFunc = (ASTProcFuncDecl)declaration;
          //Add function or procedure identifier
          declaration.Address = -1;
          info.ProcFuncs.addDeclaration(procFunc);
          Namespace<IASTStoDecl> ns = new Namespace<IASTStoDecl>();
          info.Namespaces.Add(declaration.Ident, ns);
          //Relative address: The framepointer is one above the last parameter. Meaning the last parameter has the relative address -1 and the first -Params.Count
          int paramAddress = -procFunc.Params.Sum(x => x.Size());
          //Relative address: out copy, inout copy and local identifiers. Starting 3 addresses behind the frame pointer.
          int localAddress = 3;
          //Add local params of this function/procedure
          foreach (ASTParam localParam in procFunc.Params) {
            if (localParam.OptMechmode == MechMode.COPY && (localParam.FlowMode == FlowMode.OUT || localParam.FlowMode == FlowMode.INOUT)) {
              localParam.Address = localAddress;
              localParam.AddressLocation = paramAddress;
              localAddress += localParam.Size();
              paramAddress += localParam.Size();
            }
            else {
              localParam.Address = paramAddress;
              paramAddress += localParam.Size();
            }
            // if localparam ident is in the globals or local namespace then use its isInitialized value
            if (info.CurrentNamespace != null && info.Namespaces.ContainsKey(info.CurrentNamespace) &&
                info.Namespaces[info.CurrentNamespace].ContainsIdent(localParam.Ident)) {
              localParam.isInitialized = info.Namespaces[info.CurrentNamespace][localParam.Ident].isInitialized;
            }
            else if (info.Globals.ContainsIdent((localParam.Ident))) {
              localParam.isInitialized = info.Globals[localParam.Ident].isInitialized;   
            }
            else {
              throw new IVirtualMachine.InternalError("Access of undeclared Identifier " + localParam.Ident);
            }
            ns.addDeclaration(localParam);
          }
          //Add local storage identifier of this function/procedure
          foreach (ASTCpsDecl localDeclaration in ((ASTProcFuncDecl)declaration).Declarations) {
            if (localDeclaration is ASTStoDecl) {
              localDeclaration.Address = localAddress;
              localAddress += localDeclaration.Size();
              ns.addDeclaration((ASTStoDecl)localDeclaration);
            }
          }
        }
      }
    }

    private void CheckForUndeclaredIdent(ASTProgram root, CheckerInformation info)
    {

    }

    public void Check(ASTProgram root, CheckerInformation info)
    {
      //Fill namespaces with declaration identifiers
      //Throws an exception if an identifier is declared more then once in a namespace
      ObtainNamespaceInformation(root, info);
      //is any applied identifier declared?
      CheckForUndeclaredIdent(root, info);
    }
  }
}
