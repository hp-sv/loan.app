namespace Loan.Entity
{

    public class BusinessValidationError
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }

    public class ValidationError
    {
        public int Code { get; set; }
        public string Message { get; set; }        
    }
}
