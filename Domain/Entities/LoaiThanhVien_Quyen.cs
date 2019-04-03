using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LoaiThanhVien_Quyen
    {
        public string GhiChu { get; set; }
        [Key]
        [Column(Order =1)]
        public int MaLoaiTV { get; set; }
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
        [Key]
        [Column(Order =2)]
        public int MaQuyen { get; set; }
        public virtual Quyen Quyen { get; set; }
    }
}
