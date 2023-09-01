using Microsoft.AspNetCore.Mvc;
using Register.Api.Extensions;
using Register.Application.Dtos;
using Register.Application.Services.Interfaces;
using Register.Infrastructure.Models;

namespace Register.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressingsController : Controller
    {
        private readonly IAddressingService _addressingService;

        public AddressingsController(IAddressingService addressingService)
        {
            _addressingService = addressingService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPageList([FromQuery] PageParams pageParams)
        {
            try
            {
                var addressings = await _addressingService.GetAllAddressingsPageListAsync(pageParams);
                if (addressings == null) return NoContent();

                Response.AddPagination(addressings.CurrentPage, addressings.PageSize, addressings.TotalCount, addressings.TotalPages);

                return Ok(addressings);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar addressings. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var addressing = await _addressingService.GetAddressingByIdAsync(id);
                if (addressing == null) return NoContent();

                return Ok(addressing);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar depósito. Erro: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(AddressingDto model)
        {
            try
            {
                var addressing = await _addressingService.AddAddressing(model);
                if (!addressing) return NoContent();

                return Ok();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Depósito. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AddressingDto model)
        {
            try
            {
                var addressing = await _addressingService.UpdateAddressing(id, model);
                if (!addressing) return NoContent();

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
                var addressing = await _addressingService.GetAddressingByIdAsync(id);
                if (addressing == null) return NoContent();


                if (await _addressingService.DeleteAddressing(id))
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
