using System;
using System.Reflection;

namespace RoslynAppDomain {
	public static class Program {
		public static void Main(string[] args) {
			AppDomain domain = AppDomain.CreateDomain("test");
			domain.Load(Assembly.GetExecutingAssembly().GetName());
			var calc = (Calculator) domain.CreateInstanceAndUnwrap(
				assemblyName: Assembly.GetExecutingAssembly().FullName,
				typeName: "RoslynAppDomain.Calculator");

			for (var i = 0; i < 10; i++) {
				var random = new Random(20);
				var globals = new Globals {X = random.NextDouble(), Y = random.NextDouble()};
				const string expression = "(Math.Pow(X,2)+12)/Math.Sqrt(Y)";
				Console.WriteLine($"The result of ${expression} with variables ${globals.ToString()} is " +
				                  calc.Calculate(expression, globals));
			}

			Console.WriteLine("Finished");
			Console.ReadLine();
		}
	}
}