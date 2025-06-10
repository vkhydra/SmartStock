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

        public StockEntriesController(IRegisterStockEntryUseCase registerStockEntryUseCase)
        {
            _registerStockEntryUseCase = registerStockEntryUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterStockEntryResponse>> Post(RegisterStockEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _registerStockEntryUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(Post), new { id = response.Id }, response);
        }
    }
}
