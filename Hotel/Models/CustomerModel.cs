using System.ComponentModel.DataAnnotations;

namespace Hotel.Models {
    public class CustomerModel {
        public int Id { get; set; }

        //[Required(ErrorMessage ="姓名不能为空")]
        [RegularExpression(@"^\w{4,}$", ErrorMessage = "字母数字下划线,长度大于4")]
        public string Name { get; set; }

        [Required(ErrorMessage = "描述不能为空")]
        public string ReMark { get; set; }
    }
}