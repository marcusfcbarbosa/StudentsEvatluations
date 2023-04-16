namespace Studentes.Evaluation.Shared
{
    public interface IQueryResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
