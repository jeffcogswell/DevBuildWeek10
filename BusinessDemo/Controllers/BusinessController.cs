using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDemo.Models;

namespace BusinessDemo.Controllers
{
	public class BusinessController : Controller
	{
		/*
		 *    Routes:
		 *    
		 *         /business   -- list all the departments
		 *         /business/department?dept=sales  -- list all employees in a department
		 *         /business/employee?emp=10 -- list details for employee by ID
		 *         /business/addform -- present the user with a form to add an employee
		 *         /business/addemp -- create a new employee
		 *         /business/editform?empid=5 -- present user with form to edit an employee
		 *         /business/saveemp -- save edited employee
		 */

		public IActionResult Index()
		{
			List<Department> results = DAL.GetAllDepartments();
			return View(results);
		}

		public IActionResult department(string dept)
		{
			List<Employee> results = DAL.GetEmpsInDept(dept);
			Department thedept = DAL.GetDepartment(dept);
			ViewData["DeptName"] = thedept.name;
			return View(results);
		}

		public IActionResult employee(int emp)
		{
			Employee theemp = DAL.GetEmployee(emp);
			return View(theemp);
		}

		public IActionResult delete(int id)
		{
			// Delete the employee
			DAL.DeleteEmployee(id);
			// Return a view or something
			// Don't do this, because the URL will still show "delete":
			//List<Department> results = DAL.GetAllDepartments();
			//return View("index", results);

			return Redirect("/business");
		}

		public IActionResult add()
		{
			return View();
		}

		public IActionResult add(Employee emp)
		{
			DAL.InsertEmployee(emp);
			return Redirect($"/business/department?dept={emp.department}");
		}

		public IActionResult editform(int empid)
		{
			Employee emp = DAL.GetEmployee(empid);
			return View(emp);
		}

		public IActionResult saveemp(Employee emp)
		{
			DAL.UpdateEmployee(emp);
			return Redirect($"/business/employee?emp={emp.id}");
		}
	}
}
