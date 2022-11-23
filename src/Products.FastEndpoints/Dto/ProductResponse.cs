namespace ProductsApi.Dto
{
    public record ProductResponse : PostProductRequest
    {
        public Guid Id { get; set; }
    }
}
