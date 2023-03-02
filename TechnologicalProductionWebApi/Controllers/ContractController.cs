using Microsoft.AspNetCore.Mvc;
using TechnologicalProductionWebApi.Authentication;
using TechnologicalProductionWebApi.DTOs;
using TechnologicalProductionWebApi.Services.Interfaces;

namespace TechnologicalProductionWebApi.Controllers;

[ApiController]
[ApiKey]
[Route("contracts")]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;

    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<IActionResult> GetContracts()
    {
        var result = await _contractService.GetContracts();

        return (result.IsError)
            ? BadRequest(result)
            : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] AddContract request)
    {
        var result = await _contractService.CreateContract(request);

        return (result.IsError)
         ? BadRequest(result)
         : Ok(result);
    }
}