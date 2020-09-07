using System;

namespace UkazkaWebApi.Controllers
{
	internal class Infected
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public DateTime	TestDate { get; set; }
		public string City { get; set; }
		public string ClientIpAddress { get; set; }
	}
}