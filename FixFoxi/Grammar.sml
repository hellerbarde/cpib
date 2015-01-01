datatype term  =
     ADDOPR
   | ARRAY
   | BECOMES
   | BOOLOPR
   | CALL
   | CHANGEMODE
   | COLON
   | COMMA
   | DEBUGIN
   | DEBUGOUT
   | DO
   | ELSE
   | ENDFUN
   | ENDIF
   | ENDPROC
   | ENDPROGRAM
   | ENDWHILE
   | FILL
   | FLOWMODE
   | FUN
   | GLOBAL
   | IDENT
   | IF
   | INIT
   | LBRACKET
   | LITERAL
   | LOCAL
   | LPAREN
   | MECHMODE
   | MULTOPR
   | NOT
   | PROC
   | PROGRAM
   | RANGE
   | RBRACKET
   | RELOPR
   | RETURNS
   | RPAREN
   | SEMICOLON
   | SENTINEL
   | SKIP
   | THEN
   | TYPE
   | WHILE

val string_of_term =
  fn ADDOPR => "ADDOPR"
   | ARRAY => "ARRAY"
   | BECOMES => "BECOMES"
   | BOOLOPR => "BOOLOPR"
   | CALL => "CALL"
   | CHANGEMODE => "CHANGEMODE"
   | COLON => "COLON"
   | COMMA => "COMMA"
   | DEBUGIN => "DEBUGIN"
   | DEBUGOUT => "DEBUGOUT"
   | DO => "DO"
   | ELSE => "ELSE"
   | ENDFUN => "ENDFUN"
   | ENDIF => "ENDIF"
   | ENDPROC => "ENDPROC"
   | ENDPROGRAM => "ENDPROGRAM"
   | ENDWHILE => "ENDWHILE"
   | FILL => "FILL"
   | FLOWMODE => "FLOWMODE"
   | FUN => "FUN"
   | GLOBAL => "GLOBAL"
   | IDENT => "IDENT"
   | IF => "IF"
   | INIT => "INIT"
   | LBRACKET => "LBRACKET"
   | LITERAL => "LITERAL"
   | LOCAL => "LOCAL"
   | LPAREN => "LPAREN"
   | MECHMODE => "MECHMODE"
   | MULTOPR => "MULTOPR"
   | NOT => "NOT"
   | PROC => "PROC"
   | PROGRAM => "PROGRAM"
   | RANGE => "RANGE"
   | RBRACKET => "RBRACKET"
   | RELOPR => "RELOPR"
   | RETURNS => "RETURNS"
   | RPAREN => "RPAREN"
   | SEMICOLON => "SEMICOLON"
   | SENTINEL => "SENTINEL"
   | SKIP => "SKIP"
   | THEN => "THEN"
   | TYPE => "TYPE"
   | WHILE => "WHILE"


datatype nonterm = 
      arrayAccess 
    | arrayContent 
    | arrayDecl 
    | arrayIndex
    | arrayLiteral
    | cmd
    | cpsCmd
    | cpsDecl
    | cpsStoDecl
    | decl
    | expr
    | exprList
    | factor
    | funDecl
    | globImp
    | globImps
    | monadicOpr
    | optChangemode
    | optCpsDecl
    | optCpsStoDecl
    | optExprList
    | optFill
    | optGlobImps
    | optGlobInits
    | optInitOrExprListOrArrayAccess
    | optMechmode
    | optParamList
    | optProgParamList
    | param
    | paramList
    | procDecl
    | progParam
    | progParamList
    | program
    | repArray
    | repArrayIndex
    | repArrayLength
    | repCpsCmd
    | repCpsDecl
    | repCpsStoDecl
    | repExprList
    | repFactor
    | repGlobImps
    | repIdents
    | repLiteral
    | repParamList
    | repProgParamList
    | repSliceExpr
    | repTerm1
    | repTerm2
    | repTerm3
    | sliceExpr
    | stoDecl
    | term1
    | term2
    | term3
    | typedIdent
    | typeOrArray

val string_of_nonterm =
   fn arrayAccess => "arrayAccess"
    | arrayContent => "arrayContent"
    | arrayDecl => "arrayDecl"
    | arrayIndex => "arrayIndex"
    | arrayLiteral => "arrayLiteral"
    | cmd => "cmd"
    | cpsCmd => "cpsCmd"
    | cpsDecl => "cpsDecl"
    | cpsStoDecl => "cpsStoDecl"
    | decl => "decl"
    | expr => "expr"
    | exprList => "exprList"
    | factor => "factor"
    | funDecl => "funDecl"
    | globImp => "globImp"
    | globImps => "globImps"
    | monadicOpr => "monadicOpr"
    | optChangemode => "optChangemode"
    | optCpsDecl => "optCpsDecl"
    | optCpsStoDecl => "optCpsStoDecl"
    | optFill => "optFill"
    | optExprList => "optExprList"
    | optGlobImps => "optGlobImps"
    | optGlobInits => "optGlobInits"
    | optInitOrExprListOrArrayAccess => "optInitOrExprListOrArrayAccess"
    | optMechmode => "optMechmode"
    | optParamList => "optParamList"
    | optProgParamList => "optProgParamList"
    | param => "param"
    | paramList => "paramList"
    | procDecl => "procDecl"
    | progParam => "progParam"
    | progParamList => "progParamList"
    | program => "program"
    | repArray => "repArray"
    | repArrayIndex => "repArrayIndex"
    | repArrayLength => "repArrayLength"
    | repCpsCmd => "repCpsCmd"
    | repCpsDecl => "repCpsDecl"
    | repCpsStoDecl => "repCpsStoDecl"
    | repExprList => "repExprList"
    | repFactor => "repFactor"
    | repGlobImps => "repGlobImps"
    | repLiteral => "repLiteral"
    | repIdents => "repIdents"
    | repParamList => "repParamList"
    | repProgParamList => "repProgParamList"
    | repSliceExpr => "repSliceExpr"
    | repTerm1 => "repTerm1"
    | repTerm2 => "repTerm2"
    | repTerm3 => "repTerm3"
    | sliceExpr => "sliceExpr"
    | stoDecl => "stoDecl"
    | term1 => "term1"
    | term2 => "term2"
    | term3 => "term3"
    | typedIdent => "typedIdent"
    | typeOrArray => "typeOrArray"

val string_of_gramsym = (string_of_term, string_of_nonterm)

local
  open FixFoxi.FixFoxiCore
in

val productions =
[
    (program, [
        [T PROGRAM, T IDENT, N progParamList, N optCpsDecl, T DO, N cpsCmd, T ENDPROGRAM]
    ]),

    (decl, [
        [N stoDecl],
        [N funDecl],
        [N procDecl]
    ]),

    (stoDecl, [
        [              N typedIdent],
        [T CHANGEMODE, N typedIdent]
    ]),

    (funDecl, [
        [T FUN, T IDENT, N paramList, T RETURNS, N stoDecl, N optGlobImps, N optCpsStoDecl, T DO, N cpsCmd, T ENDFUN]
    ]),

    (procDecl, [
        [T PROC, T IDENT, N paramList, N optGlobImps, N optCpsStoDecl, T DO, N cpsCmd, T ENDPROC]
    ]),

    (optGlobImps, [
        [T GLOBAL, N globImps],
        []
    ]),

    (globImps, [
        [N globImp, N repGlobImps]
    ]),

    (repGlobImps, [
        [T COMMA, N globImp, N repGlobImps],
        []
    ]),

    (optChangemode, [
        [T CHANGEMODE],
        []
    ]),

    (optMechmode, [
        [T MECHMODE],
        []
    ]),

    (globImp, [
        [            N optChangemode, T IDENT],
        [T FLOWMODE, N optChangemode, T IDENT]
    ]),

    (optCpsDecl, [
        [T GLOBAL, N cpsDecl],
        []
    ]),

    (cpsDecl, [
        [N decl, N repCpsDecl]
    ]),

    (repCpsDecl, [
        [T SEMICOLON, N decl, N repCpsDecl],
        []
    ]),

    (optCpsStoDecl, [
        [T LOCAL, N cpsStoDecl],
        []
    ]),

    (cpsStoDecl, [
        [N stoDecl, N repCpsStoDecl]
    ]),

    (repCpsStoDecl, [
        [T SEMICOLON, N stoDecl, N repCpsStoDecl],
        []
    ]),

    (progParamList, [
        [T LPAREN, N optProgParamList, T RPAREN]
    ]),

    (optProgParamList, [
        [N progParam, N repProgParamList],
        []
    ]),

    (repProgParamList, [
        [T COMMA, N progParam, N repProgParamList],
        []
    ]),

    (progParam, [
        [            N optChangemode, N typedIdent],
        [T FLOWMODE, N optChangemode, N typedIdent]
    ]),

    (paramList, [
        [T LPAREN, N optParamList, T RPAREN]
    ]),

    (optParamList, [
        [N param, N repParamList],
        []
    ]),

    (repParamList, [
        [T COMMA, N param, N repParamList],
        []
    ]),

    (param, [
        [            N optMechmode, N optChangemode, N typedIdent],
        [T FLOWMODE, N optMechmode, N optChangemode, N typedIdent]
    ]),

    (typedIdent, [
        [T IDENT, T COLON, N typeOrArray]
    ]),

(typeOrArray ,
[[T TYPE],
[T ARRAY, T LPAREN, N expr, N repArrayLength, T RPAREN, T TYPE]]),

(repArrayLength ,
[[],
[T COMMA, N expr, N repArrayLength]]),

    (cmd, [
        [T SKIP],
        [N expr, T BECOMES, N optFill, N expr],
        [T IF, N expr, T THEN, N cpsCmd, T ELSE, N cpsCmd, T ENDIF],
        [T WHILE, N expr, T DO, N cpsCmd, T ENDWHILE],
        [T CALL, T IDENT, N exprList, N optGlobInits],
        [T DEBUGIN, N expr],
        [T DEBUGOUT, N expr]
    ]),

    (cpsCmd, [
        [N cmd, N repCpsCmd]
    ]),

    (repCpsCmd, [
        [T SEMICOLON, N cmd, N repCpsCmd],
        []
    ]),
    
  (optFill ,
    [[],
     [T FILL]]),

    (optGlobInits, [
        [T INIT, T IDENT, N repIdents],
        []
    ]),

    (repIdents, [
        [T COMMA, T IDENT, N repIdents],
        []
    ]),

    (expr, [
        [N term1, N repTerm1]
    ]),

    (repTerm1, [
        [T BOOLOPR, N term1, N repTerm1],
        []
    ]),

    (term1, [
        [N term2, N repTerm2]
    ]),

    (repTerm2, [
        [T RELOPR, N term2, N repTerm2],
        []
    ]),

    (term2, [
        [N term3, N repTerm3]
    ]),

    (repTerm3, [
        [T ADDOPR, N term3, N repTerm3],
        []
    ]),

    (term3, [
        [N factor, N repFactor]
    ]),

    (repFactor, [
        [T MULTOPR, N factor, N repFactor],
        []
    ]),

    (factor, [
        [T LITERAL],
        [N arrayLiteral],
        [T IDENT, N optInitOrExprListOrArrayAccess],
        [N monadicOpr, N factor],
        [T LPAREN, N expr, T RPAREN],
        [T TYPE, T LPAREN, N expr, T RPAREN]
    ]),

(arrayLiteral, 
[[T LBRACKET, N arrayContent, T RBRACKET]]),

(arrayContent , 
[[T LITERAL,N repLiteral],
[N arrayLiteral, N repArray]]),

(repArray ,
[[],
[T COMMA, N arrayLiteral, N repArray]]),

(repLiteral ,
[[],
[T COMMA, T LITERAL, N repLiteral]]),

    (optInitOrExprListOrArrayAccess, [
        [T INIT],
[N arrayIndex],
        [N exprList],
        []
    ]),

(arrayIndex ,
[[T LBRACKET, N sliceExpr, T RBRACKET, N repArrayIndex]]),

(sliceExpr ,
[[N expr, N repSliceExpr]]),
(repSliceExpr ,
[[],
[T RANGE, N expr]]),

(repArrayIndex , 
[[],
[N arrayIndex]]),

    (monadicOpr, [
        [T NOT],
        [T ADDOPR]
    ]),

    (exprList, [
        [T LPAREN, N optExprList, T RPAREN]
    ]),

    (optExprList, [
        [N expr, N repExprList],
        []
    ]),

    (repExprList, [
        [T COMMA, N expr, N repExprList],
        []
    ])
]

val S = program

val result = fix_foxi productions S string_of_gramsym

end (* local *)
