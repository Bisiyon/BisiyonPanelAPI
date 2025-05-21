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
}