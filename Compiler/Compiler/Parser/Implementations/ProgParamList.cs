using System;
using System.Collections;
using System.Collections.Generic;

namespace Compiler
{
	public class ProgParamList :IProgParamList
	{
    #region IProgParamList implementation
    public IProgParams progParams { get; set; }
    #endregion
	}
}

