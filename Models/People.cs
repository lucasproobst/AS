using System.ComponentModel.DataAnnotations;

namespace API_AP2_POO.Models;

public class People
{
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }        
    [Required]
    public string Age { get; set; }        
    [Required]
    public int CityId { get; set; }
    [Required]
    public City City { get; set; }
}