using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Quequan
    {
        public Quequan()
        {
            
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Quan { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Huyen { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Thanhpho { get; set; }

     
        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
