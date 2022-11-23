namespace ProductsApi.Dto
{
    public record PutProductRequest : PostProductRequest
    {
        public Guid Id { get; set; }
    }
}
