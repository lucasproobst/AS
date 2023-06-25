using System.ComponentModel.DataAnnotations;

namespace API_AP2_POO.Models;
public class City
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public int Population { get; set; }
    [Required]
    public List<People> People { get; set; }

}