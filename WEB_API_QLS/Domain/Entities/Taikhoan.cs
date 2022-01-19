using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        [RegularExpression("^[a-zA-Z0-9]+@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+$")]
        public string Email { get; set; }
        [RegularExpression("^[a-zA-Z0-9_.+-]+$")]
        public string Password { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }



    }
}
