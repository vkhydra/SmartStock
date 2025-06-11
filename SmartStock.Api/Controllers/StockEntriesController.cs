using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStock.Application.DTOs;
using SmartStock.Application.UseCases;

namespace SmartStock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockEntriesController : ControllerBase
    {
        private readonly IRegisterStockEntryUseCase _registerStockEntryUseCase;
        private readonly IGetStockEntryByIdUseCase _getStockEntryByIdUseCase;
        private readonly IGetAllStockEntryUseCase _getAllStockEntriesUseCase;
        private readonly IUpdateStockEntryUseCase _updateStockEntryUseCase;
        private readonly IDeleteStockEntryUseCase _deleteStockEntryUseCase;

        public StockEntriesController(IRegisterStockEntryUseCase registerStockEntryUseCase, IGetStockEntryByIdUseCase getStockEntryByIdUseCase, IGetAllStockEntryUseCase getAllStockEntriesUseCase, 
            IUpdateStockEntryUseCase updateStockEntryUseCase, IDeleteStockEntryUseCase deleteStockEntryUseCase)
        {
            _getStockEntryByIdUseCase = getStockEntryByIdUseCase;
            _getAllStockEntriesUseCase = getAllStockEntriesUseCase;
            _registerStockEntryUseCase = registerStockEntryUseCase;
            _updateStockEntryUseCase = updateStockEntryUseCase;
            _deleteStockEntryUseCase = deleteStockEntryUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterStockEntryResponse>> Post(RegisterStockEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _registerStockEntryUseCase.ExecuteAsync(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Error.Message);
            }
            return CreatedAtAction(nameof(Get), new { id = response.Value.Id }, response.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStockEntryResponse>> Get(Guid id)
        {
            var stockEntry = await _getStockEntryByIdUseCase.ExecuteAsync(id);
            if (stockEntry == null)
            {
                return NotFound();
            }
            return Ok(stockEntry);
        }
        [HttpGet]
        public async Task<ActionResult<GetAllStockEntryResponse>> Get([FromQuery] GetAllStockEntryRequest request)
        {
            var response = await _getAllStockEntriesUseCase.ExecuteAsync(request);
            return Ok(response);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] UpdateStockEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateStockEntryUseCase.ExecuteAsync(id, request);
            if (!result.IsSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _deleteStockEntryUseCase.ExecuteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
