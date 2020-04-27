using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
	interface ICodeChecker
	{
		bool CheckCodeSyntax(string line, string language);
	}
}
