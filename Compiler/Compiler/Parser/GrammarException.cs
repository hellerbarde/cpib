using System;

namespace Compiler
{
  public class GrammarException : Exception
  {
    public GrammarException(String ErrorMessage) :base (ErrorMessage)
    {

    }

    public GrammarException(String ErrorMessage, int Line, int Column) :
    this(
      String.Format("[PARSER] (Line: {0}, Column: {1}) {2}", 
        Line, 
        Column, 
        ErrorMessage))
    {

    }
  }
}

