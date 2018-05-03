using System;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace RoslynAppDomain {
	public class Calculator : MarshalByRefObject {
		public double Calculate(string expression, Globals globals) {
			return CSharpScript.EvaluateAsync<double>(
					code: expression,
					options: ScriptOptions.Default.WithImports("System.Math"),
					globals: globals)
				.Result;
		}
	}
}