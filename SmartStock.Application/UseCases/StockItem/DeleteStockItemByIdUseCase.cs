using SmartStock.Application.Interfaces;

namespace SmartStock.Application.UseCases
{
    public class DeleteStockItemByIdUseCase : IDeleteStockItemByIdUseCase
    {
        private readonly IStockItemRepository _stockItemRepository;
        public DeleteStockItemByIdUseCase(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            var stockItem = await _stockItemRepository.GetByIdAsync(id);
            if (stockItem == null)
            {
                return false;
            }

            await _stockItemRepository.DeleteAsync(id);
            return true;
        }
    }
}