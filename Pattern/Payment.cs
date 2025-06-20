using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pattern;

public class Payment
{
    public enum PaymentMethod
    {
        Cash,
        Card,
        Online
    }

    public enum PaymentType
    {
        Rental,
        Deposit,
        DepositReturn,
        Fine
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }
    public int ID { get; set; }
    [Key] public int PaymentID { get; set; }
    [Required] int RentalID { get; set; }
    [ForeignKey("RentalID")] public Rental Rental { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethods { get; set; }
    public PaymentType PaymentTypes { get; set; }
    public string TransactionID { get; set; } = "";
    public PaymentStatus Status { get; set; }
}