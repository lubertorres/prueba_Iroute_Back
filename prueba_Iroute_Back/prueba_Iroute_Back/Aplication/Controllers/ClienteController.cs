using Microsoft.AspNetCore.Mvc;
using prueba_Iroute_Back.Aplication.Exceptions;
using prueba_Iroute_Back.Domain.Dto;
using prueba_Iroute_Back.Interface;

namespace prueba_Iroute_Back.Aplication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class ClienteController : ControllerBase
    {
        public ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }



        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var res = await _cliente.GetCustomers();
                if (res.Count >= 1)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest("No hay registros");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        [HttpGet("GetCustomersById")]
        public async Task<IActionResult> GetCustomersById(string identification)
        {
            try
            {
                var res = await _cliente.GetCustomersById(identification);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest("No hay registros");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPost("createCustomer")]
        public async Task<IActionResult> createCustomer(ClienteInsertDto clienteDto)
        {
            try
            {
                var res = await _cliente.createCustomer(clienteDto);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest(new RespuestaIncorrecta
                    { ProcesoExitoso = false, Mensaje = "Ya existe un cliente con dicha Identificación" }
                    );
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        [HttpPut("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(EditarEstadoClienteDto editarEstadoClienteDto)
        {
            try
            {
                var response = await _cliente.DeleteCustomer(editarEstadoClienteDto);

                if (response == true)
                {
                    return Ok(new RespuestaExitosa { ProcesoExitoso = true, id = editarEstadoClienteDto.Id });
                }
                else
                {
                    return BadRequest(new RespuestaIncorrecta
                    { ProcesoExitoso = false, Mensaje = "El cliente ya se encuentra inactivo" }
                    );
                }
            }
            catch (ClienteNoExisteException)
            {
                return NotFound(new RespuestaIncorrecta
                { ProcesoExitoso = false, Mensaje = "El ID del cliente no es válido" }
                );

            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
