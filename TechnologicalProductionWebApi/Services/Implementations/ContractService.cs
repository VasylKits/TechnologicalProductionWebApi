using Microsoft.EntityFrameworkCore;
using TechnologicalProductionWebApi.DB;
using TechnologicalProductionWebApi.DTOs;
using TechnologicalProductionWebApi.Models;
using TechnologicalProductionWebApi.Services.Interfaces;

namespace TechnologicalProductionWebApi.Services.Implementations;

public class ContractService : IContractService
{
    private readonly ApplicationDbContext _context;

    public ContractService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IResult<AddContractResponse>> CreateContract(AddContract request)
    {
        try
        {
            var contract = new Contract()
            {
                Name = request.Name,
                BuildingId = request.BuildingId,
                TypeId = request.TypeId,
                Count = request.Count
            };

            var building = await _context.ProductionBuildings.FirstOrDefaultAsync(x => x.Id == request.BuildingId);
            var equipment = await _context.TypeOfEquipments.FirstOrDefaultAsync(x => x.Id == request.TypeId);

            var freeSquare = building.FreeSquare - (equipment.Square * contract.Count);
            building.FreeSquare = freeSquare;

            if (building.FreeSquare <= 0)
            {
                return new Result<AddContractResponse>
                {
                    IsError = true,
                    ErrorMessage = "Error! The equipment square is much than building square!"
                };
            }

            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();

            var result = new AddContractResponse()
            {
                Name = contract.Name,
                BuildingId = contract.BuildingId,
                BuildingName = contract.ProductionBuilding.Name,
                TypeId = contract.TypeId,
                EquipmentName = contract.TypeOfEquipment.Name,
                Count = contract.Count
            };

            return new Result<AddContractResponse>
            {
                Response = result
            };
        }

        catch (Exception ex)
        {
            return new Result<AddContractResponse>
            {
                IsError = true,
                ErrorMessage = $"[CreateContract] : {ex.Message}"
            };
        }
    }

    public async Task<IResult<List<ContractResponse>>> GetContracts()
    {
        try
        {
            var contracts = await _context.Contracts.Select(x => new ContractResponse
            {
                Name = x.Name,
                BuildingName = x.ProductionBuilding.Name,
                TypeOfEquipmentName = x.TypeOfEquipment.Name,
                Count = x.Count
            }).ToListAsync();

            return new Result<List<ContractResponse>>
            {
                Response = contracts
            };
        }

        catch (Exception ex)
        {
            return new Result<List<ContractResponse>>
            {
                IsError = true,
                ErrorMessage = $"[GetContracts] : {ex.Message}"
            };
        }
    }
}