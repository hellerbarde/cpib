using System;

namespace Compiler
{
  public interface IASTStoDecl : IASTDecl
  {
    Type Type { get; set; }
  }
}
