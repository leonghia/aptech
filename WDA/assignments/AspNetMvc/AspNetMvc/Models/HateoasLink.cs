namespace AspNetMvc.Models
{
    public class HateoasLink
    {
        public required string? Href { get; set; }
        public required string Rel { get; set; }
        public required string Method { get; set; }
    }
}
