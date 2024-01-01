namespace BankingBackend.Application.Common.Models
{
    public class PaginationModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
