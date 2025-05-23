using System.Threading.Tasks;
using SmartStock.Application.DTOs;

namespace SmartStock.Application.UseCases // <--- Adicione esta linha
{
    public interface IGetAllStockItemsUseCase
    {
        Task<GetAllStockItemsResponse> ExecuteAsync(GetAllStockItemsRequest request);
    }
}