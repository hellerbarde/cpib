using System;

namespace Compiler
{
    public interface IASTDecl
    {
        string Ident { get; set; }
        int Address { get; set; }
        int Size();
    }
}
