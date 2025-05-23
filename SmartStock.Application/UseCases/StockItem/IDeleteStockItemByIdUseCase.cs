namespace SmartStock.Application.UseCases
{
    public interface IDeleteStockItemByIdUseCase
    {
        Task<bool> ExecuteAsync(Guid id);
    }
}