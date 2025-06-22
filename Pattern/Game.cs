using System.ComponentModel.DataAnnotations;

namespace Pattern;

public class Game
{
   
    public int ID { get; set; }
    [Key] public int GameID { get; set; }
    [Required] public string Title { get; set; } = "";
     public string Description { get; set; } 
    public int ReleaseYear { get; set; }
    public decimal DailyRentalPrice { get; set; }
    public decimal DepositAmount { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public ICollection<RentalItem> RentalItems  { get; set; } 
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}