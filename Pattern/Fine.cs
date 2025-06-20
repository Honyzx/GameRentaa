using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pattern;

public class Fine
{
    public enum FineStatus
    {
        Pending,
        Paid,
        Waived
    }
    public int ID { get; set; }
    [Key] public int FineID { get; set; }
    [Required] int RentalID { get; set; }
    [ForeignKey("RentalID")] public Rental Rental { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; } = "";
    public DateTime IssueDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public FineStatus Status { get; set; }
}