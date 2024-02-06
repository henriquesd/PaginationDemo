namespace PaginationDemo.Domain.Models
{
    public record PagedResponseKeyset<T>
    {
        public int Reference { get; init; }
        public List<T> Data { get; init; }

        // Other properties might be added;

        public PagedResponseKeyset(List<T> data, int reference)
        {
            Data = data;
            Reference = reference;
        }
    }
}