namespace TechnologicalProductionWebApi.Models;

public class TypeOfEquipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Square { get; set; }

    public List<Contract> Contracts { get; set; }
}