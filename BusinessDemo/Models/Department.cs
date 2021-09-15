using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BusinessDemo.Models
{
	[Table("department")]
	public class Department
	{
		[Key]
		public string id { get; set; }
		public string name { get; set; }
		public string location { get; set; }
	}
}
