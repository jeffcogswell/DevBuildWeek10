using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BusinessDemo.Models
{
	[Table("employee")]
	public class Employee
	{
		[Key]
		public int id { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string department { get; set; }
	}
}
