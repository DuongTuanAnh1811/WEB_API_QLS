using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Sach
    {
        public Sach()
        {
            Ngaymuons = new HashSet<Ngaymuon>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Tensach { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        [RegularExpression("^[0-9]+$")]
        public int? Soluong { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Tinhtrang { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Tacgia { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        [DataType(DataType.DateTime)]
        public DateTime? Ngaynhap { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public int? TheloaiId { get; set; }

        public virtual Theloai Theloai { get; set; }
        public virtual ICollection<Ngaymuon> Ngaymuons { get; set; }
    }
}
