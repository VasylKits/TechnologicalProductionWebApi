using TechnologicalProductionWebApi.DTOs;

namespace TechnologicalProductionWebApi.Services.Interfaces;

public interface IContractService
{
    Task<IResult<AddContractResponse>> CreateContract(AddContract contract);
    Task<IResult<List<ContractResponse>>> GetContracts();
}