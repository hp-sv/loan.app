
namespace Loan.Model
{
    public abstract class PagedResultDtoBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int FirstRowOnPage { get; set; }        
        public int LastRowOnPage { get; set; }
    }

    public class PagedResultDto<T> : PagedResultDtoBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResultDto()
        {
            Results = new List<T>();
        }
    }
}
