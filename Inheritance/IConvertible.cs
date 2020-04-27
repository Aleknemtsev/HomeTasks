using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
	public interface IConvertible
	{
		string ConvertToCSharp(string line);

		string ConvertToVB(string line);
	}
}
