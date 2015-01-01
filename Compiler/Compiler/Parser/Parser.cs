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
          var program = new ProgramPROGRAM();
          program.PROGRAM = consume(Terminals.PROGRAM);
          program.IDENT = consume(Terminals.IDENT);
          program.progparamlist = parseprogParamList();
          program.optcpsdecl = parseoptCpsDecl();
          program.DO = consume(Terminals.DO);
          program.cpscmd = parsecpsCmd();
          program.ENDPROGRAM = consume(Terminals.ENDPROGRAM);
          return program;
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
          var decl = new DeclCHANGEMODE();
          decl.stodecl = parsestoDecl();
          return decl;
        }
        
        case Terminals.IDENT:
        {
          var decl = new DeclIDENT();
          decl.stodecl = parsestoDecl();
          return decl;
        }
        
        case Terminals.FUN:
        {
          var decl = new DeclFUN();
          decl.fundecl = parsefunDecl();
          return decl;
        }
        
        case Terminals.PROC:
        {
          var decl = new DeclPROC();
          decl.procdecl = parseprocDecl();
          return decl;
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
          var stodecl = new StoDeclIDENT();
          stodecl.typedident = parsetypedIdent();
          return stodecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var stodecl = new StoDeclCHANGEMODE();
          stodecl.CHANGEMODE = consume(Terminals.CHANGEMODE);
          stodecl.typedident = parsetypedIdent();
          return stodecl;
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
          var fundecl = new FunDeclFUN();
          fundecl.FUN = consume(Terminals.FUN);
          fundecl.IDENT = consume(Terminals.IDENT);
          fundecl.paramlist = parseparamList();
          fundecl.RETURNS = consume(Terminals.RETURNS);
          fundecl.stodecl = parsestoDecl();
          fundecl.optglobimps = parseoptGlobImps();
          fundecl.optcpsstodecl = parseoptCpsStoDecl();
          fundecl.DO = consume(Terminals.DO);
          fundecl.cpscmd = parsecpsCmd();
          fundecl.ENDFUN = consume(Terminals.ENDFUN);
          return fundecl;
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
          var procdecl = new ProcDeclPROC();
          procdecl.PROC = consume(Terminals.PROC);
          procdecl.IDENT = consume(Terminals.IDENT);
          procdecl.paramlist = parseparamList();
          procdecl.optglobimps = parseoptGlobImps();
          procdecl.optcpsstodecl = parseoptCpsStoDecl();
          procdecl.DO = consume(Terminals.DO);
          procdecl.cpscmd = parsecpsCmd();
          procdecl.ENDPROC = consume(Terminals.ENDPROC);
          return procdecl;
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
          var optglobimps = new OptGlobImpsGLOBAL();
          optglobimps.GLOBAL = consume(Terminals.GLOBAL);
          optglobimps.globimps = parseglobImps();
          return optglobimps;
        }
        
        case Terminals.DO:
        {
          var optglobimps = new OptGlobImpsDO();
          // Epsilon
          return optglobimps;
        }
        
        case Terminals.LOCAL:
        {
          var optglobimps = new OptGlobImpsLOCAL();
          // Epsilon
          return optglobimps;
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
          var globimps = new GlobImpsFLOWMODE();
          globimps.globimp = parseglobImp();
          globimps.repglobimps = parserepGlobImps();
          return globimps;
        }
        
        case Terminals.IDENT:
        {
          var globimps = new GlobImpsIDENT();
          globimps.globimp = parseglobImp();
          globimps.repglobimps = parserepGlobImps();
          return globimps;
        }
        
        case Terminals.CHANGEMODE:
        {
          var globimps = new GlobImpsCHANGEMODE();
          globimps.globimp = parseglobImp();
          globimps.repglobimps = parserepGlobImps();
          return globimps;
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
          var repglobimps = new RepGlobImpsCOMMA();
          repglobimps.COMMA = consume(Terminals.COMMA);
          repglobimps.globimp = parseglobImp();
          repglobimps.repglobimps = parserepGlobImps();
          return repglobimps;
        }
        
        case Terminals.DO:
        {
          var repglobimps = new RepGlobImpsDO();
          // Epsilon
          return repglobimps;
        }
        
        case Terminals.LOCAL:
        {
          var repglobimps = new RepGlobImpsLOCAL();
          // Epsilon
          return repglobimps;
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
          var optchangemode = new OptChangemodeCHANGEMODE();
          optchangemode.CHANGEMODE = consume(Terminals.CHANGEMODE);
          return optchangemode;
        }
        
        case Terminals.IDENT:
        {
          var optchangemode = new OptChangemodeIDENT();
          // Epsilon
          return optchangemode;
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
          var optmechmode = new OptMechmodeMECHMODE();
          optmechmode.MECHMODE = consume(Terminals.MECHMODE);
          return optmechmode;
        }
        
        case Terminals.IDENT:
        {
          var optmechmode = new OptMechmodeIDENT();
          // Epsilon
          return optmechmode;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optmechmode = new OptMechmodeCHANGEMODE();
          // Epsilon
          return optmechmode;
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
          var globimp = new GlobImpIDENT();
          globimp.optchangemode = parseoptChangemode();
          globimp.IDENT = consume(Terminals.IDENT);
          return globimp;
        }
        
        case Terminals.CHANGEMODE:
        {
          var globimp = new GlobImpCHANGEMODE();
          globimp.optchangemode = parseoptChangemode();
          globimp.IDENT = consume(Terminals.IDENT);
          return globimp;
        }
        
        case Terminals.FLOWMODE:
        {
          var globimp = new GlobImpFLOWMODE();
          globimp.FLOWMODE = consume(Terminals.FLOWMODE);
          globimp.optchangemode = parseoptChangemode();
          globimp.IDENT = consume(Terminals.IDENT);
          return globimp;
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
          var optcpsdecl = new OptCpsDeclGLOBAL();
          optcpsdecl.GLOBAL = consume(Terminals.GLOBAL);
          optcpsdecl.cpsdecl = parsecpsDecl();
          return optcpsdecl;
        }
        
        case Terminals.DO:
        {
          var optcpsdecl = new OptCpsDeclDO();
          // Epsilon
          return optcpsdecl;
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
          var cpsdecl = new CpsDeclPROC();
          cpsdecl.decl = parsedecl();
          cpsdecl.repcpsdecl = parserepCpsDecl();
          return cpsdecl;
        }
        
        case Terminals.FUN:
        {
          var cpsdecl = new CpsDeclFUN();
          cpsdecl.decl = parsedecl();
          cpsdecl.repcpsdecl = parserepCpsDecl();
          return cpsdecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var cpsdecl = new CpsDeclCHANGEMODE();
          cpsdecl.decl = parsedecl();
          cpsdecl.repcpsdecl = parserepCpsDecl();
          return cpsdecl;
        }
        
        case Terminals.IDENT:
        {
          var cpsdecl = new CpsDeclIDENT();
          cpsdecl.decl = parsedecl();
          cpsdecl.repcpsdecl = parserepCpsDecl();
          return cpsdecl;
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
          var repcpsdecl = new RepCpsDeclSEMICOLON();
          repcpsdecl.SEMICOLON = consume(Terminals.SEMICOLON);
          repcpsdecl.decl = parsedecl();
          repcpsdecl.repcpsdecl = parserepCpsDecl();
          return repcpsdecl;
        }
        
        case Terminals.DO:
        {
          var repcpsdecl = new RepCpsDeclDO();
          // Epsilon
          return repcpsdecl;
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
          var optcpsstodecl = new OptCpsStoDeclLOCAL();
          optcpsstodecl.LOCAL = consume(Terminals.LOCAL);
          optcpsstodecl.cpsstodecl = parsecpsStoDecl();
          return optcpsstodecl;
        }
        
        case Terminals.DO:
        {
          var optcpsstodecl = new OptCpsStoDeclDO();
          // Epsilon
          return optcpsstodecl;
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
          var cpsstodecl = new CpsStoDeclCHANGEMODE();
          cpsstodecl.stodecl = parsestoDecl();
          cpsstodecl.repcpsstodecl = parserepCpsStoDecl();
          return cpsstodecl;
        }
        
        case Terminals.IDENT:
        {
          var cpsstodecl = new CpsStoDeclIDENT();
          cpsstodecl.stodecl = parsestoDecl();
          cpsstodecl.repcpsstodecl = parserepCpsStoDecl();
          return cpsstodecl;
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
          var repcpsstodecl = new RepCpsStoDeclSEMICOLON();
          repcpsstodecl.SEMICOLON = consume(Terminals.SEMICOLON);
          repcpsstodecl.stodecl = parsestoDecl();
          repcpsstodecl.repcpsstodecl = parserepCpsStoDecl();
          return repcpsstodecl;
        }
        
        case Terminals.DO:
        {
          var repcpsstodecl = new RepCpsStoDeclDO();
          // Epsilon
          return repcpsstodecl;
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
          var progparamlist = new ProgParamListLPAREN();
          progparamlist.LPAREN = consume(Terminals.LPAREN);
          progparamlist.optprogparamlist = parseoptProgParamList();
          progparamlist.RPAREN = consume(Terminals.RPAREN);
          return progparamlist;
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
          var optprogparamlist = new OptProgParamListFLOWMODE();
          optprogparamlist.progparam = parseprogParam();
          optprogparamlist.repprogparamlist = parserepProgParamList();
          return optprogparamlist;
        }
        
        case Terminals.IDENT:
        {
          var optprogparamlist = new OptProgParamListIDENT();
          optprogparamlist.progparam = parseprogParam();
          optprogparamlist.repprogparamlist = parserepProgParamList();
          return optprogparamlist;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optprogparamlist = new OptProgParamListCHANGEMODE();
          optprogparamlist.progparam = parseprogParam();
          optprogparamlist.repprogparamlist = parserepProgParamList();
          return optprogparamlist;
        }
        
        case Terminals.RPAREN:
        {
          var optprogparamlist = new OptProgParamListRPAREN();
          // Epsilon
          return optprogparamlist;
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
          var repprogparamlist = new RepProgParamListCOMMA();
          repprogparamlist.COMMA = consume(Terminals.COMMA);
          repprogparamlist.progparam = parseprogParam();
          repprogparamlist.repprogparamlist = parserepProgParamList();
          return repprogparamlist;
        }
        
        case Terminals.RPAREN:
        {
          var repprogparamlist = new RepProgParamListRPAREN();
          // Epsilon
          return repprogparamlist;
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
          var progparam = new ProgParamIDENT();
          progparam.optchangemode = parseoptChangemode();
          progparam.typedident = parsetypedIdent();
          return progparam;
        }
        
        case Terminals.CHANGEMODE:
        {
          var progparam = new ProgParamCHANGEMODE();
          progparam.optchangemode = parseoptChangemode();
          progparam.typedident = parsetypedIdent();
          return progparam;
        }
        
        case Terminals.FLOWMODE:
        {
          var progparam = new ProgParamFLOWMODE();
          progparam.FLOWMODE = consume(Terminals.FLOWMODE);
          progparam.optchangemode = parseoptChangemode();
          progparam.typedident = parsetypedIdent();
          return progparam;
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
          var paramlist = new ParamListLPAREN();
          paramlist.LPAREN = consume(Terminals.LPAREN);
          paramlist.optparamlist = parseoptParamList();
          paramlist.RPAREN = consume(Terminals.RPAREN);
          return paramlist;
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
          var optparamlist = new OptParamListFLOWMODE();
          optparamlist.param = parseparam();
          optparamlist.repparamlist = parserepParamList();
          return optparamlist;
        }
        
        case Terminals.IDENT:
        {
          var optparamlist = new OptParamListIDENT();
          optparamlist.param = parseparam();
          optparamlist.repparamlist = parserepParamList();
          return optparamlist;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optparamlist = new OptParamListCHANGEMODE();
          optparamlist.param = parseparam();
          optparamlist.repparamlist = parserepParamList();
          return optparamlist;
        }
        
        case Terminals.MECHMODE:
        {
          var optparamlist = new OptParamListMECHMODE();
          optparamlist.param = parseparam();
          optparamlist.repparamlist = parserepParamList();
          return optparamlist;
        }
        
        case Terminals.RPAREN:
        {
          var optparamlist = new OptParamListRPAREN();
          // Epsilon
          return optparamlist;
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
          var repparamlist = new RepParamListCOMMA();
          repparamlist.COMMA = consume(Terminals.COMMA);
          repparamlist.param = parseparam();
          repparamlist.repparamlist = parserepParamList();
          return repparamlist;
        }
        
        case Terminals.RPAREN:
        {
          var repparamlist = new RepParamListRPAREN();
          // Epsilon
          return repparamlist;
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
          var param = new ParamIDENT();
          param.optmechmode = parseoptMechmode();
          param.optchangemode = parseoptChangemode();
          param.typedident = parsetypedIdent();
          return param;
        }
        
        case Terminals.CHANGEMODE:
        {
          var param = new ParamCHANGEMODE();
          param.optmechmode = parseoptMechmode();
          param.optchangemode = parseoptChangemode();
          param.typedident = parsetypedIdent();
          return param;
        }
        
        case Terminals.MECHMODE:
        {
          var param = new ParamMECHMODE();
          param.optmechmode = parseoptMechmode();
          param.optchangemode = parseoptChangemode();
          param.typedident = parsetypedIdent();
          return param;
        }
        
        case Terminals.FLOWMODE:
        {
          var param = new ParamFLOWMODE();
          param.FLOWMODE = consume(Terminals.FLOWMODE);
          param.optmechmode = parseoptMechmode();
          param.optchangemode = parseoptChangemode();
          param.typedident = parsetypedIdent();
          return param;
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
          var typedident = new TypedIdentIDENT();
          typedident.IDENT = consume(Terminals.IDENT);
          typedident.COLON = consume(Terminals.COLON);
          typedident.typeorarray = parsetypeOrArray();
          return typedident;
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
          var typeorarray = new TypeOrArrayTYPE();
          typeorarray.TYPE = consume(Terminals.TYPE);
          return typeorarray;
        }
        
        case Terminals.ARRAY:
        {
          var typeorarray = new TypeOrArrayARRAY();
          typeorarray.ARRAY = consume(Terminals.ARRAY);
          typeorarray.LPAREN = consume(Terminals.LPAREN);
          typeorarray.expr = parseexpr();
          typeorarray.reparraylength = parserepArrayLength();
          typeorarray.RPAREN = consume(Terminals.RPAREN);
          typeorarray.TYPE = consume(Terminals.TYPE);
          return typeorarray;
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
          var reparraylength = new RepArrayLengthRPAREN();
          // Epsilon
          return reparraylength;
        }
        
        case Terminals.COMMA:
        {
          var reparraylength = new RepArrayLengthCOMMA();
          reparraylength.COMMA = consume(Terminals.COMMA);
          reparraylength.expr = parseexpr();
          reparraylength.reparraylength = parserepArrayLength();
          return reparraylength;
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
          var cmd = new CmdSKIP();
          cmd.SKIP = consume(Terminals.SKIP);
          return cmd;
        }
        
        case Terminals.TYPE:
        {
          var cmd = new CmdTYPE();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.LPAREN:
        {
          var cmd = new CmdLPAREN();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.ADDOPR:
        {
          var cmd = new CmdADDOPR();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.NOT:
        {
          var cmd = new CmdNOT();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.IDENT:
        {
          var cmd = new CmdIDENT();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.LBRACKET:
        {
          var cmd = new CmdLBRACKET();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.LITERAL:
        {
          var cmd = new CmdLITERAL();
          cmd.expr = parseexpr();
          cmd.BECOMES = consume(Terminals.BECOMES);
          cmd.optfill = parseoptFill();
          cmd.expr0 = parseexpr();
          return cmd;
        }
        
        case Terminals.IF:
        {
          var cmd = new CmdIF();
          cmd.IF = consume(Terminals.IF);
          cmd.expr = parseexpr();
          cmd.THEN = consume(Terminals.THEN);
          cmd.cpscmd = parsecpsCmd();
          cmd.ELSE = consume(Terminals.ELSE);
          cmd.cpscmd0 = parsecpsCmd();
          cmd.ENDIF = consume(Terminals.ENDIF);
          return cmd;
        }
        
        case Terminals.WHILE:
        {
          var cmd = new CmdWHILE();
          cmd.WHILE = consume(Terminals.WHILE);
          cmd.expr = parseexpr();
          cmd.DO = consume(Terminals.DO);
          cmd.cpscmd = parsecpsCmd();
          cmd.ENDWHILE = consume(Terminals.ENDWHILE);
          return cmd;
        }
        
        case Terminals.CALL:
        {
          var cmd = new CmdCALL();
          cmd.CALL = consume(Terminals.CALL);
          cmd.IDENT = consume(Terminals.IDENT);
          cmd.exprlist = parseexprList();
          cmd.optglobinits = parseoptGlobInits();
          return cmd;
        }
        
        case Terminals.DEBUGIN:
        {
          var cmd = new CmdDEBUGIN();
          cmd.DEBUGIN = consume(Terminals.DEBUGIN);
          cmd.expr = parseexpr();
          return cmd;
        }
        
        case Terminals.DEBUGOUT:
        {
          var cmd = new CmdDEBUGOUT();
          cmd.DEBUGOUT = consume(Terminals.DEBUGOUT);
          cmd.expr = parseexpr();
          return cmd;
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
          var cpscmd = new CpsCmdDEBUGOUT();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.DEBUGIN:
        {
          var cpscmd = new CpsCmdDEBUGIN();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.CALL:
        {
          var cpscmd = new CpsCmdCALL();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.WHILE:
        {
          var cpscmd = new CpsCmdWHILE();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.IF:
        {
          var cpscmd = new CpsCmdIF();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.TYPE:
        {
          var cpscmd = new CpsCmdTYPE();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.LPAREN:
        {
          var cpscmd = new CpsCmdLPAREN();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.ADDOPR:
        {
          var cpscmd = new CpsCmdADDOPR();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.NOT:
        {
          var cpscmd = new CpsCmdNOT();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.IDENT:
        {
          var cpscmd = new CpsCmdIDENT();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.LBRACKET:
        {
          var cpscmd = new CpsCmdLBRACKET();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.LITERAL:
        {
          var cpscmd = new CpsCmdLITERAL();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
        }
        
        case Terminals.SKIP:
        {
          var cpscmd = new CpsCmdSKIP();
          cpscmd.cmd = parsecmd();
          cpscmd.repcpscmd = parserepCpsCmd();
          return cpscmd;
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
          var repcpscmd = new RepCpsCmdSEMICOLON();
          repcpscmd.SEMICOLON = consume(Terminals.SEMICOLON);
          repcpscmd.cmd = parsecmd();
          repcpscmd.repcpscmd = parserepCpsCmd();
          return repcpscmd;
        }
        
        case Terminals.ENDWHILE:
        {
          var repcpscmd = new RepCpsCmdENDWHILE();
          // Epsilon
          return repcpscmd;
        }
        
        case Terminals.ENDIF:
        {
          var repcpscmd = new RepCpsCmdENDIF();
          // Epsilon
          return repcpscmd;
        }
        
        case Terminals.ELSE:
        {
          var repcpscmd = new RepCpsCmdELSE();
          // Epsilon
          return repcpscmd;
        }
        
        case Terminals.ENDPROC:
        {
          var repcpscmd = new RepCpsCmdENDPROC();
          // Epsilon
          return repcpscmd;
        }
        
        case Terminals.ENDFUN:
        {
          var repcpscmd = new RepCpsCmdENDFUN();
          // Epsilon
          return repcpscmd;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repcpscmd = new RepCpsCmdENDPROGRAM();
          // Epsilon
          return repcpscmd;
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
          var optfill = new OptFillTYPE();
          // Epsilon
          return optfill;
        }
        
        case Terminals.LPAREN:
        {
          var optfill = new OptFillLPAREN();
          // Epsilon
          return optfill;
        }
        
        case Terminals.ADDOPR:
        {
          var optfill = new OptFillADDOPR();
          // Epsilon
          return optfill;
        }
        
        case Terminals.NOT:
        {
          var optfill = new OptFillNOT();
          // Epsilon
          return optfill;
        }
        
        case Terminals.IDENT:
        {
          var optfill = new OptFillIDENT();
          // Epsilon
          return optfill;
        }
        
        case Terminals.LBRACKET:
        {
          var optfill = new OptFillLBRACKET();
          // Epsilon
          return optfill;
        }
        
        case Terminals.LITERAL:
        {
          var optfill = new OptFillLITERAL();
          // Epsilon
          return optfill;
        }
        
        case Terminals.FILL:
        {
          var optfill = new OptFillFILL();
          optfill.FILL = consume(Terminals.FILL);
          return optfill;
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
          var optglobinits = new OptGlobInitsINIT();
          optglobinits.INIT = consume(Terminals.INIT);
          optglobinits.IDENT = consume(Terminals.IDENT);
          optglobinits.repidents = parserepIdents();
          return optglobinits;
        }
        
        case Terminals.ENDWHILE:
        {
          var optglobinits = new OptGlobInitsENDWHILE();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.ENDIF:
        {
          var optglobinits = new OptGlobInitsENDIF();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.ELSE:
        {
          var optglobinits = new OptGlobInitsELSE();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.ENDPROC:
        {
          var optglobinits = new OptGlobInitsENDPROC();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.ENDFUN:
        {
          var optglobinits = new OptGlobInitsENDFUN();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var optglobinits = new OptGlobInitsENDPROGRAM();
          // Epsilon
          return optglobinits;
        }
        
        case Terminals.SEMICOLON:
        {
          var optglobinits = new OptGlobInitsSEMICOLON();
          // Epsilon
          return optglobinits;
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
          var repidents = new RepIdentsCOMMA();
          repidents.COMMA = consume(Terminals.COMMA);
          repidents.IDENT = consume(Terminals.IDENT);
          repidents.repidents = parserepIdents();
          return repidents;
        }
        
        case Terminals.ENDWHILE:
        {
          var repidents = new RepIdentsENDWHILE();
          // Epsilon
          return repidents;
        }
        
        case Terminals.ENDIF:
        {
          var repidents = new RepIdentsENDIF();
          // Epsilon
          return repidents;
        }
        
        case Terminals.ELSE:
        {
          var repidents = new RepIdentsELSE();
          // Epsilon
          return repidents;
        }
        
        case Terminals.ENDPROC:
        {
          var repidents = new RepIdentsENDPROC();
          // Epsilon
          return repidents;
        }
        
        case Terminals.ENDFUN:
        {
          var repidents = new RepIdentsENDFUN();
          // Epsilon
          return repidents;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repidents = new RepIdentsENDPROGRAM();
          // Epsilon
          return repidents;
        }
        
        case Terminals.SEMICOLON:
        {
          var repidents = new RepIdentsSEMICOLON();
          // Epsilon
          return repidents;
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
          var expr = new ExprTYPE();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.LPAREN:
        {
          var expr = new ExprLPAREN();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.ADDOPR:
        {
          var expr = new ExprADDOPR();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.NOT:
        {
          var expr = new ExprNOT();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.IDENT:
        {
          var expr = new ExprIDENT();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.LBRACKET:
        {
          var expr = new ExprLBRACKET();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
        }
        
        case Terminals.LITERAL:
        {
          var expr = new ExprLITERAL();
          expr.term1 = parseterm1();
          expr.repterm1 = parserepTerm1();
          return expr;
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
          var repterm1 = new RepTerm1BOOLOPR();
          repterm1.BOOLOPR = consume(Terminals.BOOLOPR);
          repterm1.term1 = parseterm1();
          repterm1.repterm1 = parserepTerm1();
          return repterm1;
        }
        
        case Terminals.RBRACKET:
        {
          var repterm1 = new RepTerm1RBRACKET();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.RANGE:
        {
          var repterm1 = new RepTerm1RANGE();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.DO:
        {
          var repterm1 = new RepTerm1DO();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.THEN:
        {
          var repterm1 = new RepTerm1THEN();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm1 = new RepTerm1ENDWHILE();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ENDIF:
        {
          var repterm1 = new RepTerm1ENDIF();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ELSE:
        {
          var repterm1 = new RepTerm1ELSE();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm1 = new RepTerm1ENDPROC();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm1 = new RepTerm1ENDFUN();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm1 = new RepTerm1ENDPROGRAM();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm1 = new RepTerm1SEMICOLON();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.BECOMES:
        {
          var repterm1 = new RepTerm1BECOMES();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.RPAREN:
        {
          var repterm1 = new RepTerm1RPAREN();
          // Epsilon
          return repterm1;
        }
        
        case Terminals.COMMA:
        {
          var repterm1 = new RepTerm1COMMA();
          // Epsilon
          return repterm1;
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
          var term1 = new Term1TYPE();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.LPAREN:
        {
          var term1 = new Term1LPAREN();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.ADDOPR:
        {
          var term1 = new Term1ADDOPR();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.NOT:
        {
          var term1 = new Term1NOT();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.IDENT:
        {
          var term1 = new Term1IDENT();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.LBRACKET:
        {
          var term1 = new Term1LBRACKET();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
        }
        
        case Terminals.LITERAL:
        {
          var term1 = new Term1LITERAL();
          term1.term2 = parseterm2();
          term1.repterm2 = parserepTerm2();
          return term1;
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
          var repterm2 = new RepTerm2RELOPR();
          repterm2.RELOPR = consume(Terminals.RELOPR);
          repterm2.term2 = parseterm2();
          repterm2.repterm2 = parserepTerm2();
          return repterm2;
        }
        
        case Terminals.RBRACKET:
        {
          var repterm2 = new RepTerm2RBRACKET();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.RANGE:
        {
          var repterm2 = new RepTerm2RANGE();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.DO:
        {
          var repterm2 = new RepTerm2DO();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.THEN:
        {
          var repterm2 = new RepTerm2THEN();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm2 = new RepTerm2ENDWHILE();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ENDIF:
        {
          var repterm2 = new RepTerm2ENDIF();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ELSE:
        {
          var repterm2 = new RepTerm2ELSE();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm2 = new RepTerm2ENDPROC();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm2 = new RepTerm2ENDFUN();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm2 = new RepTerm2ENDPROGRAM();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm2 = new RepTerm2SEMICOLON();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.BECOMES:
        {
          var repterm2 = new RepTerm2BECOMES();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.RPAREN:
        {
          var repterm2 = new RepTerm2RPAREN();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.COMMA:
        {
          var repterm2 = new RepTerm2COMMA();
          // Epsilon
          return repterm2;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm2 = new RepTerm2BOOLOPR();
          // Epsilon
          return repterm2;
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
          var term2 = new Term2TYPE();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.LPAREN:
        {
          var term2 = new Term2LPAREN();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.ADDOPR:
        {
          var term2 = new Term2ADDOPR();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.NOT:
        {
          var term2 = new Term2NOT();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.IDENT:
        {
          var term2 = new Term2IDENT();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.LBRACKET:
        {
          var term2 = new Term2LBRACKET();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
        }
        
        case Terminals.LITERAL:
        {
          var term2 = new Term2LITERAL();
          term2.term3 = parseterm3();
          term2.repterm3 = parserepTerm3();
          return term2;
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
          var repterm3 = new RepTerm3ADDOPR();
          repterm3.ADDOPR = consume(Terminals.ADDOPR);
          repterm3.term3 = parseterm3();
          repterm3.repterm3 = parserepTerm3();
          return repterm3;
        }
        
        case Terminals.RBRACKET:
        {
          var repterm3 = new RepTerm3RBRACKET();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.RANGE:
        {
          var repterm3 = new RepTerm3RANGE();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.DO:
        {
          var repterm3 = new RepTerm3DO();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.THEN:
        {
          var repterm3 = new RepTerm3THEN();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm3 = new RepTerm3ENDWHILE();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ENDIF:
        {
          var repterm3 = new RepTerm3ENDIF();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ELSE:
        {
          var repterm3 = new RepTerm3ELSE();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm3 = new RepTerm3ENDPROC();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm3 = new RepTerm3ENDFUN();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm3 = new RepTerm3ENDPROGRAM();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm3 = new RepTerm3SEMICOLON();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.BECOMES:
        {
          var repterm3 = new RepTerm3BECOMES();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.RPAREN:
        {
          var repterm3 = new RepTerm3RPAREN();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.COMMA:
        {
          var repterm3 = new RepTerm3COMMA();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm3 = new RepTerm3BOOLOPR();
          // Epsilon
          return repterm3;
        }
        
        case Terminals.RELOPR:
        {
          var repterm3 = new RepTerm3RELOPR();
          // Epsilon
          return repterm3;
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
          var term3 = new Term3TYPE();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.LPAREN:
        {
          var term3 = new Term3LPAREN();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.ADDOPR:
        {
          var term3 = new Term3ADDOPR();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.NOT:
        {
          var term3 = new Term3NOT();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.IDENT:
        {
          var term3 = new Term3IDENT();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.LBRACKET:
        {
          var term3 = new Term3LBRACKET();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
        }
        
        case Terminals.LITERAL:
        {
          var term3 = new Term3LITERAL();
          term3.factor = parsefactor();
          term3.repfactor = parserepFactor();
          return term3;
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
          var repfactor = new RepFactorMULTOPR();
          repfactor.MULTOPR = consume(Terminals.MULTOPR);
          repfactor.factor = parsefactor();
          repfactor.repfactor = parserepFactor();
          return repfactor;
        }
        
        case Terminals.RBRACKET:
        {
          var repfactor = new RepFactorRBRACKET();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.RANGE:
        {
          var repfactor = new RepFactorRANGE();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.DO:
        {
          var repfactor = new RepFactorDO();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.THEN:
        {
          var repfactor = new RepFactorTHEN();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ENDWHILE:
        {
          var repfactor = new RepFactorENDWHILE();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ENDIF:
        {
          var repfactor = new RepFactorENDIF();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ELSE:
        {
          var repfactor = new RepFactorELSE();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ENDPROC:
        {
          var repfactor = new RepFactorENDPROC();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ENDFUN:
        {
          var repfactor = new RepFactorENDFUN();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repfactor = new RepFactorENDPROGRAM();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.SEMICOLON:
        {
          var repfactor = new RepFactorSEMICOLON();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.BECOMES:
        {
          var repfactor = new RepFactorBECOMES();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.RPAREN:
        {
          var repfactor = new RepFactorRPAREN();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.COMMA:
        {
          var repfactor = new RepFactorCOMMA();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.BOOLOPR:
        {
          var repfactor = new RepFactorBOOLOPR();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.RELOPR:
        {
          var repfactor = new RepFactorRELOPR();
          // Epsilon
          return repfactor;
        }
        
        case Terminals.ADDOPR:
        {
          var repfactor = new RepFactorADDOPR();
          // Epsilon
          return repfactor;
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
          var factor = new FactorLITERAL();
          factor.LITERAL = consume(Terminals.LITERAL);
          return factor;
        }
        
        case Terminals.LBRACKET:
        {
          var factor = new FactorLBRACKET();
          factor.arrayliteral = parsearrayLiteral();
          return factor;
        }
        
        case Terminals.IDENT:
        {
          var factor = new FactorIDENT();
          factor.IDENT = consume(Terminals.IDENT);
          factor.optinitorexprlistorarrayaccess = parseoptInitOrExprListOrArrayAccess();
          return factor;
        }
        
        case Terminals.ADDOPR:
        {
          var factor = new FactorADDOPR();
          factor.monadicopr = parsemonadicOpr();
          factor.factor = parsefactor();
          return factor;
        }
        
        case Terminals.NOT:
        {
          var factor = new FactorNOT();
          factor.monadicopr = parsemonadicOpr();
          factor.factor = parsefactor();
          return factor;
        }
        
        case Terminals.LPAREN:
        {
          var factor = new FactorLPAREN();
          factor.LPAREN = consume(Terminals.LPAREN);
          factor.expr = parseexpr();
          factor.RPAREN = consume(Terminals.RPAREN);
          return factor;
        }
        
        case Terminals.TYPE:
        {
          var factor = new FactorTYPE();
          factor.TYPE = consume(Terminals.TYPE);
          factor.LPAREN = consume(Terminals.LPAREN);
          factor.expr = parseexpr();
          factor.RPAREN = consume(Terminals.RPAREN);
          return factor;
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
          var arrayliteral = new ArrayLiteralLBRACKET();
          arrayliteral.LBRACKET = consume(Terminals.LBRACKET);
          arrayliteral.arraycontent = parsearrayContent();
          arrayliteral.RBRACKET = consume(Terminals.RBRACKET);
          return arrayliteral;
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
          var arraycontent = new ArrayContentLITERAL();
          arraycontent.LITERAL = consume(Terminals.LITERAL);
          arraycontent.repliteral = parserepLiteral();
          return arraycontent;
        }
        
        case Terminals.LBRACKET:
        {
          var arraycontent = new ArrayContentLBRACKET();
          arraycontent.arrayliteral = parsearrayLiteral();
          arraycontent.reparray = parserepArray();
          return arraycontent;
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
          var reparray = new RepArrayRBRACKET();
          // Epsilon
          return reparray;
        }
        
        case Terminals.COMMA:
        {
          var reparray = new RepArrayCOMMA();
          reparray.COMMA = consume(Terminals.COMMA);
          reparray.arrayliteral = parsearrayLiteral();
          reparray.reparray = parserepArray();
          return reparray;
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
          var repliteral = new RepLiteralRBRACKET();
          // Epsilon
          return repliteral;
        }
        
        case Terminals.COMMA:
        {
          var repliteral = new RepLiteralCOMMA();
          repliteral.COMMA = consume(Terminals.COMMA);
          repliteral.LITERAL = consume(Terminals.LITERAL);
          repliteral.repliteral = parserepLiteral();
          return repliteral;
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
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessINIT();
          optinitorexprlistorarrayaccess.INIT = consume(Terminals.INIT);
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.LBRACKET:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessLBRACKET();
          optinitorexprlistorarrayaccess.arrayindex = parsearrayIndex();
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.LPAREN:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessLPAREN();
          optinitorexprlistorarrayaccess.exprlist = parseexprList();
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.RBRACKET:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessRBRACKET();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.RANGE:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessRANGE();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.DO:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessDO();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.THEN:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessTHEN();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ENDWHILE:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessENDWHILE();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ENDIF:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessENDIF();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ELSE:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessELSE();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ENDPROC:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessENDPROC();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ENDFUN:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessENDFUN();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessENDPROGRAM();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.SEMICOLON:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessSEMICOLON();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.BECOMES:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessBECOMES();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.RPAREN:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessRPAREN();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.COMMA:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessCOMMA();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.BOOLOPR:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessBOOLOPR();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.RELOPR:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessRELOPR();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.ADDOPR:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessADDOPR();
          // Epsilon
          return optinitorexprlistorarrayaccess;
        }
        
        case Terminals.MULTOPR:
        {
          var optinitorexprlistorarrayaccess = new OptInitOrExprListOrArrayAccessMULTOPR();
          // Epsilon
          return optinitorexprlistorarrayaccess;
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
          var arrayindex = new ArrayIndexLBRACKET();
          arrayindex.LBRACKET = consume(Terminals.LBRACKET);
          arrayindex.sliceexpr = parsesliceExpr();
          arrayindex.RBRACKET = consume(Terminals.RBRACKET);
          arrayindex.reparrayindex = parserepArrayIndex();
          return arrayindex;
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
          var sliceexpr = new SliceExprTYPE();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.LPAREN:
        {
          var sliceexpr = new SliceExprLPAREN();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.ADDOPR:
        {
          var sliceexpr = new SliceExprADDOPR();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.NOT:
        {
          var sliceexpr = new SliceExprNOT();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.IDENT:
        {
          var sliceexpr = new SliceExprIDENT();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.LBRACKET:
        {
          var sliceexpr = new SliceExprLBRACKET();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
        }
        
        case Terminals.LITERAL:
        {
          var sliceexpr = new SliceExprLITERAL();
          sliceexpr.expr = parseexpr();
          sliceexpr.repsliceexpr = parserepSliceExpr();
          return sliceexpr;
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
          var repsliceexpr = new RepSliceExprRBRACKET();
          // Epsilon
          return repsliceexpr;
        }
        
        case Terminals.RANGE:
        {
          var repsliceexpr = new RepSliceExprRANGE();
          repsliceexpr.RANGE = consume(Terminals.RANGE);
          repsliceexpr.expr = parseexpr();
          return repsliceexpr;
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
          var reparrayindex = new RepArrayIndexRBRACKET();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.RANGE:
        {
          var reparrayindex = new RepArrayIndexRANGE();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.DO:
        {
          var reparrayindex = new RepArrayIndexDO();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.THEN:
        {
          var reparrayindex = new RepArrayIndexTHEN();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ENDWHILE:
        {
          var reparrayindex = new RepArrayIndexENDWHILE();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ENDIF:
        {
          var reparrayindex = new RepArrayIndexENDIF();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ELSE:
        {
          var reparrayindex = new RepArrayIndexELSE();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ENDPROC:
        {
          var reparrayindex = new RepArrayIndexENDPROC();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ENDFUN:
        {
          var reparrayindex = new RepArrayIndexENDFUN();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var reparrayindex = new RepArrayIndexENDPROGRAM();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.SEMICOLON:
        {
          var reparrayindex = new RepArrayIndexSEMICOLON();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.BECOMES:
        {
          var reparrayindex = new RepArrayIndexBECOMES();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.RPAREN:
        {
          var reparrayindex = new RepArrayIndexRPAREN();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.COMMA:
        {
          var reparrayindex = new RepArrayIndexCOMMA();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.BOOLOPR:
        {
          var reparrayindex = new RepArrayIndexBOOLOPR();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.RELOPR:
        {
          var reparrayindex = new RepArrayIndexRELOPR();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.ADDOPR:
        {
          var reparrayindex = new RepArrayIndexADDOPR();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.MULTOPR:
        {
          var reparrayindex = new RepArrayIndexMULTOPR();
          // Epsilon
          return reparrayindex;
        }
        
        case Terminals.LBRACKET:
        {
          var reparrayindex = new RepArrayIndexLBRACKET();
          reparrayindex.arrayindex = parsearrayIndex();
          return reparrayindex;
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
          var monadicopr = new MonadicOprNOT();
          monadicopr.NOT = consume(Terminals.NOT);
          return monadicopr;
        }
        
        case Terminals.ADDOPR:
        {
          var monadicopr = new MonadicOprADDOPR();
          monadicopr.ADDOPR = consume(Terminals.ADDOPR);
          return monadicopr;
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
          var exprlist = new ExprListLPAREN();
          exprlist.LPAREN = consume(Terminals.LPAREN);
          exprlist.optexprlist = parseoptExprList();
          exprlist.RPAREN = consume(Terminals.RPAREN);
          return exprlist;
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
          var optexprlist = new OptExprListTYPE();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.LPAREN:
        {
          var optexprlist = new OptExprListLPAREN();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.ADDOPR:
        {
          var optexprlist = new OptExprListADDOPR();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.NOT:
        {
          var optexprlist = new OptExprListNOT();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.IDENT:
        {
          var optexprlist = new OptExprListIDENT();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.LBRACKET:
        {
          var optexprlist = new OptExprListLBRACKET();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.LITERAL:
        {
          var optexprlist = new OptExprListLITERAL();
          optexprlist.expr = parseexpr();
          optexprlist.repexprlist = parserepExprList();
          return optexprlist;
        }
        
        case Terminals.RPAREN:
        {
          var optexprlist = new OptExprListRPAREN();
          // Epsilon
          return optexprlist;
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
          var repexprlist = new RepExprListCOMMA();
          repexprlist.COMMA = consume(Terminals.COMMA);
          repexprlist.expr = parseexpr();
          repexprlist.repexprlist = parserepExprList();
          return repexprlist;
        }
        
        case Terminals.RPAREN:
        {
          var repexprlist = new RepExprListRPAREN();
          // Epsilon
          return repexprlist;
        }
        default:
          throw new GrammarException(String.Format("found Terminal '{0}' in Nonterminal 'repExprList' unexpectedly.", terminal.ToString()), token.Row, token.Column);
      }
    }
    


  }
}