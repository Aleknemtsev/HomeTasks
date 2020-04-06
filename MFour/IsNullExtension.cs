using System;
using System.Collections.Generic;
using System.Text;

namespace MFour
{
	public static class IsNullExtension
	{
		public static bool IsNull(this object obj)
		{
			if (obj == null)
				return true;
			else
				return false;
		}

	}
}
