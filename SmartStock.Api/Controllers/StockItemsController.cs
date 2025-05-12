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
        private readonly IUpdateStockItemUseCase _updateStockItemUseCase;
        private readonly IDeleteStockItemByIdUseCase _deleteStockItemUseCase;

        public StockItemsController(IRegisterStockItemUseCase registerStockItemUseCase, IGetStockItemByIdUseCase getStockItemByIdUseCase, IGetAllStockItemsUseCase getAllStockItemsUseCase, IUpdateStockItemUseCase updateStockItemUseCase, IDeleteStockItemByIdUseCase deleteStockItemUseCase)
        {
            _registerStockItemUseCase = registerStockItemUseCase;
            _getStockItemByIdUseCase = getStockItemByIdUseCase;
            _getAllStockItemsUseCase = getAllStockItemsUseCase;
            _updateStockItemUseCase = updateStockItemUseCase;
            _deleteStockItemUseCase = deleteStockItemUseCase;
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

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] UpdateStockItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _updateStockItemUseCase.ExecuteAsync(id, request);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _deleteStockItemUseCase.ExecuteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}