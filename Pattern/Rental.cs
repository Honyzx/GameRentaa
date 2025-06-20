using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pattern;

public class Rental
{
    public enum RentalStatus
    {
        Reserved,
        Active,
        Completed,
        Overdue,
        Cancelled
    }
    public int ID { get; set; }
    [Key] public int RentalID { get; set; }
    [Required] public int UserID { get; set; }
    [ForeignKey("UserID")] public Users User { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime PlannedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public RentalStatus Status { get; set; }
    public decimal TotalCost { get; set; }
    public decimal DepositPaid { get; set; }
    public decimal DepositReturned { get; set; }
    public string Notes { get; set; } = "";
    public ICollection<Fine> Fines { get; set; } 
}