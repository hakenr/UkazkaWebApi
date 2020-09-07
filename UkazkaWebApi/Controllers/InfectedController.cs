using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UkazkaWebApi.Model;

namespace UkazkaWebApi.Controllers
{
	[ApiController]
	public class InfectedController : Controller
	{
		private readonly MyDbContext dbContext;

		private static List<Infected> InfectedItems { get; } = new List<Infected>();

		public InfectedController(MyDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpPost("api/infected/new")]
		public int CreateInfected([FromBody] InfectedIM inputModel)
		{
			var infectedEntity = new Infected()
			{
				Email = inputModel.Email,
				City = inputModel.City,
				TestDate = inputModel.TestDate,
				// Id = new Random().Next(),
				ClientIpAddress = this.HttpContext.Connection.RemoteIpAddress.ToString()
			};

			dbContext.InfectedDbSet.Add(infectedEntity);
			dbContext.SaveChanges();

			return infectedEntity.Id;
		}

		[HttpPut("api/infected/{id:int}")]
		public InfectedVM UpdateInfected(int id, [FromBody] InfectedIM inputModel)
		{
			var item = dbContext.InfectedDbSet.FirstOrDefault(item => item.Id == id);
			if (item == null)
			{
				return null;
			}
			item.Email = inputModel.Email;
			item.City = inputModel.City;
			item.TestDate = inputModel.TestDate;
			item.ClientIpAddress = this.HttpContext.Connection.RemoteIpAddress.ToString();
			dbContext.SaveChanges();

			return MapToInfectedVM(item);

		}

		[HttpGet("api/infected")]
		public List<InfectedVM> GetInfectedList()
		{
			return dbContext.InfectedDbSet.Select(item => MapToInfectedVM(item)).ToList();
		}

		[HttpGet("api/infected/{id:int}")]
		public InfectedVM GetInfectedItem(int id)
		{
			return dbContext.InfectedDbSet
				.Where(item => item.Id == id)
				.Select(item => MapToInfectedVM(item)).FirstOrDefault();
		}

		private static InfectedVM MapToInfectedVM(Infected item)
		{
			return new InfectedVM()
			{
				Email = item.Email.Substring(0, 2) + "...@..." + item.Email.Substring(item.Email.Length - 2, 2),
				City = item.City,
				TestDate = item.TestDate,
				ClientIpAddress = item.ClientIpAddress,
				Id = item.Id,
			};
		}
	}
}
