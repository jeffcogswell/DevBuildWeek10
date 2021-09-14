using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperDemo2
{
	[Table("employee")]
	class Employee
	{
		[Key]
		public string employeeId { get; set; }
		public string lastname { get; set; }
		public string firstname { get; set; }
		public override string ToString()
		{
			return $"{employeeId} {firstname} {lastname}";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			MySqlConnection conn = new MySqlConnection("Server=localhost;Database=Northwind;Uid=root;Password=abc123");
			// Let's query the employee table with a select * from employee
			IEnumerable<Employee> result = conn.GetAll<Employee>().ToList();
			foreach (Employee item in result)
			{
				Console.WriteLine(item);
			}

		}
	}
}
