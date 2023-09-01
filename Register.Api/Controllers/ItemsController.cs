using Microsoft.AspNetCore.Mvc;
using Register.Api.Extensions;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Infrastructure.Models;

namespace Register.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPageList([FromQuery] PageParams pageParams)
        {
            try
            {
                var items = await _itemService.GetAllItemsPageListAsync(pageParams);
                if (items == null) return NoContent();

                Response.AddPagination(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar items. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null) return NoContent();

                return Ok(item);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar depósito. Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ItemDto model)
        {
            try
            {
                var item = await _itemService.AddItem(model);

                if (!item) return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Depósito. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ItemDto model)
        {
            try
            {
                var item = await _itemService.UpdateItem(id, model);
                if (!item) return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Farms. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null) return NoContent();


                if (await _itemService.DeleteItem(id))
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
