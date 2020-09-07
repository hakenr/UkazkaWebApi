using System;
using System.ComponentModel.DataAnnotations;

namespace UkazkaWebApi.Controllers
{
	public class InfectedIM
	{
		public string Email { get; set; }
		public DateTime	TestDate { get; set; }
		public string City { get; set; }
	}
}