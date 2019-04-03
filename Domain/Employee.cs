using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	[Table("Employees")]
	public class Employee
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public float Slary { get; set; }
	}
}
