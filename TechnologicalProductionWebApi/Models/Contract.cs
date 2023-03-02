namespace TechnologicalProductionWebApi.Models;

public class Contract
{
    public string Name { get; set; }
    public int Count { get; set; }

    public int BuildingId { get; set; }
    public ProductionBuilding ProductionBuilding { get; set; }

    public int TypeId { get; set; }
    public TypeOfEquipment TypeOfEquipment { get; set; }
}