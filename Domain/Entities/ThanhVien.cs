using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ThanhVien
    {
        [Key]
        public int MaThanhVien { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        //khởi tạo MaLoaiTV để thực hiện mapping
        public int MaLoaiTV { get; set; }
        //khai báo khóa ngoại
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
    }
}
