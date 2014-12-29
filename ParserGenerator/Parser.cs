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

    private Token consume(Terminals expectedTerminal)
    {
      if (terminal == expectedTerminal) {
        Token consumedToken = token;
        if (terminal != Terminals.SENTINEL) {
          tokens.MoveNext();
          token = tokens.Current;
          // maintain class invariant
          terminal = token.Terminal;
        }
        return consumedToken;
      }
      else {
        throw new GrammarError("terminal expected: " + expectedTerminal +
          ", terminal found: " + terminal);
      }
    }

    
    public IoptModeFlow parseoptModeFlow()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var optmodeflow = new OptModeFlowIdent();
          
          // Epsilon
        
          return optmodeflow;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optmodeflow = new OptModeFlowChangemode();
          
          // Epsilon
        
          return optmodeflow;
        }
        
        case Terminals.MECHMODE:
        {
          var optmodeflow = new OptModeFlowMechmode();
          
          // Epsilon
        
          return optmodeflow;
        }
        
        case Terminals.FLOWMODE:
        {
          var optmodeflow = new OptModeFlowFlowmode();
          
          program.Ident = consume(Terminals.IDENT);
        
          return optmodeflow;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IcpsDecl parsecpsDecl()
    {
      switch (terminal) {
        case Terminals.DO:
        {
          var cpsdecl = new CpsDeclDo();
          
          // Epsilon
        
          return cpsdecl;
        }
        
        case Terminals.PROC:
        {
          var cpsdecl = new CpsDeclProc();
          
          program.decl = parsedecl();
        
          program.repCpsDecl = parserepCpsDecl();
        
          return cpsdecl;
        }
        
        case Terminals.FUN:
        {
          var cpsdecl = new CpsDeclFun();
          
          program.decl = parsedecl();
        
          program.repCpsDecl = parserepCpsDecl();
        
          return cpsdecl;
        }
        
        case Terminals.IDENT:
        {
          var cpsdecl = new CpsDeclIdent();
          
          program.decl = parsedecl();
        
          program.repCpsDecl = parserepCpsDecl();
        
          return cpsdecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var cpsdecl = new CpsDeclChangemode();
          
          program.decl = parsedecl();
        
          program.repCpsDecl = parserepCpsDecl();
        
          return cpsdecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepCpsDecl parserepCpsDecl()
    {
      switch (terminal) {
        case Terminals.DO:
        {
          var repcpsdecl = new RepCpsDeclDo();
          
          // Epsilon
        
          return repcpsdecl;
        }
        
        case Terminals.SEMICOLON:
        {
          var repcpsdecl = new RepCpsDeclSemicolon();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.cpsDecl = parsecpsDecl();
        
          return repcpsdecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Icmd parsecmd()
    {
      switch (terminal) {
        case Terminals.SKIP:
        {
          var cmd = new CmdSkip();
          
          program.Ident = consume(Terminals.IDENT);
        
          return cmd;
        }
        
        case Terminals.LPAREN:
        {
          var cmd = new CmdLparen();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.IDENT:
        {
          var cmd = new CmdIdent();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.ADDOPR:
        {
          var cmd = new CmdAddopr();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.NOT:
        {
          var cmd = new CmdNot();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.LBRACKET:
        {
          var cmd = new CmdLbracket();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.LITERAL:
        {
          var cmd = new CmdLiteral();
          
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.optFill = parseoptFill();
        
          program.expr0 = parseexpr0();
        
          return cmd;
        }
        
        case Terminals.IF:
        {
          var cmd = new CmdIf();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.blockCmd = parseblockCmd();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.blockCmd0 = parseblockCmd0();
        
          return cmd;
        }
        
        case Terminals.WHILE:
        {
          var cmd = new CmdWhile();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.blockCmd = parseblockCmd();
        
          return cmd;
        }
        
        case Terminals.CALL:
        {
          var cmd = new CmdCall();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.exprList = parseexprList();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.globInitList = parseglobInitList();
        
          return cmd;
        }
        
        case Terminals.DEBUGIN:
        {
          var cmd = new CmdDebugin();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          return cmd;
        }
        
        case Terminals.DEBUGOUT:
        {
          var cmd = new CmdDebugout();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          return cmd;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptFill parseoptFill()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var optfill = new OptFillLparen();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.IDENT:
        {
          var optfill = new OptFillIdent();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.ADDOPR:
        {
          var optfill = new OptFillAddopr();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.NOT:
        {
          var optfill = new OptFillNot();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.LBRACKET:
        {
          var optfill = new OptFillLbracket();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.LITERAL:
        {
          var optfill = new OptFillLiteral();
          
          // Epsilon
        
          return optfill;
        }
        
        case Terminals.FILL:
        {
          var optfill = new OptFillFill();
          
          program.Ident = consume(Terminals.IDENT);
        
          return optfill;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepParam parserepParam()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var repparam = new RepParamRparen();
          
          // Epsilon
        
          return repparam;
        }
        
        case Terminals.COMMA:
        {
          var repparam = new RepParamComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.param = parseparam();
        
          return repparam;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IglobInitList parseglobInitList()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var globinitlist = new GlobInitListIdent();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.repGlobInit = parserepGlobInit();
        
          return globinitlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepGlobInit parserepGlobInit()
    {
      switch (terminal) {
        case Terminals.ENDIF:
        {
          var repglobinit = new RepGlobInitEndif();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.ENDPROC:
        {
          var repglobinit = new RepGlobInitEndproc();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.ENDFUN:
        {
          var repglobinit = new RepGlobInitEndfun();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.ENDWHILE:
        {
          var repglobinit = new RepGlobInitEndwhile();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repglobinit = new RepGlobInitEndprogram();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.SEMICOLON:
        {
          var repglobinit = new RepGlobInitSemicolon();
          
          // Epsilon
        
          return repglobinit;
        }
        
        case Terminals.COMMA:
        {
          var repglobinit = new RepGlobInitComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.repGlobInit = parserepGlobInit();
        
          return repglobinit;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iparam parseparam()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var param = new ParamIdent();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeMech = parseoptModeMech();
        
          program.storeDecl = parsestoreDecl();
        
          program.repParam = parserepParam();
        
          return param;
        }
        
        case Terminals.CHANGEMODE:
        {
          var param = new ParamChangemode();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeMech = parseoptModeMech();
        
          program.storeDecl = parsestoreDecl();
        
          program.repParam = parserepParam();
        
          return param;
        }
        
        case Terminals.MECHMODE:
        {
          var param = new ParamMechmode();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeMech = parseoptModeMech();
        
          program.storeDecl = parsestoreDecl();
        
          program.repParam = parserepParam();
        
          return param;
        }
        
        case Terminals.FLOWMODE:
        {
          var param = new ParamFlowmode();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeMech = parseoptModeMech();
        
          program.storeDecl = parsestoreDecl();
        
          program.repParam = parserepParam();
        
          return param;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iprogram parseprogram()
    {
      switch (terminal) {
        case Terminals.PROGRAM:
        {
          var program = new ProgramProgram();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.progParamList = parseprogParamList();
        
          program.optGlobCpsDecl = parseoptGlobCpsDecl();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.cmd = parsecmd();
        
          program.repCmd = parserepCmd();
        
          program.Ident = consume(Terminals.IDENT);
        
          return program;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IprogParamList parseprogParamList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var progparamlist = new ProgParamListLparen();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.progParams = parseprogParams();
        
          program.Ident = consume(Terminals.IDENT);
        
          return progparamlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IprogParams parseprogParams()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var progparams = new ProgParamsRparen();
          
          // Epsilon
        
          return progparams;
        }
        
        case Terminals.FLOWMODE:
        {
          var progparams = new ProgParamsFlowmode();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.typedident = parsetypedident();
        
          program.repProgParams = parserepProgParams();
        
          return progparams;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepProgParams parserepProgParams()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var repprogparams = new RepProgParamsRparen();
          
          // Epsilon
        
          return repprogparams;
        }
        
        case Terminals.COMMA:
        {
          var repprogparams = new RepProgParamsComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.progParams = parseprogParams();
        
          return repprogparams;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Itypedident parsetypedident()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var typedident = new TypedidentIdent();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.typeOrArray = parsetypeOrArray();
        
          return typedident;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public ItypeOrArray parsetypeOrArray()
    {
      switch (terminal) {
        case Terminals.TYPE:
        {
          var typeorarray = new TypeOrArrayType();
          
          program.Ident = consume(Terminals.IDENT);
        
          return typeorarray;
        }
        
        case Terminals.ARRAY:
        {
          var typeorarray = new TypeOrArrayArray();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          program.repArrayLength = parserepArrayLength();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          return typeorarray;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepArrayLength parserepArrayLength()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var reparraylength = new RepArrayLengthRparen();
          
          // Epsilon
        
          return reparraylength;
        }
        
        case Terminals.COMMA:
        {
          var reparraylength = new RepArrayLengthComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          return reparraylength;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public ImonadicOpr parsemonadicOpr()
    {
      switch (terminal) {
        case Terminals.NOT:
        {
          var monadicopr = new MonadicOprNot();
          
          program.Ident = consume(Terminals.IDENT);
        
          return monadicopr;
        }
        
        case Terminals.ADDOPR:
        {
          var monadicopr = new MonadicOprAddopr();
          
          program.Ident = consume(Terminals.IDENT);
        
          return monadicopr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Idecl parsedecl()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var decl = new DeclIdent();
          
          program.storeDecl = parsestoreDecl();
        
          return decl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var decl = new DeclChangemode();
          
          program.storeDecl = parsestoreDecl();
        
          return decl;
        }
        
        case Terminals.FUN:
        {
          var decl = new DeclFun();
          
          program.funDecl = parsefunDecl();
        
          return decl;
        }
        
        case Terminals.PROC:
        {
          var decl = new DeclProc();
          
          program.procDecl = parseprocDecl();
        
          return decl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IprocDecl parseprocDecl()
    {
      switch (terminal) {
        case Terminals.PROC:
        {
          var procdecl = new ProcDeclProc();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.paramList = parseparamList();
        
          program.optGlobImportList = parseoptGlobImportList();
        
          program.optCpsStoDecl = parseoptCpsStoDecl();
        
          program.blockCmd = parseblockCmd();
        
          return procdecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IstoreDecl parsestoreDecl()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var storedecl = new StoreDeclIdent();
          
          program.optModeChange = parseoptModeChange();
        
          program.typedident = parsetypedident();
        
          return storedecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var storedecl = new StoreDeclChangemode();
          
          program.optModeChange = parseoptModeChange();
        
          program.typedident = parsetypedident();
        
          return storedecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IfunDecl parsefunDecl()
    {
      switch (terminal) {
        case Terminals.FUN:
        {
          var fundecl = new FunDeclFun();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.paramList = parseparamList();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.storeDecl = parsestoreDecl();
        
          program.optGlobImportList = parseoptGlobImportList();
        
          program.optCpsStoDecl = parseoptCpsStoDecl();
        
          program.blockCmd = parseblockCmd();
        
          return fundecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptCpsStoDecl parseoptCpsStoDecl()
    {
      switch (terminal) {
        case Terminals.LOCAL:
        {
          var optcpsstodecl = new OptCpsStoDeclLocal();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.cpsStoDecl = parsecpsStoDecl();
        
          return optcpsstodecl;
        }
        
        case Terminals.DO:
        {
          var optcpsstodecl = new OptCpsStoDeclDo();
          
          // Epsilon
        
          return optcpsstodecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IcpsStoDecl parsecpsStoDecl()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var cpsstodecl = new CpsStoDeclIdent();
          
          program.storeDecl = parsestoreDecl();
        
          program.repCpsStoDecl = parserepCpsStoDecl();
        
          return cpsstodecl;
        }
        
        case Terminals.CHANGEMODE:
        {
          var cpsstodecl = new CpsStoDeclChangemode();
          
          program.storeDecl = parsestoreDecl();
        
          program.repCpsStoDecl = parserepCpsStoDecl();
        
          return cpsstodecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepCpsStoDecl parserepCpsStoDecl()
    {
      switch (terminal) {
        case Terminals.SEMICOLON:
        {
          var repcpsstodecl = new RepCpsStoDeclSemicolon();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.storeDecl = parsestoreDecl();
        
          program.repCpsStoDecl = parserepCpsStoDecl();
        
          return repcpsstodecl;
        }
        
        case Terminals.DO:
        {
          var repcpsstodecl = new RepCpsStoDeclDo();
          
          // Epsilon
        
          return repcpsstodecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptGlobCpsDecl parseoptGlobCpsDecl()
    {
      switch (terminal) {
        case Terminals.GLOBAL:
        {
          var optglobcpsdecl = new OptGlobCpsDeclGlobal();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.cpsDecl = parsecpsDecl();
        
          return optglobcpsdecl;
        }
        
        case Terminals.DO:
        {
          var optglobcpsdecl = new OptGlobCpsDeclDo();
          
          // Epsilon
        
          return optglobcpsdecl;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IparamList parseparamList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var paramlist = new ParamListLparen();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.param = parseparam();
        
          program.Ident = consume(Terminals.IDENT);
        
          return paramlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepCmd parserepCmd()
    {
      switch (terminal) {
        case Terminals.ENDIF:
        {
          var repcmd = new RepCmdEndif();
          
          // Epsilon
        
          return repcmd;
        }
        
        case Terminals.ENDPROC:
        {
          var repcmd = new RepCmdEndproc();
          
          // Epsilon
        
          return repcmd;
        }
        
        case Terminals.ENDFUN:
        {
          var repcmd = new RepCmdEndfun();
          
          // Epsilon
        
          return repcmd;
        }
        
        case Terminals.ENDWHILE:
        {
          var repcmd = new RepCmdEndwhile();
          
          // Epsilon
        
          return repcmd;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repcmd = new RepCmdEndprogram();
          
          // Epsilon
        
          return repcmd;
        }
        
        case Terminals.SEMICOLON:
        {
          var repcmd = new RepCmdSemicolon();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.cmd = parsecmd();
        
          program.repCmd = parserepCmd();
        
          return repcmd;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IglobImport parseglobImport()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var globimport = new GlobImportIdent();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeChange = parseoptModeChange();
        
          program.Ident = consume(Terminals.IDENT);
        
          return globimport;
        }
        
        case Terminals.CHANGEMODE:
        {
          var globimport = new GlobImportChangemode();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeChange = parseoptModeChange();
        
          program.Ident = consume(Terminals.IDENT);
        
          return globimport;
        }
        
        case Terminals.FLOWMODE:
        {
          var globimport = new GlobImportFlowmode();
          
          program.optModeFlow = parseoptModeFlow();
        
          program.optModeChange = parseoptModeChange();
        
          program.Ident = consume(Terminals.IDENT);
        
          return globimport;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IglobImportList parseglobImportList()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var globimportlist = new GlobImportListIdent();
          
          program.globImport = parseglobImport();
        
          program.repglobImport = parserepglobImport();
        
          return globimportlist;
        }
        
        case Terminals.CHANGEMODE:
        {
          var globimportlist = new GlobImportListChangemode();
          
          program.globImport = parseglobImport();
        
          program.repglobImport = parserepglobImport();
        
          return globimportlist;
        }
        
        case Terminals.FLOWMODE:
        {
          var globimportlist = new GlobImportListFlowmode();
          
          program.globImport = parseglobImport();
        
          program.repglobImport = parserepglobImport();
        
          return globimportlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepglobImport parserepglobImport()
    {
      switch (terminal) {
        case Terminals.DO:
        {
          var repglobimport = new RepglobImportDo();
          
          // Epsilon
        
          return repglobimport;
        }
        
        case Terminals.LOCAL:
        {
          var repglobimport = new RepglobImportLocal();
          
          // Epsilon
        
          return repglobimport;
        }
        
        case Terminals.COMMA:
        {
          var repglobimport = new RepglobImportComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.globImport = parseglobImport();
        
          program.repglobImport = parserepglobImport();
        
          return repglobimport;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptGlobImportList parseoptGlobImportList()
    {
      switch (terminal) {
        case Terminals.GLOBAL:
        {
          var optglobimportlist = new OptGlobImportListGlobal();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.globImportList = parseglobImportList();
        
          return optglobimportlist;
        }
        
        case Terminals.DO:
        {
          var optglobimportlist = new OptGlobImportListDo();
          
          // Epsilon
        
          return optglobimportlist;
        }
        
        case Terminals.LOCAL:
        {
          var optglobimportlist = new OptGlobImportListLocal();
          
          // Epsilon
        
          return optglobimportlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptModeChange parseoptModeChange()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var optmodechange = new OptModeChangeIdent();
          
          // Epsilon
        
          return optmodechange;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optmodechange = new OptModeChangeChangemode();
          
          program.Ident = consume(Terminals.IDENT);
        
          return optmodechange;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptModeMech parseoptModeMech()
    {
      switch (terminal) {
        case Terminals.IDENT:
        {
          var optmodemech = new OptModeMechIdent();
          
          // Epsilon
        
          return optmodemech;
        }
        
        case Terminals.CHANGEMODE:
        {
          var optmodemech = new OptModeMechChangemode();
          
          // Epsilon
        
          return optmodemech;
        }
        
        case Terminals.MECHMODE:
        {
          var optmodemech = new OptModeMechMechmode();
          
          program.Ident = consume(Terminals.IDENT);
        
          return optmodemech;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IblockCmd parseblockCmd()
    {
      switch (terminal) {
        case Terminals.DO:
        {
          var blockcmd = new BlockCmdDo();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.cmd = parsecmd();
        
          program.repCmd = parserepCmd();
        
          program.endBlock = parseendBlock();
        
          return blockcmd;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IendBlock parseendBlock()
    {
      switch (terminal) {
        case Terminals.ENDWHILE:
        {
          var endblock = new EndBlockEndwhile();
          
          program.Ident = consume(Terminals.IDENT);
        
          return endblock;
        }
        
        case Terminals.ENDFUN:
        {
          var endblock = new EndBlockEndfun();
          
          program.Ident = consume(Terminals.IDENT);
        
          return endblock;
        }
        
        case Terminals.ENDPROC:
        {
          var endblock = new EndBlockEndproc();
          
          program.Ident = consume(Terminals.IDENT);
        
          return endblock;
        }
        
        case Terminals.ENDIF:
        {
          var endblock = new EndBlockEndif();
          
          program.Ident = consume(Terminals.IDENT);
        
          return endblock;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IexprList parseexprList()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var exprlist = new ExprListLparen();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.optRepExpr = parseoptRepExpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          return exprlist;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptRepExpr parseoptRepExpr()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var optrepexpr = new OptRepExprRparen();
          
          // Epsilon
        
          return optrepexpr;
        }
        
        case Terminals.LPAREN:
        {
          var optrepexpr = new OptRepExprLparen();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        
        case Terminals.IDENT:
        {
          var optrepexpr = new OptRepExprIdent();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        
        case Terminals.ADDOPR:
        {
          var optrepexpr = new OptRepExprAddopr();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        
        case Terminals.NOT:
        {
          var optrepexpr = new OptRepExprNot();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        
        case Terminals.LBRACKET:
        {
          var optrepexpr = new OptRepExprLbracket();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        
        case Terminals.LITERAL:
        {
          var optrepexpr = new OptRepExprLiteral();
          
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return optrepexpr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Ifactor parsefactor()
    {
      switch (terminal) {
        case Terminals.LITERAL:
        {
          var factor = new FactorLiteral();
          
          program.Ident = consume(Terminals.IDENT);
        
          return factor;
        }
        
        case Terminals.LBRACKET:
        {
          var factor = new FactorLbracket();
          
          program.arrayLiteral = parsearrayLiteral();
        
          return factor;
        }
        
        case Terminals.ADDOPR:
        {
          var factor = new FactorAddopr();
          
          program.monadicOpr = parsemonadicOpr();
        
          program.factor = parsefactor();
        
          return factor;
        }
        
        case Terminals.NOT:
        {
          var factor = new FactorNot();
          
          program.monadicOpr = parsemonadicOpr();
        
          program.factor = parsefactor();
        
          return factor;
        }
        
        case Terminals.IDENT:
        {
          var factor = new FactorIdent();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.optInitParamsOrArrayAccess = parseoptInitParamsOrArrayAccess();
        
          return factor;
        }
        
        case Terminals.LPAREN:
        {
          var factor = new FactorLparen();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          return factor;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IoptInitParamsOrArrayAccess parseoptInitParamsOrArrayAccess()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessRbracket();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.DOTDOT:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessDotdot();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.COMMA:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessComma();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.RPAREN:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessRparen();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ENDIF:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessEndif();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ENDPROC:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessEndproc();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ENDFUN:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessEndfun();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ENDWHILE:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessEndwhile();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessEndprogram();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.SEMICOLON:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessSemicolon();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.BECOMES:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessBecomes();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.BOOLOPR:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessBoolopr();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.RELOPR:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessRelopr();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.ADDOPR:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessAddopr();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.MULTOPR:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessMultopr();
          
          // Epsilon
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.LBRACKET:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessLbracket();
          
          program.arrayIndex = parsearrayIndex();
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.LPAREN:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessLparen();
          
          program.exprList = parseexprList();
        
          return optinitparamsorarrayaccess;
        }
        
        case Terminals.INIT:
        {
          var optinitparamsorarrayaccess = new OptInitParamsOrArrayAccessInit();
          
          program.Ident = consume(Terminals.IDENT);
        
          return optinitparamsorarrayaccess;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IarrayLiteral parsearrayLiteral()
    {
      switch (terminal) {
        case Terminals.LBRACKET:
        {
          var arrayliteral = new ArrayLiteralLbracket();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.arrayContent = parsearrayContent();
        
          program.Ident = consume(Terminals.IDENT);
        
          return arrayliteral;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IarrayContent parsearrayContent()
    {
      switch (terminal) {
        case Terminals.LITERAL:
        {
          var arraycontent = new ArrayContentLiteral();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.repLiteral = parserepLiteral();
        
          return arraycontent;
        }
        
        case Terminals.LBRACKET:
        {
          var arraycontent = new ArrayContentLbracket();
          
          program.arrayLiteral = parsearrayLiteral();
        
          program.repArray = parserepArray();
        
          return arraycontent;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepArray parserepArray()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var reparray = new RepArrayRbracket();
          
          // Epsilon
        
          return reparray;
        }
        
        case Terminals.COMMA:
        {
          var reparray = new RepArrayComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.arrayLiteral = parsearrayLiteral();
        
          program.repArray = parserepArray();
        
          return reparray;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepLiteral parserepLiteral()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repliteral = new RepLiteralRbracket();
          
          // Epsilon
        
          return repliteral;
        }
        
        case Terminals.COMMA:
        {
          var repliteral = new RepLiteralComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.Ident = consume(Terminals.IDENT);
        
          program.repLiteral = parserepLiteral();
        
          return repliteral;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IarrayIndex parsearrayIndex()
    {
      switch (terminal) {
        case Terminals.LBRACKET:
        {
          var arrayindex = new ArrayIndexLbracket();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.sliceExpr = parsesliceExpr();
        
          program.Ident = consume(Terminals.IDENT);
        
          program.repArrayIndex = parserepArrayIndex();
        
          return arrayindex;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IsliceExpr parsesliceExpr()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var sliceexpr = new SliceExprLparen();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        
        case Terminals.IDENT:
        {
          var sliceexpr = new SliceExprIdent();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        
        case Terminals.ADDOPR:
        {
          var sliceexpr = new SliceExprAddopr();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        
        case Terminals.NOT:
        {
          var sliceexpr = new SliceExprNot();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        
        case Terminals.LBRACKET:
        {
          var sliceexpr = new SliceExprLbracket();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        
        case Terminals.LITERAL:
        {
          var sliceexpr = new SliceExprLiteral();
          
          program.expr = parseexpr();
        
          program.repSliceExpr = parserepSliceExpr();
        
          return sliceexpr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepSliceExpr parserepSliceExpr()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repsliceexpr = new RepSliceExprRbracket();
          
          // Epsilon
        
          return repsliceexpr;
        }
        
        case Terminals.DOTDOT:
        {
          var repsliceexpr = new RepSliceExprDotdot();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          return repsliceexpr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepArrayIndex parserepArrayIndex()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var reparrayindex = new RepArrayIndexRbracket();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.DOTDOT:
        {
          var reparrayindex = new RepArrayIndexDotdot();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.COMMA:
        {
          var reparrayindex = new RepArrayIndexComma();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.RPAREN:
        {
          var reparrayindex = new RepArrayIndexRparen();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ENDIF:
        {
          var reparrayindex = new RepArrayIndexEndif();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ENDPROC:
        {
          var reparrayindex = new RepArrayIndexEndproc();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ENDFUN:
        {
          var reparrayindex = new RepArrayIndexEndfun();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ENDWHILE:
        {
          var reparrayindex = new RepArrayIndexEndwhile();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var reparrayindex = new RepArrayIndexEndprogram();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.SEMICOLON:
        {
          var reparrayindex = new RepArrayIndexSemicolon();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.BECOMES:
        {
          var reparrayindex = new RepArrayIndexBecomes();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.BOOLOPR:
        {
          var reparrayindex = new RepArrayIndexBoolopr();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.RELOPR:
        {
          var reparrayindex = new RepArrayIndexRelopr();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.ADDOPR:
        {
          var reparrayindex = new RepArrayIndexAddopr();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.MULTOPR:
        {
          var reparrayindex = new RepArrayIndexMultopr();
          
          // Epsilon
        
          return reparrayindex;
        }
        
        case Terminals.LBRACKET:
        {
          var reparrayindex = new RepArrayIndexLbracket();
          
          program.arrayIndex = parsearrayIndex();
        
          return reparrayindex;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepExpr parserepExpr()
    {
      switch (terminal) {
        case Terminals.RPAREN:
        {
          var repexpr = new RepExprRparen();
          
          // Epsilon
        
          return repexpr;
        }
        
        case Terminals.COMMA:
        {
          var repexpr = new RepExprComma();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.expr = parseexpr();
        
          program.repExpr = parserepExpr();
        
          return repexpr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iexpr parseexpr()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var expr = new ExprLparen();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        
        case Terminals.IDENT:
        {
          var expr = new ExprIdent();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        
        case Terminals.ADDOPR:
        {
          var expr = new ExprAddopr();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        
        case Terminals.NOT:
        {
          var expr = new ExprNot();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        
        case Terminals.LBRACKET:
        {
          var expr = new ExprLbracket();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        
        case Terminals.LITERAL:
        {
          var expr = new ExprLiteral();
          
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return expr;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepTerm1 parserepTerm1()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repterm1 = new RepTerm1Rbracket();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.DOTDOT:
        {
          var repterm1 = new RepTerm1Dotdot();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.COMMA:
        {
          var repterm1 = new RepTerm1Comma();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.RPAREN:
        {
          var repterm1 = new RepTerm1Rparen();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.ENDIF:
        {
          var repterm1 = new RepTerm1Endif();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm1 = new RepTerm1Endproc();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm1 = new RepTerm1Endfun();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm1 = new RepTerm1Endwhile();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm1 = new RepTerm1Endprogram();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm1 = new RepTerm1Semicolon();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.BECOMES:
        {
          var repterm1 = new RepTerm1Becomes();
          
          // Epsilon
        
          return repterm1;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm1 = new RepTerm1Boolopr();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.term1 = parseterm1();
        
          program.repTerm1 = parserepTerm1();
        
          return repterm1;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iterm1 parseterm1()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var term1 = new Term1Lparen();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        
        case Terminals.IDENT:
        {
          var term1 = new Term1Ident();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        
        case Terminals.ADDOPR:
        {
          var term1 = new Term1Addopr();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        
        case Terminals.NOT:
        {
          var term1 = new Term1Not();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        
        case Terminals.LBRACKET:
        {
          var term1 = new Term1Lbracket();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        
        case Terminals.LITERAL:
        {
          var term1 = new Term1Literal();
          
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return term1;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepTerm2 parserepTerm2()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repterm2 = new RepTerm2Rbracket();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.DOTDOT:
        {
          var repterm2 = new RepTerm2Dotdot();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.COMMA:
        {
          var repterm2 = new RepTerm2Comma();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.RPAREN:
        {
          var repterm2 = new RepTerm2Rparen();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.ENDIF:
        {
          var repterm2 = new RepTerm2Endif();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm2 = new RepTerm2Endproc();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm2 = new RepTerm2Endfun();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm2 = new RepTerm2Endwhile();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm2 = new RepTerm2Endprogram();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm2 = new RepTerm2Semicolon();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.BECOMES:
        {
          var repterm2 = new RepTerm2Becomes();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm2 = new RepTerm2Boolopr();
          
          // Epsilon
        
          return repterm2;
        }
        
        case Terminals.RELOPR:
        {
          var repterm2 = new RepTerm2Relopr();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.term2 = parseterm2();
        
          program.repTerm2 = parserepTerm2();
        
          return repterm2;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iterm2 parseterm2()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var term2 = new Term2Lparen();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        
        case Terminals.IDENT:
        {
          var term2 = new Term2Ident();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        
        case Terminals.ADDOPR:
        {
          var term2 = new Term2Addopr();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        
        case Terminals.NOT:
        {
          var term2 = new Term2Not();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        
        case Terminals.LBRACKET:
        {
          var term2 = new Term2Lbracket();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        
        case Terminals.LITERAL:
        {
          var term2 = new Term2Literal();
          
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return term2;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepTerm3 parserepTerm3()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repterm3 = new RepTerm3Rbracket();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.DOTDOT:
        {
          var repterm3 = new RepTerm3Dotdot();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.COMMA:
        {
          var repterm3 = new RepTerm3Comma();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.RPAREN:
        {
          var repterm3 = new RepTerm3Rparen();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ENDIF:
        {
          var repterm3 = new RepTerm3Endif();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm3 = new RepTerm3Endproc();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm3 = new RepTerm3Endfun();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm3 = new RepTerm3Endwhile();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm3 = new RepTerm3Endprogram();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm3 = new RepTerm3Semicolon();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.BECOMES:
        {
          var repterm3 = new RepTerm3Becomes();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm3 = new RepTerm3Boolopr();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.RELOPR:
        {
          var repterm3 = new RepTerm3Relopr();
          
          // Epsilon
        
          return repterm3;
        }
        
        case Terminals.ADDOPR:
        {
          var repterm3 = new RepTerm3Addopr();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.term3 = parseterm3();
        
          program.repTerm3 = parserepTerm3();
        
          return repterm3;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public Iterm3 parseterm3()
    {
      switch (terminal) {
        case Terminals.LPAREN:
        {
          var term3 = new Term3Lparen();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        
        case Terminals.IDENT:
        {
          var term3 = new Term3Ident();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        
        case Terminals.ADDOPR:
        {
          var term3 = new Term3Addopr();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        
        case Terminals.NOT:
        {
          var term3 = new Term3Not();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        
        case Terminals.LBRACKET:
        {
          var term3 = new Term3Lbracket();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        
        case Terminals.LITERAL:
        {
          var term3 = new Term3Literal();
          
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return term3;
        }
        default:
          throw new NotImplementedException();
      }
    }
    
    public IrepTerm4 parserepTerm4()
    {
      switch (terminal) {
        case Terminals.RBRACKET:
        {
          var repterm4 = new RepTerm4Rbracket();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.DOTDOT:
        {
          var repterm4 = new RepTerm4Dotdot();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.COMMA:
        {
          var repterm4 = new RepTerm4Comma();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.RPAREN:
        {
          var repterm4 = new RepTerm4Rparen();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ENDIF:
        {
          var repterm4 = new RepTerm4Endif();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ENDPROC:
        {
          var repterm4 = new RepTerm4Endproc();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ENDFUN:
        {
          var repterm4 = new RepTerm4Endfun();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ENDWHILE:
        {
          var repterm4 = new RepTerm4Endwhile();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ENDPROGRAM:
        {
          var repterm4 = new RepTerm4Endprogram();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.SEMICOLON:
        {
          var repterm4 = new RepTerm4Semicolon();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.BECOMES:
        {
          var repterm4 = new RepTerm4Becomes();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.BOOLOPR:
        {
          var repterm4 = new RepTerm4Boolopr();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.RELOPR:
        {
          var repterm4 = new RepTerm4Relopr();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.ADDOPR:
        {
          var repterm4 = new RepTerm4Addopr();
          
          // Epsilon
        
          return repterm4;
        }
        
        case Terminals.MULTOPR:
        {
          var repterm4 = new RepTerm4Multopr();
          
          program.Ident = consume(Terminals.IDENT);
        
          program.factor = parsefactor();
        
          program.repTerm4 = parserepTerm4();
        
          return repterm4;
        }
        default:
          throw new NotImplementedException();
      }
    }
    

    private class GrammarError : Exception
    {
      public GrammarError(String ErrorMessage) :base (ErrorMessage)
      {

      }
    }
  }
}

program.Ident = consume(Terminals.IDENT);
program.ProgParamList = parseProgParamList();
