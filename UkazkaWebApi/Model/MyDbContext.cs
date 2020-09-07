using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkazkaWebApi.Model
{
	public class MyDbContext : DbContext
	{
		public DbSet<Infected> InfectedDbSet { get; set; }

		public MyDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}

		protected MyDbContext()
		{
		}
	}
}
