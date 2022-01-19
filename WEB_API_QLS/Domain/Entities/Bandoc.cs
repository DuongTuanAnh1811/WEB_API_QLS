using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Bandoc
    {
        public Bandoc()
        {
            Ngaymuons = new HashSet<Ngaymuon>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Ho { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Gioitinh { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public int? Ngaysinh { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public int? Thangsinh { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public int? Namsinh { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string Sodienthoai { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        public string MaSv { get; set; }
       

        
        public virtual ICollection<Ngaymuon> Ngaymuons { get; set; }
    }
}
