namespace ProductsApi.Dto
{
    public record ProductResponse : ProductRequest
    {
        public Guid Id { get; set; }
    }
}
