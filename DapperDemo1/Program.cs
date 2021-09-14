using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib;
using System;
using System.Collections.Generic;

namespace DapperDemo1
{

	class Employee
	{
		public string employeeId { get; set; }
		public string lastname { get; set; }
		public string firstname { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			MySqlConnection conn = new MySqlConnection("Server=localhost;Database=Northwind;Uid=root;Password=abc123");
			// Let's query the employee table with a select * from employee
			IEnumerable<Employee> result = conn.Query<Employee>("select * from employee");
			foreach (Employee item in result)
			{
				Console.WriteLine($"{item.employeeId} {item.lastname} {item.firstname}");
			}

		}
	}
}
