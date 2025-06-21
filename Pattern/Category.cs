namespace Pattern;

public class Category
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ICollection<Game> Games { get; set; }=new List<Game>();
}