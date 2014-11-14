datatype term
  = LPAREN
   | RPAREN
   | DO
   | END
   | LBRACKET
   | RBRACKET
   | COMMA
   | SEMICOLON
   | COLON
   | QUESTMARK
   | EXCLAMARK
   | BECOMES
   | MULTOPR
   | ADDOPR
   | RELOPR
   | BOOLOPR
   | LITERAL
   | IDENT
   | TYPE
   | CALL
   | CHANGEMODE
   | MECHMODE
   | FLOWMODE
   | IF
   | ENDIF
   | ELSE
   | FUN
   | GLOBAL
   | LOCAL
   | NOT
   | PROGRAM
   | PROC
   | RETURNS
   | SKIP
   | WHILE
   | ENDWHILE
   | DO
   | INIT
   | DEBUGIN
   | DEBUGOUT
   | ENDFUN
   | ENDPROC
   | ENDPROGRAM
   | ARRAY
   | FILL

val string_of_term =
  fn LPAREN => "LPAREN"
   | RPAREN => "RPAREN"
   | DO => "DO"
   | END => "END"
   | COMMA => "COMMA"
   | SEMICOLON => "SEMICOLON"
   | COLON => "COLON"
   | QUESTMARK => "QUESTMARK"
   | EXCLAMARK => "EXCLAMARK"
   | BECOMES => "BECOMES"
   | MULTOPR => "MULTOPR"
   | ADDOPR => "ADDOPR"
   | RELOPR => "RELOPR"
   | BOOLOPR => "BOOLOPR"
   | LITERAL => "LITERAL"
   | IDENT => "IDENT"
   | TYPE => "TYPE"
   | CALL => "CALL"
   | CHANGEMODE => "CHANGEMODE"
   | MECHMODE => "MECHMODE"
   | FLOWMODE => "FLOWMODE"
   | IF => "IF"
   | ENDIF => "ENDIF"
   | ELSE => "ELSE"
   | FUN => "FUN"
   | GLOBAL => "GLOBAL"
   | LOCAL => "LOCAL"
   | NOT => "NOT"
   | PROGRAM => "PROGRAM"
   | PROC => "PROC"
   | RETURNS => "RETURNS"
   | SKIP => "SKIP"
   | WHILE => "WHILE"
   | ENDWHILE => "ENDWHILE"
   | DO => "DO"
   | INIT => "INIT"
   | DEBUGIN => "DEBUGIN"
   | DEBUGOUT => "DEBUGOUT"
   | ENDFUN => "ENDFUN"
   | ENDPROC => "ENDPROC"
   | ENDPROGRAM => "ENDPROGRAM"
   | ARRAY => "ARRAY"
   | FILL => "FILL"
   
datatype nonterm
  = blockCmd
   | cmd
   | cpsDecl
   | repCpsDecl
   | decl
   | expr
   | exprList
   | factor
   | funDecl
   | globImport
   | globImportList
   | globInitList
   | repGlobInit
   | monadicOpr
   | optCpsStoDecl
   | cpsStoDecl
   | repCpsStoDecl
   | optGlobCpsDecl
   | optGlobImportList
   | optModeChange
   | optModeFlow
   | optModeMech
   | param
   | paramList
   | procDecl
   | program
   | progParamList
   | progParams
   | repProgParams
   | repCmd
   | repExpr
   | optRepExpr
   | repglobImport
   | repParam
   | storeDecl
   | term1
   | term2
   | term3
   | term4
   | repTerm1
   | repTerm2
   | repTerm3
   | repTerm4
   | typedident
   | arrayDecl
   | arrayLiteral
   | arrayAccess
   | arrayIndex
   | repArrayIndex
   | optArrayOrFunction

val string_of_nonterm =
  fn blockCmd => "blockCmd"
   | cmd => "cmd"
   | cpsDecl => "cpsDecl"
   | repCpsDecl => "repCpsDecl"
   | decl => "decl"
   | expr => "expr"
   | exprList => "exprList"
   | factor => "factor"
   | funDecl => "funDecl"
   | globImport => "globImport"
   | globImportList => "globImportList"
   | globInitList => "globInitList"
   | repGlobInit => "repGlobInit"
   | monadicOpr => "monadicOpr"
   | optCpsStoDecl =>"optCpsStoDecl"
   | cpsStoDecl => "cpsStoDecl"
   | repCpsStoDecl => "repCpsStoDecl"
   | optGlobCpsDecl => "optGlobCpsDecl"
   | optGlobImportList => "optGlobImportList"
   | optModeChange => "optModeChange"
   | optModeFlow => "optModeFlow"
   | optModeMech => "optModeMech"
   | param => "param"
   | paramList => "paramList"
   | procDecl => "procDecl"
   | program => "program"
   | progParamList => "progParamList"
   | progParams => "progParams"
   | repProgParams => "repProgParams"
   | repCmd => "repCmd"
   | repExpr => "repExpr"
   | optRepExpr => "optRepExpr"
   | repglobImport => "repglobImport"
   | repParam => "repParam"
   | storeDecl => "storeDecl"
   | term1 => "term1"
   | term2 => "term2"
   | term3 => "term3"
   | term4 => "term4"
   | repTerm1 => "repTerm1"
   | repTerm2 => "repTerm2"
   | repTerm3 => "repTerm3"
   | repTerm4 => "repTerm4"
   | typedident => "typedident"
   | arrayDecl => "arrayDecl"
   | arrayLiteral => "arrayLiteral"
   | arrayAccess => "arrayAccess"
   | arrayIndex => "arrayIndex"
   | repArrayIndex => "repArrayIndex"
   | optArrayOrFunction => "optArrayOrFunction"


val string_of_gramsym = (string_of_term, string_of_nonterm)

local
  open FixFoxi.FixFoxiCore
in

val productions =
[
  (optModeFlow ,
    [[], 
    [T FLOWMODE]]),

  (cpsDecl ,
    [[],
    [N decl,N repCpsDecl]]),

  (repCpsDecl ,
    [[],
    [T SEMICOLON,N cpsDecl]]),

  (cmd ,
    [[T SKIP], 
    [N expr,T BECOMES,N expr], 
    [T IF,T LPAREN,N expr,T RPAREN,N blockCmd,T ELSE,N blockCmd], 
    [T WHILE,T LPAREN,N expr,T RPAREN,N blockCmd], 
    [T CALL,T IDENT,N exprList,T INIT,N globInitList], 
    [T QUESTMARK,N expr], 
    [T EXCLAMARK,N expr]]),

  (repParam ,
    [[], 
    [T COMMA,N param]]),

  (globInitList ,
    [[T IDENT, N repGlobInit]]),

  (repGlobInit ,
    [[],
    [T COMMA, T IDENT, N repGlobInit]]),

  (param ,
    [[N optModeFlow,N optModeMech,N storeDecl,N repParam]]),

  (program ,
    [[T PROGRAM,T IDENT,N progParamList,N optGlobCpsDecl,T DO,N cmd,N repCmd,T ENDPROGRAM]]),

  (progParamList , 
    [[T LPAREN,N progParams,T RPAREN]]),

  (progParams ,
    [[],
    [T FLOWMODE, T CHANGEMODE, N typedident, N repProgParams]]),   

  (repProgParams ,
    [[],
    [T COMMA,N progParams]]),

  (typedident ,
    [[T IDENT,T COLON,T TYPE]]),

  (monadicOpr ,
    [[T NOT], 
    [T ADDOPR]]),

  (decl ,
    [[N storeDecl], 
    [N funDecl], 
    [N procDecl]]),

  (procDecl ,
    [[T PROC,T IDENT,N paramList, N optGlobImportList,N optCpsStoDecl,N blockCmd]]),

  (storeDecl ,
    [[N optModeChange,N typedident]]),

  (funDecl ,
    [[T FUN,T IDENT,N paramList,T RETURNS,N storeDecl,N optGlobImportList,N optCpsStoDecl,N blockCmd]]),

  (optCpsStoDecl, 
    [[T LOCAL, N cpsStoDecl],
    []]),

  (cpsStoDecl, 
    [[N storeDecl, N repCpsStoDecl]]),

  (repCpsStoDecl, 
    [[T SEMICOLON, N storeDecl, N repCpsStoDecl],
    []]),
    
  (optGlobCpsDecl ,
    [[T GLOBAL,N cpsDecl],
    []]),

  (paramList ,
    [[T LPAREN,N param,T RPAREN]]),

  (repCmd ,
    [[], 
    [T SEMICOLON, N cmd, N repCmd]]),

  (globImport ,
    [[N optModeFlow,N optModeChange,T IDENT]]),

  (globImportList ,
    [[N globImport, N repglobImport]]),

  (repglobImport ,
    [[],
    [T COMMA, N globImport, N repglobImport]]),

  (optGlobImportList ,
    [[T GLOBAL,N globImportList], 
    []]),

  (optModeChange ,
    [[], 
    [T CHANGEMODE]]),

  (optModeMech ,
    [[], 
    [T MECHMODE]]),

  (blockCmd ,
    [[T DO,N cmd,N repCmd,T END]]),

  (exprList ,
    [[T LPAREN,N optRepExpr,T RPAREN]]),

  (optRepExpr,
    [[],
    [N expr, N repExpr]]),

  (factor ,
    [[T LITERAL],
    [N monadicOpr,N factor],
    [T IDENT, N optArrayOrFunction],
    [T LPAREN, N expr, T RPAREN]]),

  (optArrayOrFunction ,
    [[],
    [N arrayIndex],
    [N exprList]]),
  
  (arrayIndex ,
     [[T LBRACKET, N expr, T RBRACKET, N repArrayIndex]]),
 
  (repArrayIndex , 
     [[],
      [N arrayIndex]]),

  (repExpr,
    [[], 
    [T COMMA, N expr, N repExpr]]),
  (expr,
    [[N term1, N repTerm1]]),

  (repTerm1,
    [[],
    [T BOOLOPR, N term1, N repTerm1]]),
  (term1,
    [[N term2, N repTerm2]]),

  (repTerm2,
    [[],
    [T RELOPR, N term2,N repTerm2]]),
  (term2,
    [[N term3, N repTerm3]]),

  (repTerm3,
    [[],
    [T ADDOPR, N term3, N repTerm3]]),

  (term3,
    [[N factor, N repTerm4]]),

  (repTerm4,
    [[],
    [T MULTOPR,N factor, N repTerm4]])

]

val S = program

val result = fix_foxi productions S string_of_gramsym

end (* local *)
 

