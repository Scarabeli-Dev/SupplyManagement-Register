using Register.Api.Extensions;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Register.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPageList([FromQuery] PageParams pageParams)
        {
            try
            {
                var warehouses = await _warehouseService.GetAllWarehousesPageListAsync(pageParams);
                if (warehouses == null) return NoContent();

                Response.AddPagination(warehouses.CurrentPage, warehouses.PageSize, warehouses.TotalCount, warehouses.TotalPages);

                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar warehouses. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
                if (warehouse == null) return NoContent();

                return Ok(warehouse);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar depósito. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(WarehouseDto model)
        {
            try
            {
                var warehouse = await _warehouseService.AddWarehouse(model);
                if (!warehouse) return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Depósito. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, WarehouseDto model)
        {
            try
            {
                var warehouse = await _warehouseService.UpdateWarehouse(id, model);
                if (!warehouse) return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Farms. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
                if (warehouse == null) return NoContent();


                if (await _warehouseService.DeleteWarehouse(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não especifico ao tentar deletar Farm.");
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Farms. Erro: {ex.Message}");
            }
        }
    }
}
