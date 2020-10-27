using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
	/// <summary>
	/// Singleton Design pattern is one of the simplest design patterns. 
	/// This pattern ensures that a class has only one instance and provides a global point of access to it.
	/// </summary>
	class SingletonPattern
	{
		public void ExecuteSingletonPattern()
		{ 
		
		}
	}

	// ThreadSafe
	public class Singleton
	{
		private static Singleton instance = null;
		private Singleton() { }
		private static object lockThis = new object();

		public static Singleton GetInstance
		{
			get
			{
				lock (lockThis)
				{
					if (instance == null)
						instance = new Singleton();

					return instance;
				}
			}
		}
	}
}
