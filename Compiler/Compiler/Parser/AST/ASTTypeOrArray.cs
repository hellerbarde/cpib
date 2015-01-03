using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compiler
{
  public partial class ASTTypeOrArray : IASTNode
  {
    public ASTTypeOrArray()
    {
    }

    public Boolean isArray { get; set; }

    public Type Type { get; set; }

    public List<int> dimensions { get; set; }
 

    //public IASTNode Expr { get; set; }

    public override string ToString()
    {
      //return "";
      if (isArray) {
        return string.Format("array ({0}) {1}", string.Join(", ", dimensions), Type);
      }
      else {
        return Type.ToString();
      }
    }

    public void printAST(int level, StringBuilder sb)
    {
      throw new NotImplementedException();
    }

    public virtual int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info)
    {
      throw new System.NotImplementedException();
    }
  }
}

