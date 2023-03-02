using TechnologicalProductionWebApi.Services.Interfaces;

namespace TechnologicalProductionWebApi.DTOs;

public class Result<T> : IResult<T>
{
    public T Response { get; set; }
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }
}