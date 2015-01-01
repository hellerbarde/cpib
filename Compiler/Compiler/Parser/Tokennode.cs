using System;

namespace Compiler
{
  public partial class Tokennode : Treenode
  {
    public Token Token { get; private set; }

    public Tokennode(Token token)
    {
      this.Token = token;
    }
  }
}

