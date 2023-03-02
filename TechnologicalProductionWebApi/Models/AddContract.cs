using System.ComponentModel.DataAnnotations;

namespace TechnologicalProductionWebApi.DTOs;

public class AddContract
{
    public string Name { get; set; }
    [Required]
    public int BuildingId { get; set; }
    [Required]
    public int TypeId { get; set; }
    [Required]
    public int Count { get; set; }
}