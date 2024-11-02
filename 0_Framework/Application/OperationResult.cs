namespace Framework.Application
{
    public class OperationResult
    {
        public int Id { get; set; }
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }

        public OperationResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message = "عملیات ناموفق بود!")
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
