
## Grammatikalisch

Dies sind die Produktionen, die von der ursprünglichen IML Definition abweichen:
```
cmd     ::= SKIP
          | expr BECOMES [FILL] expr
          | IF expr THEN cpsCmd ELSE cpsCmd ENDIF
          | WHILE expr DO cpsCmd ENDWHILE
          | CALL IDENT exprList [globInits]
          | DEBUGIN expr
          | DEBUGOUT expr

typedIdent  ::= IDENT COLON (ATOMTYPE | ARRAY LPAREN expr {COMMA expr} RPAREN ATOMTYPE)

factor      ::= LITERAL
              | arrayLiteral
              | IDENT [INIT | exprList | arrayIndex]
              | monadicOpr factor
              | LPAREN expr RPAREN

arrayIndex  ::= LBRACKET expr [RANGE expr] RBRACKET {arrayIndex}

arrayLiteral ::= LBRACKET arrayContent RBRACKET

arrayContent ::= LITERAL {COMMA LITERAL}
               | arrayLiteral {COMMA arrayLiteral}

```

