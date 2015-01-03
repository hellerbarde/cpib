using System.Text;

namespace Compiler
{
  public interface IASTNode
  {
    int GenerateCode(int loc, IVirtualMachine vm, CheckerInformation info);

    void printAST(int level, StringBuilder sb);
  }
}
