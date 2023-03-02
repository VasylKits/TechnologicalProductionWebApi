namespace TechnologicalProductionWebApi.Models;

public class ProductionBuilding
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Square { get; set; }
    public double FreeSquare { get; set; }

    public List<Contract> Contracts { get; set; }

    public ProductionBuilding()
    {
        FreeSquare = Square;
    }
}