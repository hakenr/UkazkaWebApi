using System;
using System.ComponentModel.DataAnnotations;

namespace UkazkaWebApi.Model
{
	public class Infected
	{
		[Key]
		public int Id { get; set; }
		public string Email { get; set; }
		public DateTime TestDate { get; set; }
		public string City { get; set; }
		public string ClientIpAddress { get; set; }
	}
}