namespace Loan.Entity
{
    public interface ILoanEntity
    {
        public string CreateBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }        
        public Guid TransactionId { get; set; }
        public int VersionNo { get; set; } 
        public int RecordStatusId { get; set; }
    }
}
