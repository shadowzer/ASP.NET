using System;
using DryIoc;
using DryIoc.Experimental;
using MySql.Data.MySqlClient;

namespace DryIoC
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = InitContainer();
			container.Get<IDatabase>().Execute("select id, username from user");
			Console.ReadLine();
		}

		private static IContainer InitContainer()
		{
			var container = new Container();
			container.Register<ILogger, ConsoleLogger>(Reuse.Singleton);
			container.Register<IDatabase, MySQLDatabase>(Reuse.Transient);
			return container;
		}
	}

	interface ILogger
	{
		void Log(string message);
	}

	interface IDatabase
	{
		void Execute(string query);
	}

	class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}

	class MySQLDatabase : IDatabase
	{
		public void Execute(string query)
		{
			var container = new Container();

			var connection = new MySqlConnection("server=localhost;user=myuser;database=mydb;password=mypass;");
			connection.Open();
			var command = new MySqlCommand(query, connection);
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				container.Get<ILogger>().Log(reader[0].ToString() + "\t" + reader[1].ToString());
			}

			reader.Close();
			connection.Close();
		}
	}
}
