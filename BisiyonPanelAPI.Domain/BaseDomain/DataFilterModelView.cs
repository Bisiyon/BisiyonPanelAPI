using Castle.DynamicLinqQueryBuilder;
public class DataFilterModelView
{
        public int Page { get; set; }
        public int PageSize { get; set; }
        public QueryBuilderFilterRule FilterQuery { get; set; }
        public int FilterId { get; set; }
        public string OrderByField { get; set; }
        public bool OrderByIsAsc { get; set; } = true;
        public int SecondDataPage { get; set; }
        public int SecondDataPageCount { get; set; }
}