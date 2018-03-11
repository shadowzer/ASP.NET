using System;
using System.ComponentModel.Composition;
using System.IO;

namespace MEFLogger {
	[Export(typeof(ILogger))]
	public class Logger : ILogger {
		public void Log(string message) {
			var log = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t" + message;
			Console.WriteLine(log);
			
			var tempEnvVar = Environment.GetEnvironmentVariable("TEMP");
			File.AppendAllLines(tempEnvVar + "/test.log", new string[] {log});
		}
	}
}