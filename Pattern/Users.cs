using System.ComponentModel.DataAnnotations;

namespace Pattern;

public class Users
{

    public int ID { get; set; }
    [Key] public int UserID { get; set; }
    [Required] public string FirstName { get; set; } = "";
    [Required] public string LastName { get; set; } = "";
    [Required] public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public static DateTime RegistrationDate { get; set; }
    public ICollection<Rental> Rentals { get; set; } 
}