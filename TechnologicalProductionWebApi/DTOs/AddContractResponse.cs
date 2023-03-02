namespace TechnologicalProductionWebApi.DTOs;

public class AddContractResponse
{
    public string Name { get; set; }
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public int TypeId { get; set; }
    public string EquipmentName { get; set; }
    public int Count { get; set; }
}