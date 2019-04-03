using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class DbConnectionstring :DbContext
	{ 
		public DbConnectionstring():base("DbConnectionstring")
		{

		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<LoaiThanhVien> LoaiThanhViens { get; set; }
		public DbSet<Quyen> Quyens { get; set; }
		public DbSet<LoaiThanhVien_Quyen> LoaiThanhVien_Quyens { get; set; }
	}
}
