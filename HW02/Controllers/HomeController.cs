using System.Diagnostics;
using HW02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HW02.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
		{
			_logger = logger;
			_hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Regis(Regis abs)
		{
			if (ModelState.IsValid)
			{
				if (abs.Image != null)
				{
					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}

					string uniqueFileName = Guid.NewGuid().ToString() + "_" + abs.Image.FileName;

					string filePath = Path.Combine(uploadsFolder, uniqueFileName);

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						abs.Image.CopyTo(fileStream);
					}

					ViewBag.ImageUrl = $"/images/{uniqueFileName}";
				}
				return View("Success", abs);
			}
			return View(abs);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
