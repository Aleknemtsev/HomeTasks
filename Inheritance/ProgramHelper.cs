using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
	class ProgramHelper : ProgramConverter, ICodeChecker
	{
		public bool CheckCodeSyntax(string line, string language)
		{
			if ((line == "CScode" && language == "CS") || (line == "VBcode" && language == "VB"))
				return true;
			else
				return false;
		}
	}
}
