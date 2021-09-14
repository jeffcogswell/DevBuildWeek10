using DapperMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult categories()
		{
			MySqlConnection db = new MySqlConnection("Server=localhost;Database=grocerystore;Uid=root;Password=abc123");
			List<Category> cats = db.GetAll<Category>().ToList();
			return View(cats);
		}

		public IActionResult category(string cat)
		{
			MySqlConnection db = new MySqlConnection("Server=localhost;Database=grocerystore;Uid=root;Password=abc123");
			// Dapper will convert the following quoted SQL:
			//       select * from product where category=@mycat
			// to this:
			//       select * from product where category='FRUIT'
			// if they passed, for example, FRUIT in.
			List<Product> prods = db.Query<Product>("select * from product where category=@mycat", new { mycat = cat }).ToList();
			ViewData["Name"] = cat;
			return View(prods);
		}

		public IActionResult product(int pr)
		{
			MySqlConnection db = new MySqlConnection("Server=localhost;Database=grocerystore;Uid=root;Password=abc123");
			Product prod = db.Get<Product>(pr);
			return View(prod);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
