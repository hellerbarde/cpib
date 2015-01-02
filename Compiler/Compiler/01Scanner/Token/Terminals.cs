using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
<<<<<<< HEAD:Compiler/Compiler/Scanner/Token/Terminals.cs
  public enum Terminals
  {
    ///<summary>(</summary>
    LPAREN,
    ///<summary>)</summary>
    RPAREN,
    ///<summary>[</summary>
    LBRACKET,
    ///<summary>]</summary>
    RBRACKET,
    ///<summary>,</summary>
    COMMA,
    ///<summary>;</summary>
    SEMICOLON,
    ///<summary>:</summary>
    COLON,
    ///<summary>:=</summary>
    BECOMES,
    ///<summary>*, div or mod</summary>
    MULTOPR,
    ///<summary>+ or -</summary>
    ADDOPR,
    ///<summary>=, /=, &lt;, &gt;, &lt;= or &gt;=</summary>
    RELOPR,
    ///<summary>&&, ||, &? or |?</summary>
    BOOLOPR,
    ///<summary>bool or int32</summary>
    TYPE,
    ///<summary>call</summary>
    CALL,
    ///<summary>const or var</summary>
    CHANGEMODE,
    ///<summary>copy or ref</summary>
    MECHMODE,
    ///<summary>debugin</summary>
    DEBUGIN,
    ///<summary>debugout</summary>
    DEBUGOUT,
    ///<summary>do</summary>
    DO,
    ///<summary>else</summary>
    ELSE,
    ///<summary>endfun (no fun for you, sorry)</summary>
    ENDFUN,
    ///<summary>endif</summary>
    ENDIF,
    ///<summary>endproc</summary>
    ENDPROC,
    ///<summary>endprogram</summary>
    ENDPROGRAM,
    ///<summary>endwhile</summary>
    ENDWHILE,
    ///<summary>false, true or (+|-)?[0-9]+</summary>
    LITERAL,
    ///<summary>fun (here, have some fun)</summary>
    FUN,
    ///<summary>global</summary>
    GLOBAL,
    ///<summary>if</summary>
    IF,
    ///<summary>in, inout or out</summary>
    FLOWMODE,
    ///<summary>init</summary>
    INIT,
    ///<summary>local</summary>
    LOCAL,
    ///<summary>not</summary>
    NOT,
    ///<summary>proc</summary>
    PROC,
    ///<summary>program</summary>
    PROGRAM,
    ///<summary>returns</summary>
    RETURNS,
    ///<summary>skip</summary>
    SKIP,
    ///<summary>then</summary>
    THEN,
    ///<summary>while</summary>
    WHILE,
    ///<summary>[a-zA-Z][a-zA-z0-9]*</summary>
    IDENT,
    ///<summary>..</summary>
    RANGE,
    ///<summary>array</summary>
    ARRAY,
    ///<summary>fill</summary>
    FILL,
    ///<summary>EOF</summary>
    SENTINEL,
  }
=======
    public enum Terminals
    {
        ///<summary>(</summary>
        LPAREN,
        ///<summary>)</summary>
        RPAREN,
        ///<summary>,</summary>
        COMMA,
        ///<summary>;</summary>
        SEMICOLON,
        ///<summary>:</summary>
        COLON,
        ///<summary>:=</summary>
        BECOMES,
        ///<summary>*, div or mod</summary>
        MULTOPR,
        ///<summary>+ or -</summary>
        ADDOPR,
        ///<summary>=, /=, &lt;, &gt;, &lt;= or &gt;=</summary>
        RELOPR,
        ///<summary>&&, ||, &? or |?</summary>
        BOOLOPR,
        ///<summary>decimal, bool or int32</summary>
        TYPE,
        ///<summary>call</summary>
        CALL,
        ///<summary>const or var</summary>
        CHANGEMODE,
        ///<summary>copy or ref</summary>
        MECHMODE,
        ///<summary>debugin</summary>
        DEBUGIN,
        ///<summary>debugout</summary>
        DEBUGOUT,
        ///<summary>do</summary>
        DO,
        ///<summary>else</summary>
        ELSE,
        ///<summary>endfun (no fun for you, sorry)</summary>
        ENDFUN,
        ///<summary>endif</summary>
        ENDIF,
        ///<summary>endproc</summary>
        ENDPROC,
        ///<summary>endprogram</summary>
        ENDPROGRAM,
        ///<summary>endwhile</summary>
        ENDWHILE,
        ///<summary>false, true, /[0-9]+/ or /[0-9]+\.[0-9]+m/</summary>
        LITERAL,
        ///<summary>fun (here, have some fun)</summary>
        FUN,
        ///<summary>global</summary>
        GLOBAL,
        ///<summary>if</summary>
        IF,
        ///<summary>in, inout or out</summary>
        FLOWMODE,
        ///<summary>init</summary>
        INIT,
        ///<summary>local</summary>
        LOCAL,
        ///<summary>not</summary>
        NOT,
        ///<summary>proc</summary>
        PROC,
        ///<summary>program</summary>
        PROGRAM,
        ///<summary>returns</summary>
        RETURNS,
        ///<summary>skip</summary>
        SKIP,
        ///<summary>then</summary>
        THEN,
        ///<summary>while</summary>
        WHILE,
        ///<summary>[a-zA-Z][a-zA-z0-9]*</summary>
        IDENT,
    }
>>>>>>> 83e2fa2afc7da70bbf14d9d58904258dbdf2389e:Compiler/Compiler/01Scanner/Token/Terminals.cs
}
