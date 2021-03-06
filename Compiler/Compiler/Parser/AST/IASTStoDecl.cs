using System;

namespace Compiler
{
  public interface IASTStoDecl : IASTDecl
  {
    ASTTypeOrArray TypeOrArray { get; set; }
    int Size();
    bool isInitialized{ get; set; }
  }
}
