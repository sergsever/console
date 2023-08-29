using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace console.data
{
	public class DataContext : DbContext
    {
		public DataContext() : base()
		{
			Console.WriteLine("dbcontext initialize.");
		}

		public void Init()
		{
			//			Database.in
			Console.WriteLine("Init,migrations\n");
			var migrator = Database.GetService<IMigrator>();
			migrator.Migrate();
			

		}

		override protected  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured) {
				//IConfiguration conf = new ConfigurationBuilder().AddJsonFile( Directory.GetCurrentDirectory() + @"\appsettings.json", optional: false, reloadOnChange: false).Build();
				//var conns = conf.GetSection("ConnectionStrings")["postgresql"];
				string conn = System.Configuration.ConfigurationManager.ConnectionStrings["postgres"].ConnectionString;   //ConnectionStrings["postgres"];
			//optionsBuilder.UseSqlServer(conn);
			optionsBuilder.UseNpgsql(conn);
		}

		}

		public DbSet<Item> Items { get; set; }

	}
}
