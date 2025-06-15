namespace BisiyonPanelAPI.Common
{
    public interface IResult
    {
        bool IsSuccessfull { get; }
        string? Message { get; set; }
        ResultState State { get; set; }
        Exception? Exception { get; set; }
    }

    public interface IResult<T> : IResult
    {
        public T Data { get; set; }
    }

    public interface IResult<T, K> : IResult<T>
    {
        public K Data2 { get; set; }
    }

    public class Result : IResult
    {
        public ResultState State { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public bool IsSuccessfull { get { return State == ResultState.Successfull; } }
    }

    public class Result<T> : IResult<T>
    {
        public T Data { get; set; }
        public ResultState State { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public bool IsSuccessfull { get { return State == ResultState.Successfull; } }
    }

    public class Result<T, K> : IResult<T, K>
    {
        public T Data { get; set; }
        public K Data2 { get; set; }
        public ResultState State { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }
        public bool IsSuccessfull { get { return State == ResultState.Successfull; } }
    }


    public class PagedResult<T> : Result<T>, IPagedResult
    {
        public PagedResult()
        {
            ActivePage = 1;
            PageSize = 30;

        }
        public int ActivePage { get; set; }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                {
                    return 0;
                }
                double count = (double)TotalRowCount / (double)PageSize;
                return (int)Math.Ceiling(count);
            }

        }
        public long TotalRowCount { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Query { get; set; }
        public object[] Parameters { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int SecondDataPage { get; set; }
        public int SecondDataPageCount { get; set; }
    }

    public interface IPagedResult
    {
        int ActivePage { get; set; }
        int PageSize { get; set; }
        int PageCount { get; }
        long TotalRowCount { get; set; }
        string Title { get; set; }
        string Link { get; set; }
        string Query { get; set; }
        object[] Parameters { get; set; }
        string Controller { get; set; }
        string Action { get; set; }
        int SecondDataPage { get; set; }
        int SecondDataPageCount { get; set; }
    }

}