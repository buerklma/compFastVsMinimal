namespace ProductsApi.Dto
{
    public record ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
