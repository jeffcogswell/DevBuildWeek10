using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace DapperDemo3
{
	[Table("category")]
	class Category
	{
		[Key]
		public string id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string location { get; set; }
	}
}
