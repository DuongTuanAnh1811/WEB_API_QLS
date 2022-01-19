using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        [DataType(DataType.Text)]
        public string TheLoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
