using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BusinessDemo.Models
{
	public class DAL
	{
		// Database connection
		public static MySqlConnection DB = new MySqlConnection("Server=localhost;Database=business;Uid=root;Password=abc123");

		// Read all departments
		// Return a list of Department instances

		public static List<Department> GetAllDepartments()
		{
			return DB.GetAll<Department>().ToList();
		}

		// Read all employees in one department
		public static List<Employee> GetEmpsInDept(string dept)
		{
			return DB.Query<Employee>("select * from employee where department = @mydept", new { mydept = dept }).ToList();
		}

		// Read the details for a department by id
		public static Department GetDepartment(string id)
		{
			return DB.Get<Department>(id);
		}

		// Read the details for an employee by id
		public static Employee GetEmployee(int id)
		{
			return DB.Get<Employee>(id);
		}

		// Delete an employee by ID
		public static void DeleteEmployee(int id)
		{
			Employee emp = new Employee();
			emp.id = id;
			DB.Delete<Employee>(emp);
		}

		// Save a new employee (i.e. "insert") ("C" in CRUD for create)
		public static void InsertEmployee(Employee emp)
		{
			DB.Insert(emp);
		}

		// Update an employee
		public static void UpdateEmployee(Employee emp)
		{
			DB.Update(emp);
		}
	}

}
