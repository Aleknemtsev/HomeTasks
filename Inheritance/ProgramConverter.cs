using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
	public class ProgramConverter : IConvertible
	{
		public string ConvertToCSharp(string line)
		{
			return line + "\n converted to CSharp";
		}

		public string ConvertToVB(string line)
		{
			return line + "\n converted to VB";
		}
	}
}
