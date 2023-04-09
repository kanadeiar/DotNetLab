namespace AspNetCore.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Пожалуйста, ведите наименование товара")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Пожалуйста, введите описание")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
    public string Category { get; set; } = string.Empty;
    [Required, Range(double.Epsilon, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительную цену")]
    [Column(TypeName="decimal(8, 2)")]
    public decimal Price { get; set; }
}