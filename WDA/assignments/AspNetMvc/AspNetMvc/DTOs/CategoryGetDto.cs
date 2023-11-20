namespace AspNetMvc.DTOs
{
    public class CategoryGetDto
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<ProductGetDto>? Products { get; set; }
    }
}
