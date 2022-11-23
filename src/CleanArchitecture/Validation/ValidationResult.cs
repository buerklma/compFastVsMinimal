namespace ProductsApi.Resources
{
    internal record ValidationResult
    {
        public bool IsValid { get; init; }
        public IResult? ValidationProblem { get; init; }
    }
}
