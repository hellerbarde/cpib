using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
  public class Parser
  {
    private IList<Token> TokenList { get; set; }

    private IEnumerator<Token> tokens;
    private Token token;
    private Terminals terminal;

    public Parser(IList<Token> tl)
    {
      TokenList = tl;
      tokens = TokenList.GetEnumerator();
      tokens.Reset();
      tokens.MoveNext();
      token = tokens.Current;
      terminal = token.Terminal;
    }

    private Tokennode consume(Terminals expectedTerminal)
    {
      if (terminal == expectedTerminal) {
        Token consumedToken = token;
        if (terminal != Terminals.SENTINEL) {
          tokens.MoveNext();
          token = tokens.Current;
          // maintain class invariant
          terminal = token.Terminal;
        }
        return new Tokennode(consumedToken);
      }
      else {
        throw new GrammarException("terminal expected: " + expectedTerminal +
          ", terminal found: " + terminal, token.Row, token.Column);
      }
    }

    
    public IProgram parseprogram()
    {
      switch (terminal) {
        case Terminals.PROGRAM:
        {
          var Program = new ProgramPROGRAM();
          Program.PROGRAM = consume(Terminals.PROGRAM);
          Program.IDENT = consume(Terminals.IDENT);
          Program.ProgParamList = parseprogParamList();
          Program.OptCpsDecl = parseoptCpsDecl();
          Program.DO = consume(Terminals.DO);
          Program.CpsCmd = parsecpsCmd();
          Program.ENDPROGRAM = consume(Terminals.ENDPROGRAM);
          return Program;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'program' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IDecl parsedecl()
    {
      switch (terminal) {
        case Terminals.CHANGEMODE:
        {
          var Decl = new DeclCHANGEMODE();
          Decl.StoDecl = parsestoDecl();
          return Decl;
        }
        
        case Terminals.IDENT:
        {
          var Decl = new DeclIDENT();
          Decl.StoDecl = parsestoDecl();
          return Decl;
        }
        
        case Terminals.FUN:
        {
          var Decl = new DeclFUN();
          Decl.FunDecl = parsefunDecl();
          return Decl;
        }
        
        case Terminals.PROC:
        {
          var Decl = new DeclPROC();
          Decl.ProcDecl = parseprocDecl();
          return Decl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'decl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IStoDecl parsestoDecl()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var StoDecl = new StoDeclIDENT();
          StoDecl.TypedIdent = parsetypedIdent();
          return StoDecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var StoDecl = new StoDeclCHANGEMODE();
          StoDecl.CHANGEMODE = consume(Terminals.CHANGEMODE);
          StoDecl.TypedIdent = parsetypedIdent();
          return StoDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'stoDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IFunDecl parsefunDecl()
    {
      switch (terminal) {
        case Terminals.FUN:
        {
          var FunDecl = new FunDeclFUN();
          FunDecl.FUN = consume(Terminals.FUN);
          FunDecl.IDENT = consume(Terminals.IDENT);
          FunDecl.ParamList = parseparamList();
          FunDecl.RETURNS = consume(Terminals.RETURNS);
          FunDecl.StoDecl = parsestoDecl();
          FunDecl.OptGlobImps = parseoptGlobImps();
          FunDecl.OptCpsStoDecl = parseoptCpsStoDecl();
          FunDecl.DO = consume(Terminals.DO);
          FunDecl.CpsCmd = parsecpsCmd();
          FunDecl.ENDFUN = consume(Terminals.ENDFUN);
          return FunDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'funDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IProcDecl parseprocDecl()
    {
      switch (terminal) {
        case Terminals.PROC:
        {
          var ProcDecl = new ProcDeclPROC();
          ProcDecl.PROC = consume(Terminals.PROC);
          ProcDecl.IDENT = consume(Terminals.IDENT);
          ProcDecl.ParamList = parseparamList();
          ProcDecl.OptGlobImps = parseoptGlobImps();
          ProcDecl.OptCpsStoDecl = parseoptCpsStoDecl();
          ProcDecl.DO = consume(Terminals.DO);
          ProcDecl.CpsCmd = parsecpsCmd();
          ProcDecl.ENDPROC = consume(Terminals.ENDPROC);
          return ProcDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'procDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptGlobImps parseoptGlobImps()
    {
      switch (terminal) {
        case Terminals.GLOBAL:
        {
          var OptGlobImps = new OptGlobImpsGLOBAL();
          OptGlobImps.GLOBAL = consume(Terminals.GLOBAL);
          OptGlobImps.GlobImps = parseglobImps();
          return OptGlobImps;
        }
        
        case Terminals.DO:
        {
          var OptGlobImps = new OptGlobImpsDO();
          // Epsilon
          return OptGlobImps;
        }
        
        case Terminals.LOCAL:
        {
          var OptGlobImps = new OptGlobImpsLOCAL();
          // Epsilon
          return OptGlobImps;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optGlobImps' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IGlobImps parseglobImps()
    {
      switch (terminal) {
        case Terminals.FLOWMODE:
        {
          var GlobImps = new GlobImpsFLOWMODE();
          GlobImps.GlobImp = parseglobImp();
          GlobImps.RepGlobImps = parserepGlobImps();
          return GlobImps;
        }
        
        case Terminals.IDENT:
        {
          var GlobImps = new GlobImpsIDENT();
          GlobImps.GlobImp = parseglobImp();
          GlobImps.RepGlobImps = parserepGlobImps();
          return GlobImps;
        }
        
        case Terminals.CHANGEMODE:
        {
          var GlobImps = new GlobImpsCHANGEMODE();
          GlobImps.GlobImp = parseglobImp();
          GlobImps.RepGlobImps = parserepGlobImps();
          return GlobImps;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'globImps' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepGlobImps parserepGlobImps()
    {
      switch (terminal) {
        case Terminals.COMMA:
        {
          var RepGlobImps = new RepGlobImpsCOMMA();
          RepGlobImps.COMMA = consume(Terminals.COMMA);
          RepGlobImps.GlobImp = parseglobImp();
          RepGlobImps.RepGlobImps = parserepGlobImps();
          return RepGlobImps;
        }
        
        case Terminals.DO:
        {
          var RepGlobImps = new RepGlobImpsDO();
          // Epsilon
          return RepGlobImps;
        }
        
        case Terminals.LOCAL:
        {
          var RepGlobImps = new RepGlobImpsLOCAL();
          // Epsilon
          return RepGlobImps;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repGlobImps' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptChangemode parseoptChangemode()
    {
      switch (terminal) {
        case Terminals.CHANGEMODE:
        {
          var OptChangemode = new OptChangemodeCHANGEMODE();
          OptChangemode.CHANGEMODE = consume(Terminals.CHANGEMODE);
          return OptChangemode;
        }
        
        case Terminals.IDENT:
        {
          var OptChangemode = new OptChangemodeIDENT();
          // Epsilon
          return OptChangemode;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optChangemode' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptMechmode parseoptMechmode()
    {
      switch (terminal) {
        case Terminals.MECHMODE:
        {
          var OptMechmode = new OptMechmodeMECHMODE();
          OptMechmode.MECHMODE = consume(Terminals.MECHMODE);
          return OptMechmode;
        }
        
        case Terminals.IDENT:
        {
          var OptMechmode = new OptMechmodeIDENT();
          // Epsilon
          return OptMechmode;
        }
        
        case Terminals.CHANGEMODE:
        {
          var OptMechmode = new OptMechmodeCHANGEMODE();
          // Epsilon
          return OptMechmode;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optMechmode' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IGlobImp parseglobImp()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var GlobImp = new GlobImpIDENT();
          GlobImp.OptChangemode = parseoptChangemode();
          GlobImp.IDENT = consume(Terminals.IDENT);
          return GlobImp;
        }
        
        case Terminals.CHANGEMODE:
        {
          var GlobImp = new GlobImpCHANGEMODE();
          GlobImp.OptChangemode = parseoptChangemode();
          GlobImp.IDENT = consume(Terminals.IDENT);
          return GlobImp;
        }
        
        case Terminals.FLOWMODE:
        {
          var GlobImp = new GlobImpFLOWMODE();
          GlobImp.FLOWMODE = consume(Terminals.FLOWMODE);
          GlobImp.OptChangemode = parseoptChangemode();
          GlobImp.IDENT = consume(Terminals.IDENT);
          return GlobImp;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'globImp' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptCpsDecl parseoptCpsDecl()
    {
      switch (terminal) {
        case Terminals.GLOBAL:
        {
          var OptCpsDecl = new OptCpsDeclGLOBAL();
          OptCpsDecl.GLOBAL = consume(Terminals.GLOBAL);
          OptCpsDecl.CpsDecl = parsecpsDecl();
          return OptCpsDecl;
        }
        
        case Terminals.DO:
        {
          var OptCpsDecl = new OptCpsDeclDO();
          // Epsilon
          return OptCpsDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optCpsDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ICpsDecl parsecpsDecl()
    {
      switch (terminal) {
        case Terminals.PROC:
        {
          var CpsDecl = new CpsDeclPROC();
          CpsDecl.Decl = parsedecl();
          CpsDecl.RepCpsDecl = parserepCpsDecl();
          return CpsDecl;
        }
        
        case Terminals.FUN:
        {
          var CpsDecl = new CpsDeclFUN();
          CpsDecl.Decl = parsedecl();
          CpsDecl.RepCpsDecl = parserepCpsDecl();
          return CpsDecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var CpsDecl = new CpsDeclCHANGEMODE();
          CpsDecl.Decl = parsedecl();
          CpsDecl.RepCpsDecl = parserepCpsDecl();
          return CpsDecl;
        }
        
        case Terminals.IDENT:
        {
          var CpsDecl = new CpsDeclIDENT();
          CpsDecl.Decl = parsedecl();
          CpsDecl.RepCpsDecl = parserepCpsDecl();
          return CpsDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'cpsDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepCpsDecl parserepCpsDecl()
    {
      switch (terminal) {
        case Terminals.SEMICOLON:
        {
          var RepCpsDecl = new RepCpsDeclSEMICOLON();
          RepCpsDecl.SEMICOLON = consume(Terminals.SEMICOLON);
          RepCpsDecl.Decl = parsedecl();
          RepCpsDecl.RepCpsDecl = parserepCpsDecl();
          return RepCpsDecl;
        }
        
        case Terminals.DO:
        {
          var RepCpsDecl = new RepCpsDeclDO();
          // Epsilon
          return RepCpsDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repCpsDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptCpsStoDecl parseoptCpsStoDecl()
    {
      switch (terminal) {
        case Terminals.LOCAL:
        {
          var OptCpsStoDecl = new OptCpsStoDeclLOCAL();
          OptCpsStoDecl.LOCAL = consume(Terminals.LOCAL);
          OptCpsStoDecl.CpsStoDecl = parsecpsStoDecl();
          return OptCpsStoDecl;
        }
        
        case Terminals.DO:
        {
          var OptCpsStoDecl = new OptCpsStoDeclDO();
          // Epsilon
          return OptCpsStoDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optCpsStoDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ICpsStoDecl parsecpsStoDecl()
    {
      switch (terminal) {
        case Terminals.CHANGEMODE:
        {
          var CpsStoDecl = new CpsStoDeclCHANGEMODE();
          CpsStoDecl.StoDecl = parsestoDecl();
          CpsStoDecl.RepCpsStoDecl = parserepCpsStoDecl();
          return CpsStoDecl;
        }
        
        case Terminals.IDENT:
        {
          var CpsStoDecl = new CpsStoDeclIDENT();
          CpsStoDecl.StoDecl = parsestoDecl();
          CpsStoDecl.RepCpsStoDecl = parserepCpsStoDecl();
          return CpsStoDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'cpsStoDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepCpsStoDecl parserepCpsStoDecl()
    {
      switch (terminal) {
        case Terminals.SEMICOLON:
        {
          var RepCpsStoDecl = new RepCpsStoDeclSEMICOLON();
          RepCpsStoDecl.SEMICOLON = consume(Terminals.SEMICOLON);
          RepCpsStoDecl.StoDecl = parsestoDecl();
          RepCpsStoDecl.RepCpsStoDecl = parserepCpsStoDecl();
          return RepCpsStoDecl;
        }
        
        case Terminals.DO:
        {
          var RepCpsStoDecl = new RepCpsStoDeclDO();
          // Epsilon
          return RepCpsStoDecl;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repCpsStoDecl' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IProgParamList parseprogParamList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var ProgParamList = new ProgParamListLPAREN();
          ProgParamList.LPAREN = consume(Terminals.LPAREN);
          ProgParamList.OptProgParamList = parseoptProgParamList();
          ProgParamList.RPAREN = consume(Terminals.RPAREN);
          return ProgParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'progParamList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptProgParamList parseoptProgParamList()
    {
      switch (terminal) {
        case Terminals.FLOWMODE:
        {
          var OptProgParamList = new OptProgParamListFLOWMODE();
          OptProgParamList.ProgParam = parseprogParam();
          OptProgParamList.RepProgParamList = parserepProgParamList();
          return OptProgParamList;
        }
        
        case Terminals.IDENT:
        {
          var OptProgParamList = new OptProgParamListIDENT();
          OptProgParamList.ProgParam = parseprogParam();
          OptProgParamList.RepProgParamList = parserepProgParamList();
          return OptProgParamList;
        }
        
        case Terminals.CHANGEMODE:
        {
          var OptProgParamList = new OptProgParamListCHANGEMODE();
          OptProgParamList.ProgParam = parseprogParam();
          OptProgParamList.RepProgParamList = parserepProgParamList();
          return OptProgParamList;
        }
        
        case Terminals.RPAREN:
        {
          var OptProgParamList = new OptProgParamListRPAREN();
          // Epsilon
          return OptProgParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optProgParamList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepProgParamList parserepProgParamList()
    {
      switch (terminal) {
        case Terminals.COMMA:
        {
          var RepProgParamList = new RepProgParamListCOMMA();
          RepProgParamList.COMMA = consume(Terminals.COMMA);
          RepProgParamList.ProgParam = parseprogParam();
          RepProgParamList.RepProgParamList = parserepProgParamList();
          return RepProgParamList;
        }
        
        case Terminals.RPAREN:
        {
          var RepProgParamList = new RepProgParamListRPAREN();
          // Epsilon
          return RepProgParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repProgParamList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IProgParam parseprogParam()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var ProgParam = new ProgParamIDENT();
          ProgParam.OptChangemode = parseoptChangemode();
          ProgParam.TypedIdent = parsetypedIdent();
          return ProgParam;
        }
        
        case Terminals.CHANGEMODE:
        {
          var ProgParam = new ProgParamCHANGEMODE();
          ProgParam.OptChangemode = parseoptChangemode();
          ProgParam.TypedIdent = parsetypedIdent();
          return ProgParam;
        }
        
        case Terminals.FLOWMODE:
        {
          var ProgParam = new ProgParamFLOWMODE();
          ProgParam.FLOWMODE = consume(Terminals.FLOWMODE);
          ProgParam.OptChangemode = parseoptChangemode();
          ProgParam.TypedIdent = parsetypedIdent();
          return ProgParam;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'progParam' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IParamList parseparamList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var ParamList = new ParamListLPAREN();
          ParamList.LPAREN = consume(Terminals.LPAREN);
          ParamList.OptParamList = parseoptParamList();
          ParamList.RPAREN = consume(Terminals.RPAREN);
          return ParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'paramList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptParamList parseoptParamList()
    {
      switch (terminal) {
        case Terminals.FLOWMODE:
        {
          var OptParamList = new OptParamListFLOWMODE();
          OptParamList.Param = parseparam();
          OptParamList.RepParamList = parserepParamList();
          return OptParamList;
        }
        
        case Terminals.IDENT:
        {
          var OptParamList = new OptParamListIDENT();
          OptParamList.Param = parseparam();
          OptParamList.RepParamList = parserepParamList();
          return OptParamList;
        }
        
        case Terminals.CHANGEMODE:
        {
          var OptParamList = new OptParamListCHANGEMODE();
          OptParamList.Param = parseparam();
          OptParamList.RepParamList = parserepParamList();
          return OptParamList;
        }
        
        case Terminals.MECHMODE:
        {
          var OptParamList = new OptParamListMECHMODE();
          OptParamList.Param = parseparam();
          OptParamList.RepParamList = parserepParamList();
          return OptParamList;
        }
        
        case Terminals.RPAREN:
        {
          var OptParamList = new OptParamListRPAREN();
          // Epsilon
          return OptParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optParamList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepParamList parserepParamList()
    {
      switch (terminal) {
        case Terminals.COMMA:
        {
          var RepParamList = new RepParamListCOMMA();
          RepParamList.COMMA = consume(Terminals.COMMA);
          RepParamList.Param = parseparam();
          RepParamList.RepParamList = parserepParamList();
          return RepParamList;
        }
        
        case Terminals.RPAREN:
        {
          var RepParamList = new RepParamListRPAREN();
          // Epsilon
          return RepParamList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repParamList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IParam parseparam()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var Param = new ParamIDENT();
          Param.OptMechmode = parseoptMechmode();
          Param.OptChangemode = parseoptChangemode();
          Param.TypedIdent = parsetypedIdent();
          return Param;
        }
        
        case Terminals.CHANGEMODE:
        {
          var Param = new ParamCHANGEMODE();
          Param.OptMechmode = parseoptMechmode();
          Param.OptChangemode = parseoptChangemode();
          Param.TypedIdent = parsetypedIdent();
          return Param;
        }
        
        case Terminals.MECHMODE:
        {
          var Param = new ParamMECHMODE();
          Param.OptMechmode = parseoptMechmode();
          Param.OptChangemode = parseoptChangemode();
          Param.TypedIdent = parsetypedIdent();
          return Param;
        }
        
        case Terminals.FLOWMODE:
        {
          var Param = new ParamFLOWMODE();
          Param.FLOWMODE = consume(Terminals.FLOWMODE);
          Param.OptMechmode = parseoptMechmode();
          Param.OptChangemode = parseoptChangemode();
          Param.TypedIdent = parsetypedIdent();
          return Param;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'param' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ITypedIdent parsetypedIdent()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var TypedIdent = new TypedIdentIDENT();
          TypedIdent.IDENT = consume(Terminals.IDENT);
          TypedIdent.COLON = consume(Terminals.COLON);
          TypedIdent.TypeOrArray = parsetypeOrArray();
          return TypedIdent;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'typedIdent' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ITypeOrArray parsetypeOrArray()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var TypeOrArray = new TypeOrArrayTYPE();
          TypeOrArray.TYPE = consume(Terminals.TYPE);
          return TypeOrArray;
        }
        
        case Terminals.ARRAY:
        {
          var TypeOrArray = new TypeOrArrayARRAY();
          TypeOrArray.ARRAY = consume(Terminals.ARRAY);
          TypeOrArray.LPAREN = consume(Terminals.LPAREN);
          TypeOrArray.Expr = parseexpr();
          TypeOrArray.RepArrayLength = parserepArrayLength();
          TypeOrArray.RPAREN = consume(Terminals.RPAREN);
          TypeOrArray.TYPE = consume(Terminals.TYPE);
          return TypeOrArray;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'typeOrArray' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepArrayLength parserepArrayLength()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var RepArrayLength = new RepArrayLengthRPAREN();
          // Epsilon
          return RepArrayLength;
        }
        
        case Terminals.COMMA:
        {
          var RepArrayLength = new RepArrayLengthCOMMA();
          RepArrayLength.COMMA = consume(Terminals.COMMA);
          RepArrayLength.Expr = parseexpr();
          RepArrayLength.RepArrayLength = parserepArrayLength();
          return RepArrayLength;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repArrayLength' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ICmd parsecmd()
    {
      switch (terminal) {
        case Terminals.SKIP:
        {
          var Cmd = new CmdSKIP();
          Cmd.SKIP = consume(Terminals.SKIP);
          return Cmd;
        }
        
        case Terminals.TYPE:
        {
          var Cmd = new CmdTYPE();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.LPAREN:
        {
          var Cmd = new CmdLPAREN();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.ADDOPR:
        {
          var Cmd = new CmdADDOPR();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.NOT:
        {
          var Cmd = new CmdNOT();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.IDENT:
        {
          var Cmd = new CmdIDENT();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.LBRACKET:
        {
          var Cmd = new CmdLBRACKET();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.LITERAL:
        {
          var Cmd = new CmdLITERAL();
          Cmd.Expr = parseexpr();
          Cmd.BECOMES = consume(Terminals.BECOMES);
          Cmd.OptFill = parseoptFill();
          Cmd.Expr2 = parseexpr();
          return Cmd;
        }
        
        case Terminals.IF:
        {
          var Cmd = new CmdIF();
          Cmd.IF = consume(Terminals.IF);
          Cmd.Expr = parseexpr();
          Cmd.THEN = consume(Terminals.THEN);
          Cmd.CpsCmd = parsecpsCmd();
          Cmd.ELSE = consume(Terminals.ELSE);
          Cmd.CpsCmd2 = parsecpsCmd();
          Cmd.ENDIF = consume(Terminals.ENDIF);
          return Cmd;
        }
        
        case Terminals.WHILE:
        {
          var Cmd = new CmdWHILE();
          Cmd.WHILE = consume(Terminals.WHILE);
          Cmd.Expr = parseexpr();
          Cmd.DO = consume(Terminals.DO);
          Cmd.CpsCmd = parsecpsCmd();
          Cmd.ENDWHILE = consume(Terminals.ENDWHILE);
          return Cmd;
        }
        
        case Terminals.CALL:
        {
          var Cmd = new CmdCALL();
          Cmd.CALL = consume(Terminals.CALL);
          Cmd.IDENT = consume(Terminals.IDENT);
          Cmd.ExprList = parseexprList();
          Cmd.OptGlobInits = parseoptGlobInits();
          return Cmd;
        }
        
        case Terminals.DEBUGIN:
        {
          var Cmd = new CmdDEBUGIN();
          Cmd.DEBUGIN = consume(Terminals.DEBUGIN);
          Cmd.Expr = parseexpr();
          return Cmd;
        }
        
        case Terminals.DEBUGOUT:
        {
          var Cmd = new CmdDEBUGOUT();
          Cmd.DEBUGOUT = consume(Terminals.DEBUGOUT);
          Cmd.Expr = parseexpr();
          return Cmd;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'cmd' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ICpsCmd parsecpsCmd()
    {
      switch (terminal) {
        case Terminals.DEBUGOUT:
        {
          var CpsCmd = new CpsCmdDEBUGOUT();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.DEBUGIN:
        {
          var CpsCmd = new CpsCmdDEBUGIN();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.CALL:
        {
          var CpsCmd = new CpsCmdCALL();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.WHILE:
        {
          var CpsCmd = new CpsCmdWHILE();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.IF:
        {
          var CpsCmd = new CpsCmdIF();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.TYPE:
        {
          var CpsCmd = new CpsCmdTYPE();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.LPAREN:
        {
          var CpsCmd = new CpsCmdLPAREN();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.ADDOPR:
        {
          var CpsCmd = new CpsCmdADDOPR();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.NOT:
        {
          var CpsCmd = new CpsCmdNOT();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.IDENT:
        {
          var CpsCmd = new CpsCmdIDENT();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.LBRACKET:
        {
          var CpsCmd = new CpsCmdLBRACKET();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.LITERAL:
        {
          var CpsCmd = new CpsCmdLITERAL();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        
        case Terminals.SKIP:
        {
          var CpsCmd = new CpsCmdSKIP();
          CpsCmd.Cmd = parsecmd();
          CpsCmd.RepCpsCmd = parserepCpsCmd();
          return CpsCmd;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'cpsCmd' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepCpsCmd parserepCpsCmd()
    {
      switch (terminal) {
        case Terminals.SEMICOLON:
        {
          var RepCpsCmd = new RepCpsCmdSEMICOLON();
          RepCpsCmd.SEMICOLON = consume(Terminals.SEMICOLON);
          RepCpsCmd.Cmd = parsecmd();
          RepCpsCmd.RepCpsCmd = parserepCpsCmd();
          return RepCpsCmd;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepCpsCmd = new RepCpsCmdENDWHILE();
          // Epsilon
          return RepCpsCmd;
        }
        
        case Terminals.ENDIF:
        {
          var RepCpsCmd = new RepCpsCmdENDIF();
          // Epsilon
          return RepCpsCmd;
        }
        
        case Terminals.ELSE:
        {
          var RepCpsCmd = new RepCpsCmdELSE();
          // Epsilon
          return RepCpsCmd;
        }
        
        case Terminals.ENDPROC:
        {
          var RepCpsCmd = new RepCpsCmdENDPROC();
          // Epsilon
          return RepCpsCmd;
        }
        
        case Terminals.ENDFUN:
        {
          var RepCpsCmd = new RepCpsCmdENDFUN();
          // Epsilon
          return RepCpsCmd;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepCpsCmd = new RepCpsCmdENDPROGRAM();
          // Epsilon
          return RepCpsCmd;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repCpsCmd' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptFill parseoptFill()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var OptFill = new OptFillTYPE();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.LPAREN:
        {
          var OptFill = new OptFillLPAREN();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.ADDOPR:
        {
          var OptFill = new OptFillADDOPR();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.NOT:
        {
          var OptFill = new OptFillNOT();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.IDENT:
        {
          var OptFill = new OptFillIDENT();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.LBRACKET:
        {
          var OptFill = new OptFillLBRACKET();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.LITERAL:
        {
          var OptFill = new OptFillLITERAL();
          // Epsilon
          return OptFill;
        }
        
        case Terminals.FILL:
        {
          var OptFill = new OptFillFILL();
          OptFill.FILL = consume(Terminals.FILL);
          return OptFill;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optFill' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptGlobInits parseoptGlobInits()
    {
      switch (terminal) {
        case Terminals.INIT:
        {
          var OptGlobInits = new OptGlobInitsINIT();
          OptGlobInits.INIT = consume(Terminals.INIT);
          OptGlobInits.IDENT = consume(Terminals.IDENT);
          OptGlobInits.RepIdents = parserepIdents();
          return OptGlobInits;
        }
        
        case Terminals.ENDWHILE:
        {
          var OptGlobInits = new OptGlobInitsENDWHILE();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.ENDIF:
        {
          var OptGlobInits = new OptGlobInitsENDIF();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.ELSE:
        {
          var OptGlobInits = new OptGlobInitsELSE();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.ENDPROC:
        {
          var OptGlobInits = new OptGlobInitsENDPROC();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.ENDFUN:
        {
          var OptGlobInits = new OptGlobInitsENDFUN();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var OptGlobInits = new OptGlobInitsENDPROGRAM();
          // Epsilon
          return OptGlobInits;
        }
        
        case Terminals.SEMICOLON:
        {
          var OptGlobInits = new OptGlobInitsSEMICOLON();
          // Epsilon
          return OptGlobInits;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optGlobInits' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepIdents parserepIdents()
    {
      switch (terminal) {
        case Terminals.COMMA:
        {
          var RepIdents = new RepIdentsCOMMA();
          RepIdents.COMMA = consume(Terminals.COMMA);
          RepIdents.IDENT = consume(Terminals.IDENT);
          RepIdents.RepIdents = parserepIdents();
          return RepIdents;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepIdents = new RepIdentsENDWHILE();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.ENDIF:
        {
          var RepIdents = new RepIdentsENDIF();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.ELSE:
        {
          var RepIdents = new RepIdentsELSE();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.ENDPROC:
        {
          var RepIdents = new RepIdentsENDPROC();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.ENDFUN:
        {
          var RepIdents = new RepIdentsENDFUN();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepIdents = new RepIdentsENDPROGRAM();
          // Epsilon
          return RepIdents;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepIdents = new RepIdentsSEMICOLON();
          // Epsilon
          return RepIdents;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repIdents' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IExpr parseexpr()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var Expr = new ExprTYPE();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.LPAREN:
        {
          var Expr = new ExprLPAREN();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.ADDOPR:
        {
          var Expr = new ExprADDOPR();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.NOT:
        {
          var Expr = new ExprNOT();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.IDENT:
        {
          var Expr = new ExprIDENT();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.LBRACKET:
        {
          var Expr = new ExprLBRACKET();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        
        case Terminals.LITERAL:
        {
          var Expr = new ExprLITERAL();
          Expr.Term1 = parseterm1();
          Expr.RepTerm1 = parserepTerm1();
          return Expr;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'expr' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepTerm1 parserepTerm1()
    {
      switch (terminal) {
        case Terminals.BOOLOPR:
        {
          var RepTerm1 = new RepTerm1BOOLOPR();
          RepTerm1.BOOLOPR = consume(Terminals.BOOLOPR);
          RepTerm1.Term1 = parseterm1();
          RepTerm1.RepTerm1 = parserepTerm1();
          return RepTerm1;
        }
        
        case Terminals.RBRACKET:
        {
          var RepTerm1 = new RepTerm1RBRACKET();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.RANGE:
        {
          var RepTerm1 = new RepTerm1RANGE();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.DO:
        {
          var RepTerm1 = new RepTerm1DO();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.THEN:
        {
          var RepTerm1 = new RepTerm1THEN();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepTerm1 = new RepTerm1ENDWHILE();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ENDIF:
        {
          var RepTerm1 = new RepTerm1ENDIF();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ELSE:
        {
          var RepTerm1 = new RepTerm1ELSE();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ENDPROC:
        {
          var RepTerm1 = new RepTerm1ENDPROC();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ENDFUN:
        {
          var RepTerm1 = new RepTerm1ENDFUN();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepTerm1 = new RepTerm1ENDPROGRAM();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepTerm1 = new RepTerm1SEMICOLON();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.BECOMES:
        {
          var RepTerm1 = new RepTerm1BECOMES();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.RPAREN:
        {
          var RepTerm1 = new RepTerm1RPAREN();
          // Epsilon
          return RepTerm1;
        }
        
        case Terminals.COMMA:
        {
          var RepTerm1 = new RepTerm1COMMA();
          // Epsilon
          return RepTerm1;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repTerm1' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ITerm1 parseterm1()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var Term1 = new Term1TYPE();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.LPAREN:
        {
          var Term1 = new Term1LPAREN();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.ADDOPR:
        {
          var Term1 = new Term1ADDOPR();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.NOT:
        {
          var Term1 = new Term1NOT();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.IDENT:
        {
          var Term1 = new Term1IDENT();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.LBRACKET:
        {
          var Term1 = new Term1LBRACKET();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        
        case Terminals.LITERAL:
        {
          var Term1 = new Term1LITERAL();
          Term1.Term2 = parseterm2();
          Term1.RepTerm2 = parserepTerm2();
          return Term1;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'term1' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepTerm2 parserepTerm2()
    {
      switch (terminal) {
        case Terminals.RELOPR:
        {
          var RepTerm2 = new RepTerm2RELOPR();
          RepTerm2.RELOPR = consume(Terminals.RELOPR);
          RepTerm2.Term2 = parseterm2();
          RepTerm2.RepTerm2 = parserepTerm2();
          return RepTerm2;
        }
        
        case Terminals.RBRACKET:
        {
          var RepTerm2 = new RepTerm2RBRACKET();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.RANGE:
        {
          var RepTerm2 = new RepTerm2RANGE();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.DO:
        {
          var RepTerm2 = new RepTerm2DO();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.THEN:
        {
          var RepTerm2 = new RepTerm2THEN();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepTerm2 = new RepTerm2ENDWHILE();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ENDIF:
        {
          var RepTerm2 = new RepTerm2ENDIF();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ELSE:
        {
          var RepTerm2 = new RepTerm2ELSE();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ENDPROC:
        {
          var RepTerm2 = new RepTerm2ENDPROC();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ENDFUN:
        {
          var RepTerm2 = new RepTerm2ENDFUN();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepTerm2 = new RepTerm2ENDPROGRAM();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepTerm2 = new RepTerm2SEMICOLON();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.BECOMES:
        {
          var RepTerm2 = new RepTerm2BECOMES();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.RPAREN:
        {
          var RepTerm2 = new RepTerm2RPAREN();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.COMMA:
        {
          var RepTerm2 = new RepTerm2COMMA();
          // Epsilon
          return RepTerm2;
        }
        
        case Terminals.BOOLOPR:
        {
          var RepTerm2 = new RepTerm2BOOLOPR();
          // Epsilon
          return RepTerm2;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repTerm2' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ITerm2 parseterm2()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var Term2 = new Term2TYPE();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.LPAREN:
        {
          var Term2 = new Term2LPAREN();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.ADDOPR:
        {
          var Term2 = new Term2ADDOPR();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.NOT:
        {
          var Term2 = new Term2NOT();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.IDENT:
        {
          var Term2 = new Term2IDENT();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.LBRACKET:
        {
          var Term2 = new Term2LBRACKET();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        
        case Terminals.LITERAL:
        {
          var Term2 = new Term2LITERAL();
          Term2.Term3 = parseterm3();
          Term2.RepTerm3 = parserepTerm3();
          return Term2;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'term2' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepTerm3 parserepTerm3()
    {
      switch (terminal) {
        case Terminals.ADDOPR:
        {
          var RepTerm3 = new RepTerm3ADDOPR();
          RepTerm3.ADDOPR = consume(Terminals.ADDOPR);
          RepTerm3.Term3 = parseterm3();
          RepTerm3.RepTerm3 = parserepTerm3();
          return RepTerm3;
        }
        
        case Terminals.RBRACKET:
        {
          var RepTerm3 = new RepTerm3RBRACKET();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.RANGE:
        {
          var RepTerm3 = new RepTerm3RANGE();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.DO:
        {
          var RepTerm3 = new RepTerm3DO();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.THEN:
        {
          var RepTerm3 = new RepTerm3THEN();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepTerm3 = new RepTerm3ENDWHILE();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ENDIF:
        {
          var RepTerm3 = new RepTerm3ENDIF();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ELSE:
        {
          var RepTerm3 = new RepTerm3ELSE();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ENDPROC:
        {
          var RepTerm3 = new RepTerm3ENDPROC();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ENDFUN:
        {
          var RepTerm3 = new RepTerm3ENDFUN();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepTerm3 = new RepTerm3ENDPROGRAM();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepTerm3 = new RepTerm3SEMICOLON();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.BECOMES:
        {
          var RepTerm3 = new RepTerm3BECOMES();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.RPAREN:
        {
          var RepTerm3 = new RepTerm3RPAREN();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.COMMA:
        {
          var RepTerm3 = new RepTerm3COMMA();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.BOOLOPR:
        {
          var RepTerm3 = new RepTerm3BOOLOPR();
          // Epsilon
          return RepTerm3;
        }
        
        case Terminals.RELOPR:
        {
          var RepTerm3 = new RepTerm3RELOPR();
          // Epsilon
          return RepTerm3;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repTerm3' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ITerm3 parseterm3()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var Term3 = new Term3TYPE();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.LPAREN:
        {
          var Term3 = new Term3LPAREN();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.ADDOPR:
        {
          var Term3 = new Term3ADDOPR();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.NOT:
        {
          var Term3 = new Term3NOT();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.IDENT:
        {
          var Term3 = new Term3IDENT();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.LBRACKET:
        {
          var Term3 = new Term3LBRACKET();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        
        case Terminals.LITERAL:
        {
          var Term3 = new Term3LITERAL();
          Term3.Factor = parsefactor();
          Term3.RepFactor = parserepFactor();
          return Term3;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'term3' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepFactor parserepFactor()
    {
      switch (terminal) {
        case Terminals.MULTOPR:
        {
          var RepFactor = new RepFactorMULTOPR();
          RepFactor.MULTOPR = consume(Terminals.MULTOPR);
          RepFactor.Factor = parsefactor();
          RepFactor.RepFactor = parserepFactor();
          return RepFactor;
        }
        
        case Terminals.RBRACKET:
        {
          var RepFactor = new RepFactorRBRACKET();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.RANGE:
        {
          var RepFactor = new RepFactorRANGE();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.DO:
        {
          var RepFactor = new RepFactorDO();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.THEN:
        {
          var RepFactor = new RepFactorTHEN();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepFactor = new RepFactorENDWHILE();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ENDIF:
        {
          var RepFactor = new RepFactorENDIF();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ELSE:
        {
          var RepFactor = new RepFactorELSE();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ENDPROC:
        {
          var RepFactor = new RepFactorENDPROC();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ENDFUN:
        {
          var RepFactor = new RepFactorENDFUN();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepFactor = new RepFactorENDPROGRAM();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepFactor = new RepFactorSEMICOLON();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.BECOMES:
        {
          var RepFactor = new RepFactorBECOMES();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.RPAREN:
        {
          var RepFactor = new RepFactorRPAREN();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.COMMA:
        {
          var RepFactor = new RepFactorCOMMA();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.BOOLOPR:
        {
          var RepFactor = new RepFactorBOOLOPR();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.RELOPR:
        {
          var RepFactor = new RepFactorRELOPR();
          // Epsilon
          return RepFactor;
        }
        
        case Terminals.ADDOPR:
        {
          var RepFactor = new RepFactorADDOPR();
          // Epsilon
          return RepFactor;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repFactor' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IFactor parsefactor()
    {
      switch (terminal) {
        case Terminals.LITERAL:
        {
          var Factor = new FactorLITERAL();
          Factor.LITERAL = consume(Terminals.LITERAL);
          return Factor;
        }
        
        case Terminals.LBRACKET:
        {
          var Factor = new FactorLBRACKET();
          Factor.ArrayLiteral = parsearrayLiteral();
          return Factor;
        }
        
        case Terminals.IDENT:
        {
          var Factor = new FactorIDENT();
          Factor.IDENT = consume(Terminals.IDENT);
          Factor.OptInitOrExprListOrArrayAccess = parseoptInitOrExprListOrArrayAccess();
          return Factor;
        }
        
        case Terminals.ADDOPR:
        {
          var Factor = new FactorADDOPR();
          Factor.MonadicOpr = parsemonadicOpr();
          Factor.Factor = parsefactor();
          return Factor;
        }
        
        case Terminals.NOT:
        {
          var Factor = new FactorNOT();
          Factor.MonadicOpr = parsemonadicOpr();
          Factor.Factor = parsefactor();
          return Factor;
        }
        
        case Terminals.LPAREN:
        {
          var Factor = new FactorLPAREN();
          Factor.LPAREN = consume(Terminals.LPAREN);
          Factor.Expr = parseexpr();
          Factor.RPAREN = consume(Terminals.RPAREN);
          return Factor;
        }
        
        case Terminals.TYPE:
        {
          var Factor = new FactorTYPE();
          Factor.TYPE = consume(Terminals.TYPE);
          Factor.LPAREN = consume(Terminals.LPAREN);
          Factor.Expr = parseexpr();
          Factor.RPAREN = consume(Terminals.RPAREN);
          return Factor;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'factor' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IArrayLiteral parsearrayLiteral()
    {
      switch (terminal) {
        case Terminals.LBRACKET:
        {
          var ArrayLiteral = new ArrayLiteralLBRACKET();
          ArrayLiteral.LBRACKET = consume(Terminals.LBRACKET);
          ArrayLiteral.ArrayContent = parsearrayContent();
          ArrayLiteral.RBRACKET = consume(Terminals.RBRACKET);
          return ArrayLiteral;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'arrayLiteral' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IArrayContent parsearrayContent()
    {
      switch (terminal) {
        case Terminals.LITERAL:
        {
          var ArrayContent = new ArrayContentLITERAL();
          ArrayContent.LITERAL = consume(Terminals.LITERAL);
          ArrayContent.RepLiteral = parserepLiteral();
          return ArrayContent;
        }
        
        case Terminals.LBRACKET:
        {
          var ArrayContent = new ArrayContentLBRACKET();
          ArrayContent.ArrayLiteral = parsearrayLiteral();
          ArrayContent.RepArray = parserepArray();
          return ArrayContent;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'arrayContent' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepArray parserepArray()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var RepArray = new RepArrayRBRACKET();
          // Epsilon
          return RepArray;
        }
        
        case Terminals.COMMA:
        {
          var RepArray = new RepArrayCOMMA();
          RepArray.COMMA = consume(Terminals.COMMA);
          RepArray.ArrayLiteral = parsearrayLiteral();
          RepArray.RepArray = parserepArray();
          return RepArray;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repArray' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepLiteral parserepLiteral()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var RepLiteral = new RepLiteralRBRACKET();
          // Epsilon
          return RepLiteral;
        }
        
        case Terminals.COMMA:
        {
          var RepLiteral = new RepLiteralCOMMA();
          RepLiteral.COMMA = consume(Terminals.COMMA);
          RepLiteral.LITERAL = consume(Terminals.LITERAL);
          RepLiteral.RepLiteral = parserepLiteral();
          return RepLiteral;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repLiteral' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptInitOrExprListOrArrayAccess parseoptInitOrExprListOrArrayAccess()
    {
      switch (terminal) {
        case Terminals.INIT:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessINIT();
          OptInitOrExprListOrArrayAccess.INIT = consume(Terminals.INIT);
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.LBRACKET:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessLBRACKET();
          OptInitOrExprListOrArrayAccess.ArrayIndex = parsearrayIndex();
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.LPAREN:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessLPAREN();
          OptInitOrExprListOrArrayAccess.ExprList = parseexprList();
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.RBRACKET:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessRBRACKET();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.RANGE:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessRANGE();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.DO:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessDO();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.THEN:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessTHEN();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ENDWHILE:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessENDWHILE();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ENDIF:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessENDIF();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ELSE:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessELSE();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ENDPROC:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessENDPROC();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ENDFUN:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessENDFUN();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessENDPROGRAM();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.SEMICOLON:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessSEMICOLON();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.BECOMES:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessBECOMES();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.RPAREN:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessRPAREN();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.COMMA:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessCOMMA();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.BOOLOPR:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessBOOLOPR();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.RELOPR:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessRELOPR();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.ADDOPR:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessADDOPR();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        
        case Terminals.MULTOPR:
        {
          var OptInitOrExprListOrArrayAccess = new OptInitOrExprListOrArrayAccessMULTOPR();
          // Epsilon
          return OptInitOrExprListOrArrayAccess;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optInitOrExprListOrArrayAccess' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IArrayIndex parsearrayIndex()
    {
      switch (terminal) {
        case Terminals.LBRACKET:
        {
          var ArrayIndex = new ArrayIndexLBRACKET();
          ArrayIndex.LBRACKET = consume(Terminals.LBRACKET);
          ArrayIndex.SliceExpr = parsesliceExpr();
          ArrayIndex.RBRACKET = consume(Terminals.RBRACKET);
          ArrayIndex.RepArrayIndex = parserepArrayIndex();
          return ArrayIndex;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'arrayIndex' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public ISliceExpr parsesliceExpr()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var SliceExpr = new SliceExprTYPE();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.LPAREN:
        {
          var SliceExpr = new SliceExprLPAREN();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.ADDOPR:
        {
          var SliceExpr = new SliceExprADDOPR();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.NOT:
        {
          var SliceExpr = new SliceExprNOT();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.IDENT:
        {
          var SliceExpr = new SliceExprIDENT();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.LBRACKET:
        {
          var SliceExpr = new SliceExprLBRACKET();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        
        case Terminals.LITERAL:
        {
          var SliceExpr = new SliceExprLITERAL();
          SliceExpr.Expr = parseexpr();
          SliceExpr.RepSliceExpr = parserepSliceExpr();
          return SliceExpr;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'sliceExpr' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepSliceExpr parserepSliceExpr()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var RepSliceExpr = new RepSliceExprRBRACKET();
          // Epsilon
          return RepSliceExpr;
        }
        
        case Terminals.RANGE:
        {
          var RepSliceExpr = new RepSliceExprRANGE();
          RepSliceExpr.RANGE = consume(Terminals.RANGE);
          RepSliceExpr.Expr = parseexpr();
          return RepSliceExpr;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repSliceExpr' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepArrayIndex parserepArrayIndex()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var RepArrayIndex = new RepArrayIndexRBRACKET();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.RANGE:
        {
          var RepArrayIndex = new RepArrayIndexRANGE();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.DO:
        {
          var RepArrayIndex = new RepArrayIndexDO();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.THEN:
        {
          var RepArrayIndex = new RepArrayIndexTHEN();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ENDWHILE:
        {
          var RepArrayIndex = new RepArrayIndexENDWHILE();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ENDIF:
        {
          var RepArrayIndex = new RepArrayIndexENDIF();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ELSE:
        {
          var RepArrayIndex = new RepArrayIndexELSE();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ENDPROC:
        {
          var RepArrayIndex = new RepArrayIndexENDPROC();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ENDFUN:
        {
          var RepArrayIndex = new RepArrayIndexENDFUN();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var RepArrayIndex = new RepArrayIndexENDPROGRAM();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.SEMICOLON:
        {
          var RepArrayIndex = new RepArrayIndexSEMICOLON();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.BECOMES:
        {
          var RepArrayIndex = new RepArrayIndexBECOMES();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.RPAREN:
        {
          var RepArrayIndex = new RepArrayIndexRPAREN();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.COMMA:
        {
          var RepArrayIndex = new RepArrayIndexCOMMA();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.BOOLOPR:
        {
          var RepArrayIndex = new RepArrayIndexBOOLOPR();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.RELOPR:
        {
          var RepArrayIndex = new RepArrayIndexRELOPR();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.ADDOPR:
        {
          var RepArrayIndex = new RepArrayIndexADDOPR();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.MULTOPR:
        {
          var RepArrayIndex = new RepArrayIndexMULTOPR();
          // Epsilon
          return RepArrayIndex;
        }
        
        case Terminals.LBRACKET:
        {
          var RepArrayIndex = new RepArrayIndexLBRACKET();
          RepArrayIndex.ArrayIndex = parsearrayIndex();
          return RepArrayIndex;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repArrayIndex' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IMonadicOpr parsemonadicOpr()
    {
      switch (terminal) {
        case Terminals.NOT:
        {
          var MonadicOpr = new MonadicOprNOT();
          MonadicOpr.NOT = consume(Terminals.NOT);
          return MonadicOpr;
        }
        
        case Terminals.ADDOPR:
        {
          var MonadicOpr = new MonadicOprADDOPR();
          MonadicOpr.ADDOPR = consume(Terminals.ADDOPR);
          return MonadicOpr;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'monadicOpr' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IExprList parseexprList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var ExprList = new ExprListLPAREN();
          ExprList.LPAREN = consume(Terminals.LPAREN);
          ExprList.OptExprList = parseoptExprList();
          ExprList.RPAREN = consume(Terminals.RPAREN);
          return ExprList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'exprList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IOptExprList parseoptExprList()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var OptExprList = new OptExprListTYPE();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.LPAREN:
        {
          var OptExprList = new OptExprListLPAREN();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.ADDOPR:
        {
          var OptExprList = new OptExprListADDOPR();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.NOT:
        {
          var OptExprList = new OptExprListNOT();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.IDENT:
        {
          var OptExprList = new OptExprListIDENT();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.LBRACKET:
        {
          var OptExprList = new OptExprListLBRACKET();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.LITERAL:
        {
          var OptExprList = new OptExprListLITERAL();
          OptExprList.Expr = parseexpr();
          OptExprList.RepExprList = parserepExprList();
          return OptExprList;
        }
        
        case Terminals.RPAREN:
        {
          var OptExprList = new OptExprListRPAREN();
          // Epsilon
          return OptExprList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'optExprList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    
    public IRepExprList parserepExprList()
    {
      switch (terminal) {
        case Terminals.COMMA:
        {
          var RepExprList = new RepExprListCOMMA();
          RepExprList.COMMA = consume(Terminals.COMMA);
          RepExprList.Expr = parseexpr();
          RepExprList.RepExprList = parserepExprList();
          return RepExprList;
        }
        
        case Terminals.RPAREN:
        {
          var RepExprList = new RepExprListRPAREN();
          // Epsilon
          return RepExprList;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repExprList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    


  }
}