using System;

namespace Compiler
{
  public partial class ASTAddOpr : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTArrayAccess : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTArrayLiteral : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTBoolLiteral : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTBoolOpr : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCmdCall : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCmdDebugIn  : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCmdDebugOut : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCmdIdent : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCmdSkip : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTComma : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCpsCmd : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTCpsDecl : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTDecimalLiteral : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTEmpty : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTExpression : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTGlobalParam : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTIdent  : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTIf : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTIntLiteral : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTMultOpr : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTOptInit : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTParam : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTProcFuncDecl: ASTCpsDecl
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTProgram : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTRelOpr : ASTExpression
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTSliceExpr : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTStoDecl : ASTCpsDecl
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTType : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTTypeOrArray : IASTNode
  {
    public virtual String EmitCode()
    {
      throw new NotImplementedException();
    }
  }

  public partial class ASTWhile : ASTCpsCmd
  {
    public override String EmitCode()
    {
      throw new NotImplementedException();
    }
  }
}