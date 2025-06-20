using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pattern;

public class RentalItem
{
    public int ID { get; set; }
    [Key] public int RentalItemID { get; set; }
    [Required] int RentalID { get; set; }
    [ForeignKey("RentalID")] public Rental Rental { get; set; }
    [Required] int GameID { get; set; }
    [ForeignKey("GameID")] public Game Game { get; set; }
    public int Quantity { get; set; }
    public decimal DailyPrice { get; set; }
    public decimal DepositAmount { get; set; }
}