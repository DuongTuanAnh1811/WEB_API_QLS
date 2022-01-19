using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_API_QLS.Domain.Entities
{
    public partial class Ngaymuon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} cần thiết lập")]
        [DataType(DataType.DateTime)]
        public DateTime? NgayMuon { get; set; }
        public int? SachId { get; set; }
        public int? BandocId { get; set; }

        public virtual Bandoc Bandoc { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
