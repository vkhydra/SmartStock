using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartStock.Application.DTOs;
using SmartStock.Application.UseCases;

namespace SmartStock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockItemsController : ControllerBase
    {
        private readonly IRegisterStockItemUseCase _registerStockItemUseCase;
        private readonly IGetStockItemByIdUseCase _getStockItemByIdUseCase;
        private readonly IGetAllStockItemsUseCase _getAllStockItemsUseCase;

        public StockItemsController(IRegisterStockItemUseCase registerStockItemUseCase, IGetStockItemByIdUseCase getStockItemByIdUseCase, IGetAllStockItemsUseCase getAllStockItemsUseCase)
        {
            _registerStockItemUseCase = registerStockItemUseCase;
            _getStockItemByIdUseCase = getStockItemByIdUseCase;
            _getAllStockItemsUseCase = getAllStockItemsUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterStockItemResponse>> Post(RegisterStockItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _registerStockItemUseCase.ExecuteAsync(request);

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var stockItem = await _getStockItemByIdUseCase.ExecuteAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }
            return Ok(stockItem);
        }
        [HttpGet]
        public async Task<ActionResult<GetAllStockItemsResponse>> Get([FromQuery] GetAllStockItemsRequest request)
        {
            var response = await _getAllStockItemsUseCase.ExecuteAsync(request);
            return Ok(response);
        }
    }
}