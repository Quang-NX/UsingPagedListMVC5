using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LoaiThanhVien
    {
        [Key]
        public int MaLoaiTV { get; set; }
        public string TenLoaiTV { get; set; }
        public string UuDai { get; set; }
        public virtual ICollection<ThanhVien> ThanhViens { get; set; }
    }
}
