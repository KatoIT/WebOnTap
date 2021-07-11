namespace An181203458.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        /* [StringLength(<max_length>, MinimumLength = <min_length>)]
                    VD: [StringLength(9, MinimumLength = 4, ErrorMessage = "Số ký tự từ 4 đến 9")]
         */

        /* [Required(ErrorMessage = <error-message>)]
                    VD: [Required(ErrorMessage = "Không được để trống")]
         */

        /*[RegularExpression(<pattern>)]
                    VD: [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email không hợp lệ.")]
                    VD: [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Chỉ nhập số")]
                    VD: [RegularExpression(@"^[\w,\s-]+\.jpg$", ErrorMessage = "Đuôi ảnh là .jpg.")]
         */

        /*[Range (<minimum_range>, <maximum_range>)]
                    VD: [Range(10, 100, ErrorMessage = "Giá trị phải nằm trong khoảng 10 đến 100")]
         */

        /* [DisplayName(<text>)] Hiển thị trước input
                    VD: [DisplayName("User Name")]
         */

        // [DataType(DataType.<value>)] VD: [DataType(DataType.Password)]

        [Key]
        public int MaHang { get; set; }

        public int MaLoai { get; set; }

        [Required]

        public string TenHang { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Gia { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }
    }
}
