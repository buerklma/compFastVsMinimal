namespace ProductsApi.Dto
{
    public record PostProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
