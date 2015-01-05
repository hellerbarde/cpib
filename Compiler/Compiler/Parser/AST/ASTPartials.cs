using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Compiler
{
  public partial class Tokennode : Treenode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ProgramPROGRAM : IProgram
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var program = new ASTProgram();

      program.Ident = ((IdentToken)this.IDENT.Token).Value;

      var currentParam = this.ProgParamList.ToAbstractSyntax();

      program.Params = new List<ASTParam>();

      while (!(currentParam is ASTEmpty)) {
        var astparam = (ASTParam)currentParam;
        program.Params.Add(astparam);
        currentParam = astparam.NextParam;
      }

      var currentDecl = this.OptCpsDecl.ToAbstractSyntax();
      program.Declarations = new List<ASTCpsDecl>();

      while (!(currentDecl is ASTEmpty)) {
        var cpsDecl = (ASTCpsDecl)currentDecl;
        program.Declarations.Add(cpsDecl);
        currentDecl = cpsDecl.NextDecl;
      }

      program.Commands = new List<ASTCpsCmd>();

      var currentCmd = this.CpsCmd.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        program.Commands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      return program;
    }
  }

  public partial class DeclCHANGEMODE : IDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.StoDecl.ToAbstractSyntax();
    }
  }

  public partial class DeclIDENT : IDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.StoDecl.ToAbstractSyntax();
    }
  }

  public partial class DeclFUN : IDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.FunDecl.ToAbstractSyntax();
    }
  }

  public partial class DeclPROC : IDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.ProcDecl.ToAbstractSyntax();
    }
  }

  public partial class StoDeclIDENT : IStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.TypedIdent.ToAbstractSyntax();
    }
  }

  public partial class StoDeclCHANGEMODE : IStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var decl = new ASTStoDecl();
      decl.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      decl.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();
      // DONE!
        
      decl.Changemode = ((ChangeModeToken)this.CHANGEMODE.Token).Value;

      return decl;
    }
  }


  public partial class FunDeclFUN : IFunDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var decl = new ASTProcFuncDecl();

      //add return param to param list as out param, so we can use the same class for funcs and procedures
      var returnParam = (ASTStoDecl)this.StoDecl.ToAbstractSyntax();

      var rootParam = new ASTParam();

      rootParam.OptChangemode = returnParam.Changemode;
      rootParam.Ident = returnParam.Ident;
      rootParam.TypeOrArray = returnParam.TypeOrArray;
      rootParam.FlowMode = FlowMode.OUT;

      rootParam.NextParam = this.ParamList.ToAbstractSyntax();

      decl.Params = new List<ASTParam>();
      IASTNode currentParam = rootParam;

      while (!(currentParam is ASTEmpty)) {
        var astparam = (ASTParam)currentParam;
        decl.Params.Add(astparam);
        currentParam = astparam.NextParam;
      }

      var currentDecl = this.OptCpsStoDecl.ToAbstractSyntax();
      decl.Declarations = new List<ASTCpsDecl>();

      while (!(currentDecl is ASTEmpty)) {
        var cpsDecl = (ASTCpsDecl)currentDecl;
        decl.Declarations.Add(cpsDecl);
        currentDecl = cpsDecl.NextDecl;
      }

      decl.Commands = new List<ASTCpsCmd>();

      var currentCmd = this.CpsCmd.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        decl.Commands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      decl.OptGlobImps = new List<ASTGlobalParam>();

      var currentGlob = this.OptGlobImps.ToAbstractSyntax();

      while (!(currentGlob is ASTEmpty)) {
        var glob = (ASTGlobalParam)currentGlob;
        decl.OptGlobImps.Add(glob);
        currentGlob = glob.NextParam;
      }

      decl.Ident = ((IdentToken)this.IDENT.Token).Value;
      decl.IsFunc = true;
      return decl;
    }
  }

  public partial class ProcDeclPROC : IProcDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var decl = new ASTProcFuncDecl();
      decl.Ident = ((IdentToken)this.IDENT.Token).Value;
      var currentDecl = this.OptCpsStoDecl.ToAbstractSyntax();
      decl.Declarations = new List<ASTCpsDecl>();

      while (!(currentDecl is ASTEmpty)) {
        var cpsDecl = (ASTCpsDecl)currentDecl;
        decl.Declarations.Add(cpsDecl);
        currentDecl = cpsDecl.NextDecl;
      }

      decl.Commands = new List<ASTCpsCmd>();

      var currentCmd = this.CpsCmd.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        decl.Commands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      decl.OptGlobImps = new List<ASTGlobalParam>();

      var currentGlob = this.OptGlobImps.ToAbstractSyntax();

      while (!(currentGlob is ASTEmpty)) {
        var glob = (ASTGlobalParam)currentGlob;
        decl.OptGlobImps.Add(glob);
        currentGlob = glob.NextParam;
      }

      decl.Params = new List<ASTParam>();
            
      IASTNode currentParam = this.ParamList.ToAbstractSyntax();

      while (!(currentParam is ASTEmpty)) {
        var astparam = (ASTParam)currentParam;
        decl.Params.Add(astparam);
        currentParam = astparam.NextParam;
      }

      decl.IsFunc = false;
      return decl;
    }
  }

  public partial class OptGlobImpsGLOBAL : IOptGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.GlobImps.ToAbstractSyntax();
    }
  }

  public partial class OptGlobImpsDO : IOptGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobImpsLOCAL : IOptGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class GlobImpsFLOWMODE : IGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTGlobalParam)this.GlobImp.ToAbstractSyntax();
      result.NextParam = this.RepGlobImps.ToAbstractSyntax();

      return result;
    }
  }

  public partial class GlobImpsIDENT : IGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTGlobalParam)this.GlobImp.ToAbstractSyntax();
      result.NextParam = this.RepGlobImps.ToAbstractSyntax();

      return result;
    }
  }

  public partial class GlobImpsCHANGEMODE : IGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTGlobalParam)this.GlobImp.ToAbstractSyntax();
      result.NextParam = this.RepGlobImps.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepGlobImpsCOMMA : IRepGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTGlobalParam)this.GlobImp.ToAbstractSyntax();
      result.NextParam = this.RepGlobImps.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepGlobImpsDO : IRepGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepGlobImpsLOCAL : IRepGlobImps
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptChangemodeCHANGEMODE : IOptChangemode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptChangemodeIDENT : IOptChangemode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptMechmodeMECHMODE : IOptMechmode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptMechmodeIDENT : IOptMechmode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptMechmodeCHANGEMODE : IOptMechmode
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class GlobImpIDENT : IGlobImp
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTGlobalParam();

      param.Ident = ((IdentToken)this.IDENT.Token).Value;
      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class GlobImpCHANGEMODE : IGlobImp
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTGlobalParam();

      param.Ident = ((IdentToken)this.IDENT.Token).Value;
      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class GlobImpFLOWMODE : IGlobImp
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTGlobalParam();

      param.Ident = ((IdentToken)this.IDENT.Token).Value;
      param.FlowMode = ((FlowModeToken)this.FLOWMODE.Token).Value;
      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class OptCpsDeclGLOBAL : IOptCpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.CpsDecl.ToAbstractSyntax();
    }
  }

  public partial class OptCpsDeclDO : IOptCpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class CpsDeclPROC : ICpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepCpsDecl.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var decl = (ASTCpsDecl)this.Decl.ToAbstractSyntax();

        decl.NextDecl = rep;

        return decl;
      }

      return this.Decl.ToAbstractSyntax();
    }
  }

  public partial class CpsDeclFUN : ICpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepCpsDecl.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var decl = (ASTCpsDecl)this.Decl.ToAbstractSyntax();

        decl.NextDecl = rep;

        return decl;
      }

      return this.Decl.ToAbstractSyntax();
    }
  }

  public partial class CpsDeclCHANGEMODE : ICpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepCpsDecl.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var decl = (ASTCpsDecl)this.Decl.ToAbstractSyntax();

        decl.NextDecl = rep;

        return decl;
      }

      return this.Decl.ToAbstractSyntax();
    }
  }

  public partial class CpsDeclIDENT : ICpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepCpsDecl.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var decl = (ASTCpsDecl)this.Decl.ToAbstractSyntax();

        decl.NextDecl = rep;

        return decl;
      }

      return this.Decl.ToAbstractSyntax();
    }
  }

  public partial class RepCpsDeclSEMICOLON : IRepCpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepCpsDecl.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var decl = (ASTCpsDecl)this.Decl.ToAbstractSyntax();

        decl.NextDecl = rep;

        return decl;
      }

      return this.Decl.ToAbstractSyntax();
    }
  }

  public partial class RepCpsDeclDO : IRepCpsDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptCpsStoDeclLOCAL : IOptCpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.CpsStoDecl.ToAbstractSyntax();
    }
  }

  public partial class OptCpsStoDeclDO : IOptCpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class CpsStoDeclCHANGEMODE : ICpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTStoDecl)this.StoDecl.ToAbstractSyntax();
      result.NextDecl = this.RepCpsStoDecl.ToAbstractSyntax();

      return result;
    }
  }

  public partial class CpsStoDeclIDENT : ICpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTStoDecl)this.StoDecl.ToAbstractSyntax();
      result.NextDecl = this.RepCpsStoDecl.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepCpsStoDeclSEMICOLON : IRepCpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTStoDecl)this.StoDecl.ToAbstractSyntax();
      result.NextDecl = this.RepCpsStoDecl.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepCpsStoDeclDO : IRepCpsStoDecl
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ProgParamListLPAREN : IProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      if (this.OptProgParamList == null) {
        return new ASTEmpty();
      }

      return this.OptProgParamList.ToAbstractSyntax();
    }
  }

  public partial class OptProgParamListFLOWMODE : IOptProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.ProgParam.ToAbstractSyntax();
      result.NextParam = this.RepProgParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptProgParamListIDENT : IOptProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.ProgParam.ToAbstractSyntax();
      result.NextParam = this.RepProgParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptProgParamListCHANGEMODE : IOptProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.ProgParam.ToAbstractSyntax();
      result.NextParam = this.RepProgParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptProgParamListRPAREN : IOptProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepProgParamListCOMMA : IRepProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.ProgParam.ToAbstractSyntax();
      result.NextParam = this.RepProgParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepProgParamListRPAREN : IRepProgParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ProgParamIDENT : IProgParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();
      // DONE!
      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ProgParamCHANGEMODE : IProgParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ProgParamFLOWMODE : IProgParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      param.FlowMode = ((FlowModeToken)this.FLOWMODE.Token).Value;
      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ParamListLPAREN : IParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      if (this.OptParamList == null) {
        return new ASTEmpty();
      }

      return this.OptParamList.ToAbstractSyntax();
    }
  }

  public partial class OptParamListFLOWMODE : IOptParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.Param.ToAbstractSyntax();
      result.NextParam = this.RepParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptParamListIDENT : IOptParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.Param.ToAbstractSyntax();
      result.NextParam = this.RepParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptParamListCHANGEMODE : IOptParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.Param.ToAbstractSyntax();
      result.NextParam = this.RepParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptParamListMECHMODE : IOptParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.Param.ToAbstractSyntax();
      result.NextParam = this.RepParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class OptParamListRPAREN : IOptParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepParamListCOMMA : IRepParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var result = (ASTParam)this.Param.ToAbstractSyntax();
      result.NextParam = this.RepParamList.ToAbstractSyntax();

      return result;
    }
  }

  public partial class RepParamListRPAREN : IRepParamList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ParamIDENT : IParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      if (this.OptMechmode is OptMechmodeMECHMODE) {
        param.OptMechmode =
                    ((MechModeToken)((OptMechmodeMECHMODE)this.OptMechmode).MECHMODE.Token).Value;
      }

      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ParamCHANGEMODE : IParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      if (this.OptMechmode is OptMechmodeMECHMODE) {
        param.OptMechmode =
                    ((MechModeToken)((OptMechmodeMECHMODE)this.OptMechmode).MECHMODE.Token).Value;
      }

      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ParamMECHMODE : IParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      if (this.OptMechmode is OptMechmodeMECHMODE) {
        param.OptMechmode =
                    ((MechModeToken)((OptMechmodeMECHMODE)this.OptMechmode).MECHMODE.Token).Value;
      }

      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class ParamFLOWMODE : IParam
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var param = new ASTParam();
      param.Ident = ((IdentToken)((TypedIdentIDENT)this.TypedIdent).IDENT.Token).Value;
      param.TypeOrArray = (ASTTypeOrArray)((TypedIdentIDENT)TypedIdent).TypeOrArray.ToAbstractSyntax();

      param.FlowMode = ((FlowModeToken)this.FLOWMODE.Token).Value;

      if (this.OptMechmode is OptMechmodeMECHMODE) {
        param.OptMechmode =
                    ((MechModeToken)((OptMechmodeMECHMODE)this.OptMechmode).MECHMODE.Token).Value;
      }

      if (this.OptChangemode is OptChangemodeCHANGEMODE) {
        param.OptChangemode =
                    ((ChangeModeToken)((OptChangemodeCHANGEMODE)this.OptChangemode).CHANGEMODE.Token).Value;
      }

      return param;
    }
  }

  public partial class TypedIdentIDENT : ITypedIdent
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ast = new ASTStoDecl();
      ast.Ident = ((IdentToken)IDENT.Token).Value;
      ast.TypeOrArray = (ASTTypeOrArray)this.TypeOrArray.ToAbstractSyntax();
      //ast.Changemode = ChangeMode.VAR; //TO DO: Is this correct?
      return ast;
    }
  }

  public partial class CmdSKIP : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTCmdSkip();
    }
  }

  public partial class CmdTYPE : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdLPAREN : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdADDOPR : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdNOT : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdIDENT : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdLITERAL : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdIdent();
      ident.LValue = (ASTExpression)this.Expr.ToAbstractSyntax();
      ident.RValue = (ASTExpression)this.Expr2.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdIF : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ifCmd = new ASTIf();

      ifCmd.Condition = this.Expr.ToAbstractSyntax();

      ifCmd.TrueCommands = new List<ASTCpsCmd>();

      var currentCmd = this.CpsCmd.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        ifCmd.TrueCommands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      ifCmd.FalseCommands = new List<ASTCpsCmd>();

      currentCmd = this.CpsCmd2.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        ifCmd.FalseCommands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      return ifCmd;
    }
  }

  public partial class CmdWHILE : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var whileCmd = new ASTWhile();

      whileCmd.Condition = this.Expr.ToAbstractSyntax();

      whileCmd.Commands = new List<ASTCpsCmd>();

      var currentCmd = this.CpsCmd.ToAbstractSyntax();

      while (!(currentCmd is ASTEmpty)) {
        var cpsCmd = (ASTCpsCmd)currentCmd;
        whileCmd.Commands.Add(cpsCmd);
        currentCmd = cpsCmd.NextCmd;
      }

      return whileCmd;
    }
  }

  public partial class CmdCALL : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var call = new ASTCmdCall();
      call.Ident = ((IdentToken)this.IDENT.Token).Value;

      call.ExprList = new List<ASTExpression>();
      var currentExpr = this.ExprList.ToAbstractSyntax();
      while (!(currentExpr is ASTEmpty)) {
        var expr = (ASTExpression)currentExpr;
        call.ExprList.Add(expr);
        currentExpr = expr.NextExpression;
      }
      call.OptGlobInits = this.OptGlobInits.ToAbstractSyntax();

      return call;
    }
  }

  public partial class CmdDEBUGIN : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdDebugIn();
      ident.Expr = (ASTExpression)this.Expr.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CmdDEBUGOUT : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTCmdDebugOut();
      ident.Expr = (ASTExpression)this.Expr.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class CpsCmdDEBUGOUT : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdDEBUGIN : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdCALL : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdWHILE : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdIF : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdTYPE : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdLPAREN : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdADDOPR : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdNOT : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdIDENT : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdLITERAL : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class CpsCmdSKIP : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class RepCpsCmdSEMICOLON : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class RepCpsCmdENDWHILE : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepCpsCmdENDIF : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepCpsCmdELSE : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepCpsCmdENDPROC : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepCpsCmdENDFUN : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepCpsCmdENDPROGRAM : IRepCpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsINIT : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.RepIdents.ToAbstractSyntax();
    }
  }

  public partial class OptGlobInitsENDWHILE : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsENDIF : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsELSE : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsENDPROC : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsENDFUN : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsENDPROGRAM : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptGlobInitsSEMICOLON : IOptGlobInits
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsCOMMA : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var optinit = new ASTOptInit();
      optinit.Ident = ((IdentToken)this.IDENT.Token).Value;
      optinit.NextInit = this.RepIdents.ToAbstractSyntax();
      return optinit;
    }
  }

  public partial class RepIdentsENDWHILE : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsENDIF : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsELSE : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsENDPROC : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsENDFUN : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsENDPROGRAM : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepIdentsSEMICOLON : IRepIdents
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ExprTYPE : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        ident.RepTerm = rep;
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class ExprLPAREN : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class ExprADDOPR : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class ExprNOT : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class ExprIDENT : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.SetLeftChild(this.Term1.ToAbstractSyntax());
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class ExprLITERAL : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        ident.RepTerm = rep;
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class RepTerm1BOOLOPR : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var relop = new ASTBoolOpr();
      relop.Operator = ((OperatorToken)this.BOOLOPR.Token).Value;
      relop.Term = this.Term1.ToAbstractSyntax();
      relop.RepTerm = this.RepTerm1.ToAbstractSyntax();

      //To rebalance the tree correctly, switch left and right nodes if right node is empty
      if (relop.RepTerm is ASTEmpty) {
        relop.RepTerm = relop.Term;
        relop.Term = new ASTEmpty();
      }
      else if (relop.RepTerm is ASTBoolOpr) {
        var tmp = (ASTBoolOpr)relop.RepTerm;

        if ((relop.Operator == Operators.AND || relop.Operator == Operators.CAND) && (tmp.Operator == Operators.OR || tmp.Operator == Operators.COR)) {
          relop.RepTerm = relop.Term;
          relop.Term = new ASTEmpty();
          tmp.Term = relop;
          relop = tmp;
        }
        else {
          tmp.SetLeftChild(relop.Term);
          relop.Term = new ASTEmpty();
        }
      }

      return relop;
    }
  }

  public partial class RepTerm1COMMA : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1RPAREN : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1DO : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1THEN : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ENDWHILE : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ENDIF : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ELSE : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ENDPROC : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ENDFUN : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1ENDPROGRAM : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();//return EndProgram node?
    }
  }

  public partial class RepTerm1SEMICOLON : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1BECOMES : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class Term1TYPE : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term1LPAREN : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term1ADDOPR : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term1NOT : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term1IDENT : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term1LITERAL : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm2.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var relOpr = (ASTRelOpr)rep;

        relOpr.Term = this.Term2.ToAbstractSyntax();
        return relOpr;
      }

      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class RepTerm2RELOPR : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
            

      var relop = new ASTRelOpr();
      relop.Operator = ((OperatorToken)this.RELOPR.Token).Value;
      relop.RepTerm = this.Term2.ToAbstractSyntax();

      var term = this.RepTerm2.ToAbstractSyntax();
      if (!(term is ASTEmpty)) {
        relop.Term = term;
        throw new GrammarException(
          string.Format(
            "Row: {0}, Col: {1}: IImplicit chaining of relative Operators is not allowed (E.G. true = 3 = 3, use brackets in this case: Itrue = (3 = 3) )",
            this.RELOPR.Token.Row,
            this.RELOPR.Token.Column));
      }

      return relop;
    }
  }

  public partial class RepTerm2COMMA : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2RPAREN : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2DO : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2THEN : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ENDWHILE : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ENDIF : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ELSE : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ENDPROC : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ENDFUN : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2ENDPROGRAM : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2SEMICOLON : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2BECOMES : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2BOOLOPR : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class Term2TYPE : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term2 = (ASTAddOpr)rep;
        term2.Term = this.Term3.ToAbstractSyntax();
        return term2;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term2LPAREN : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTAddOpr)rep;
        term3.SetLeftChild(this.Term3.ToAbstractSyntax());
        return term3;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term2ADDOPR : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTAddOpr)rep;
        term3.SetLeftChild(this.Term3.ToAbstractSyntax());
        return term3;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term2NOT : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTAddOpr)rep;
        term3.SetLeftChild(this.Term3.ToAbstractSyntax());
        return term3;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term2IDENT : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTAddOpr)rep;
        term3.SetLeftChild(this.Term3.ToAbstractSyntax());
        return term3;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term2LITERAL : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm3.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTAddOpr)rep;
        term3.SetLeftChild(this.Term3.ToAbstractSyntax());
        return term3;
      }

      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class RepTerm3ADDOPR : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var fac = this.Term3.ToAbstractSyntax();
      var rep = this.RepTerm3.ToAbstractSyntax();

      var addOpr = new ASTAddOpr();
      addOpr.Operator = ((OperatorToken)this.ADDOPR.Token).Value;

      if (!(rep is ASTEmpty)) {
        var parent = (ASTAddOpr)rep;
        addOpr.RepTerm = fac;
        parent.SetLeftChild(addOpr);
        return parent;
      }

      addOpr.RepTerm = this.Term3.ToAbstractSyntax();

      return addOpr;
    }
  }

  public partial class RepTerm3COMMA : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3RPAREN : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3DO : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3THEN : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ENDWHILE : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ENDIF : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ELSE : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ENDPROC : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ENDFUN : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3ENDPROGRAM : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3SEMICOLON : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3BECOMES : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3BOOLOPR : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3RELOPR : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class Term3TYPE : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class Term3LPAREN : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class Term3ADDOPR : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class Term3NOT : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class Term3IDENT : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class Term3LITERAL : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepFactor.ToAbstractSyntax();

      if (!(rep is ASTEmpty)) {
        var term3 = (ASTMultOpr)rep;
        term3.SetLeftChild(this.Factor.ToAbstractSyntax());
        return term3;
      }

      return this.Factor.ToAbstractSyntax();
    }
  }

  public partial class RepFactorMULTOPR : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var fac = this.Factor.ToAbstractSyntax();
      var rep = this.RepFactor.ToAbstractSyntax();

      var multOpr = new ASTMultOpr();
      multOpr.Operator = ((OperatorToken)this.MULTOPR.Token).Value;

      if (!(rep is ASTEmpty)) {
        var parent = (ASTMultOpr)rep;
        multOpr.RepFactor = fac;
        parent.SetLeftChild(multOpr);
        return parent;
      }

      multOpr.RepFactor = this.Factor.ToAbstractSyntax();

      return multOpr;
    }
  }

  public partial class RepFactorCOMMA : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorRPAREN : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorDO : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorTHEN : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorENDWHILE : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorENDIF : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorELSE : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorENDPROC : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorENDFUN : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorENDPROGRAM : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorSEMICOLON : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorBECOMES : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorBOOLOPR : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorRELOPR : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorADDOPR : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class FactorLITERAL : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      if (this.LITERAL.Token is DecimalLiteralToken) {
        return new ASTDecimalLiteral(((DecimalLiteralToken)this.LITERAL.Token).Value);
      }
            
      if (this.LITERAL.Token is BoolLiteralToken) {
        return new ASTBoolLiteral(((BoolLiteralToken)this.LITERAL.Token).Value);
      }
            
      if (this.LITERAL.Token is IntLiteralToken) {
        return new ASTIntLiteral(((IntLiteralToken)this.LITERAL.Token).Value);
      }

      throw new NotImplementedException();
    }
  }

  public partial class FactorIDENT : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTIdent();
      ident.Ident = ((IdentToken)this.IDENT.Token).Value;

      if (this.OptInitOrExprListOrArrayAccess is OptInitOrExprListOrArrayAccessINIT) {
        ident.IsArrayAccess = false;
        ident.IsInit = true;
        ident.OptInitOrExprListOrArrayAccess = new ASTEmpty();
      }
      if (this.OptInitOrExprListOrArrayAccess is OptInitOrExprListOrArrayAccessLBRACKET) {
        var returnvalue = new ASTArrayAccess();
        returnvalue.Ident = ident.Ident;
        returnvalue.IsArrayAccess = true;

        var arrayaccessor = this.OptInitOrExprListOrArrayAccess.ToAbstractSyntax();
        while (!(arrayaccessor is ASTEmpty)) {
          returnvalue.Accessor.Add((ASTSliceExpr)arrayaccessor);
          arrayaccessor = ((ASTSliceExpr)arrayaccessor).NextExpression;
        }

        return returnvalue;
      }
      if (this.OptInitOrExprListOrArrayAccess is OptInitOrExprListOrArrayAccessLPAREN) {
        ident.IsArrayAccess = false;
        ident.IsInit = false;
        ident.OptInitOrExprListOrArrayAccess = this.OptInitOrExprListOrArrayAccess.ToAbstractSyntax();
      }
      return ident;
    }
  }

  public partial class FactorADDOPR : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var lit = this.Factor.ToAbstractSyntax();

      if (MonadicOpr is MonadicOprADDOPR) {
        var opr = ((OperatorToken)((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token).Value;

        if (opr == Operators.MINUS) {
          if (lit is ASTIntLiteral) {
            ((ASTIntLiteral)lit).Value *= -1;
          }
          else if (lit is ASTDecimalLiteral) {
            ((ASTDecimalLiteral)lit).Value *= -1;
          }
          else {
            var not = new ASTNot();
            not.Expr = (ASTExpression)lit;

            lit = not;
          }
        }
      }
      else if (MonadicOpr is MonadicOprNOT) {
        var not = new ASTNot();
        not.Expr = (ASTExpression)lit;

        lit = not;
      }
      else {
        throw new GrammarException(
          string.Format("Row: {0}, Col: {1}: Can't find relevant MonadicOperator",
            ((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token.Row,
            ((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token.Column));
      }

      return lit;
    }
  }

  public partial class FactorNOT : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var lit = this.Factor.ToAbstractSyntax();

      if (MonadicOpr is MonadicOprADDOPR) {
        var opr = ((OperatorToken)((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token).Value;

        if (opr == Operators.MINUS) {
          if (lit is ASTIntLiteral) {
            ((ASTIntLiteral)lit).Value *= -1;
          }
          else if (lit is ASTDecimalLiteral) {
            ((ASTDecimalLiteral)lit).Value *= -1;
          }
          else {
            var not = new ASTNot();
            not.Expr = (ASTExpression)lit;

            lit = not;
          }
        }
      }
      else if (MonadicOpr is MonadicOprNOT) {
        var not = new ASTNot();
        not.Expr = (ASTExpression)lit;

        lit = not;
      }
      else {
        throw new GrammarException(
          string.Format("Row: {0}, Col: {1}: Can't find relevant MonadicOperator",
            ((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token.Row,
            ((MonadicOprADDOPR)MonadicOpr).ADDOPR.Token.Column));
      }

      return lit;
    }
  }

  public partial class FactorLPAREN : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class FactorTYPE : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var ident = new ASTType();
      ident.Type = ((TypeToken)this.TYPE.Token).Value;
      ident.Expr = (ASTExpression)this.Expr.ToAbstractSyntax();
      return ident;
    }
  }

  public partial class OptInitOrExprListOrArrayAccessINIT : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessLPAREN : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.ExprList.ToAbstractSyntax();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessCOMMA : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessRPAREN : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessDO : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessTHEN : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessENDWHILE : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessENDIF : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessELSE : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessENDPROC : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessENDFUN : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessENDPROGRAM : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessSEMICOLON : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessBECOMES : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessBOOLOPR : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessRELOPR : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessADDOPR : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessMULTOPR : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class MonadicOprNOT : IMonadicOpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class MonadicOprADDOPR : IMonadicOpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ExprListLPAREN : IExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.OptExprList.ToAbstractSyntax();
    }
  }

  public partial class OptExprListTYPE : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListLPAREN : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListADDOPR : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListNOT : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListIDENT : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListLITERAL : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptExprListRPAREN : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepExprListCOMMA : IRepExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;
        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class RepExprListRPAREN : IRepExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class ArrayContentLBRACKET : IArrayContent
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // starting with an lbracket, means we have another array literal.

      var returnvalue = new ASTArrayLiteral();

      var rep = this.RepArray.ToAbstractSyntax();

      if (rep is ASTEmpty) {
        // there is only one array literal in this array literal. so meta. wow
        returnvalue.Value.Add((ASTExpression)this.ArrayLiteral.ToAbstractSyntax());
        return returnvalue;
      }
      else {
        // there are many array literals
        returnvalue.Value.Add((ASTExpression)this.ArrayLiteral.ToAbstractSyntax());
        var foo = rep;
        while (!(foo is ASTEmpty)) {
          returnvalue.Value.Add((ASTExpression)foo);
          foo = ((ASTExpression)foo).NextExpression;
        }
        return returnvalue;
      }
      /*node.NextExpression = 
      this.ArrayLiteral;
      this.RepArray;

      return new ASTArrayLiteral();*/

    }
  }

  public partial class ArrayContentLITERAL : IArrayContent
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // we are inside an array literal with ints or bools

      var returnvalue = new ASTArrayLiteral();

      var rep = this.RepLiteral.ToAbstractSyntax();
      ASTExpression lit;
      if (rep is ASTEmpty) {
        // there is only one literal in this array literal.
        if (this.LITERAL.Token is BoolLiteralToken) {
          lit = new ASTBoolLiteral(((BoolLiteralToken)this.LITERAL.Token).Value);
        }
        else if (this.LITERAL.Token is IntLiteralToken) {
          lit = new ASTIntLiteral(((IntLiteralToken)this.LITERAL.Token).Value);
        }
        else {
          throw new ContextException("Types other than int32 and bool are not supported");
        }
        returnvalue.Value.Add(lit);
        return returnvalue;
      }
      else {
        // there are many literals in the array (the usual case)
        if (this.LITERAL.Token is BoolLiteralToken) {
          lit = new ASTBoolLiteral(((BoolLiteralToken)this.LITERAL.Token).Value);
        }
        else if (this.LITERAL.Token is IntLiteralToken) {
          lit = new ASTIntLiteral(((IntLiteralToken)this.LITERAL.Token).Value);
        }
        else {
          throw new ContextException("Types other than int32 and bool are not supported");
        }
        returnvalue.Value.Add(lit);
        while (!(rep is ASTEmpty)) {
          returnvalue.Value.Add((ASTExpression)rep);
          rep = ((ASTExpression)rep).NextExpression;
        }
        return returnvalue;
      }
    }
  }

  public partial class ArrayIndexLBRACKET : IArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepArrayIndex.ToAbstractSyntax();

      if (rep is ASTEmpty) {
        return this.SliceExpr.ToAbstractSyntax();
      }
      else {
        var sliceexpr = (ASTSliceExpr)this.SliceExpr.ToAbstractSyntax();
        sliceexpr.NextExpression = rep;

        return sliceexpr;
      }
    }
  }



  public partial class ArrayLiteralLBRACKET : IArrayLiteral
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.ArrayContent.ToAbstractSyntax();
    }
  }

  public partial class CmdLBRACKET : ICmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      throw new ContextException("Assigning to an Array Literal is invalid");
    }
  }

  public partial class CpsCmdLBRACKET : ICpsCmd
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var cmd = (ASTCpsCmd)this.Cmd.ToAbstractSyntax();
      cmd.NextCmd = this.RepCpsCmd.ToAbstractSyntax();
      return cmd;
    }
  }

  public partial class ExprLBRACKET : IExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepTerm1.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var ident = (ASTBoolOpr)rep;
        ident.Term = this.Term1.ToAbstractSyntax();
        return ident;
      }

      return this.Term1.ToAbstractSyntax();
    }
  }

  public partial class FactorLBRACKET : IFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return (ASTExpression)this.ArrayLiteral.ToAbstractSyntax();
    }
  }

  public partial class OptExprListLBRACKET : IOptExprList
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepExprList.ToAbstractSyntax();
      if (!(rep is ASTEmpty)) {
        var expr = (ASTExpression)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;

        return expr;
      }

      return this.Expr.ToAbstractSyntax();
    }
  }

  public partial class OptFillADDOPR : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillFILL : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillIDENT : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillLBRACKET : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillLITERAL : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillLPAREN : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillNOT : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptFillTYPE : IOptFill
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessLBRACKET : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.ArrayIndex.ToAbstractSyntax();

    }
  }

  public partial class OptInitOrExprListOrArrayAccessRANGE : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class OptInitOrExprListOrArrayAccessRBRACKET : IOptInitOrExprListOrArrayAccess
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayCOMMA : IRepArray
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepArray.ToAbstractSyntax();

      if (rep is ASTEmpty) {
        return this.ArrayLiteral.ToAbstractSyntax();
      }
      else {
        var lit = (ASTExpression)this.ArrayLiteral.ToAbstractSyntax();
        lit.NextExpression = rep;
        return lit;
      }
    }
  }

  public partial class RepArrayIndexADDOPR : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexBECOMES : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexBOOLOPR : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexCOMMA : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexDO : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexELSE : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexENDFUN : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexENDIF : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexENDPROC : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexENDPROGRAM : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexENDWHILE : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexLBRACKET : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return this.ArrayIndex.ToAbstractSyntax();
    }
  }

  public partial class RepArrayIndexMULTOPR : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexRANGE : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexRBRACKET : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexRELOPR : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexRPAREN : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexSEMICOLON : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayIndexTHEN : IRepArrayIndex
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayLengthCOMMA : IRepArrayLength
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepArrayLength.ToAbstractSyntax();

      if (rep is ASTEmpty) {
        return (ASTIntLiteral)this.Expr.ToAbstractSyntax();
      }
      else {
        var expr = (ASTIntLiteral)this.Expr.ToAbstractSyntax();
        expr.NextExpression = rep;
        return (ASTIntLiteral)expr;
      }
    }
  }

  public partial class RepArrayLengthRPAREN : IRepArrayLength
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepArrayRBRACKET : IRepArray
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorRANGE : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepFactorRBRACKET : IRepFactor
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepLiteralCOMMA : IRepLiteral
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var rep = this.RepLiteral.ToAbstractSyntax();

      if (rep is ASTEmpty) {
        if (this.LITERAL.Token is BoolLiteralToken) {
          return new ASTBoolLiteral(((BoolLiteralToken)this.LITERAL.Token).Value);
        }
        else if (this.LITERAL.Token is IntLiteralToken) {
          return new ASTIntLiteral(((IntLiteralToken)this.LITERAL.Token).Value);
        }
        else {
          throw new ContextException("Types other than int32 and bool are not supported");
        }
      }
      else {
        ASTExpression expr;// = new ASTIntLiteral(((IntLiteralToken)LITERAL.Token).Value);
        if (this.LITERAL.Token is BoolLiteralToken) {
          expr = new ASTBoolLiteral(((BoolLiteralToken)this.LITERAL.Token).Value);
        }
        else if (this.LITERAL.Token is IntLiteralToken) {
          expr = new ASTIntLiteral(((IntLiteralToken)this.LITERAL.Token).Value);
        }
        else {
          throw new ContextException("Types other than int32 and bool are not supported");
        }
        expr.NextExpression = rep;
        return expr;
      }
    }
  }

  public partial class RepLiteralRBRACKET : IRepLiteral
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepSliceExprRANGE : IRepSliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // this means there is a slice
      var slice = new ASTSliceExpr();
      slice.End = (ASTExpression)this.Expr.ToAbstractSyntax();
      return slice;
    }
  }

  public partial class RepSliceExprRBRACKET : IRepSliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // this means there is no slice, only an index
      var index = new ASTSliceExpr();
      index.End = new ASTEmpty();
      return index;
    }
  }

  public partial class SliceExprADDOPR : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var slice = (ASTSliceExpr)this.RepSliceExpr.ToAbstractSyntax();
      slice.Start = this.Expr.ToAbstractSyntax();
      return slice;
    }
  }

  public partial class SliceExprIDENT : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var slice = (ASTSliceExpr)this.RepSliceExpr.ToAbstractSyntax();
      slice.Start = this.Expr.ToAbstractSyntax();
      return slice;
    }
  }

  public partial class SliceExprLBRACKET : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      throw new ContextException("No nested arrayliterals allowed in a slice expression");
    }
  }

  public partial class SliceExprLITERAL : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var slice = (ASTSliceExpr)this.RepSliceExpr.ToAbstractSyntax();
      slice.Start = this.Expr.ToAbstractSyntax();
      return slice;
    }
  }

  public partial class SliceExprLPAREN : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var slice = (ASTSliceExpr)this.RepSliceExpr.ToAbstractSyntax();
      slice.Start = this.Expr.ToAbstractSyntax();
      return slice;
    }
  }

  public partial class SliceExprNOT : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      throw new ContextException("No Bools allowed in a slice expression");
    }
  }

  public partial class SliceExprTYPE : ISliceExpr
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      throw new ContextException("No TYPE allowed in a slice expression");
    }
  }

  public partial class TypeOrArrayARRAY : ITypeOrArray
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var type = new ASTTypeOrArray();
      type.isArray = true;
      type.Type = ((TypeToken)TYPE.Token).Value;

      type.dimensions.Add(((ASTIntLiteral)((ExprLITERAL)Expr).ToAbstractSyntax()).Value);
      var rep = this.RepArrayLength.ToAbstractSyntax();
      while (!(rep is ASTEmpty)) {
        type.dimensions.Add(((ASTIntLiteral)rep).Value);
        rep = ((ASTIntLiteral)rep).NextExpression;
      }

      return type;
    }
  }

  public partial class TypeOrArrayTYPE : ITypeOrArray
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      var type = new ASTTypeOrArray();
      type.isArray = false;
      type.Type = ((TypeToken)TYPE.Token).Value;
      return type;
    }
  }

  public partial class RepTerm1RANGE : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm1RBRACKET : IRepTerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2RANGE : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm2RBRACKET : IRepTerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3RANGE : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class RepTerm3RBRACKET : IRepTerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      return new ASTEmpty();
    }
  }

  public partial class Term1LBRACKET : ITerm1
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // this can only be an array literal, so we can skip repterm2
      return this.Term2.ToAbstractSyntax();
    }
  }

  public partial class Term2LBRACKET : ITerm2
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // this can only be an array literal, so we can skip repterm3
      return this.Term3.ToAbstractSyntax();
    }
  }

  public partial class Term3LBRACKET : ITerm3
  {
    public virtual IASTNode ToAbstractSyntax()
    {
      // this can only be an array literal, so we can skip repfactor
      return this.Factor.ToAbstractSyntax();
    }
  }


}