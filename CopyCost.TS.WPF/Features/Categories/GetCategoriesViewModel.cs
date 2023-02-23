using CopyCost.TS.WPF.Models.DTOs;

namespace CopyCost.TS.WPF.Features.Categories;

public class GetCategoriesViewModel
{
    public IEnumerable<CategoryDto> Categories { get; set; }
}