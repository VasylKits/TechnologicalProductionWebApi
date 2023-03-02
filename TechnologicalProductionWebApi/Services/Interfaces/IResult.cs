namespace TechnologicalProductionWebApi.Services.Interfaces;

public interface IResult<T>
{
    T Response { get; set; }
    public bool IsError { get; set; }
}