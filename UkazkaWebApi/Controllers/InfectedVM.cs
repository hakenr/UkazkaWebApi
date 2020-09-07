using System;

namespace UkazkaWebApi.Controllers
{
	public class InfectedVM
	{
		public string Email { get; internal set; }
		public string City { get; internal set; }
		public DateTime TestDate { get; internal set; }
		public string ClientIpAddress { get; internal set; }
		public int Id { get; internal set; }
	}
}