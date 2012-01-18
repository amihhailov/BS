using System;

namespace UI
{
	public class MustBeOverridenException : Exception
	{
		public MustBeOverridenException(string name) : base("Property or method " + name + " must be overrriden")
		{
		}
	}
}