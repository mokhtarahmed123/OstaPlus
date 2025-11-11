using System.ComponentModel.DataAnnotations;

namespace OSTA.BLL.DTOs.CategoryDTOS
{
    public class AddCategory
    {
        [Required, MaxLength(50), MinLength(2)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
