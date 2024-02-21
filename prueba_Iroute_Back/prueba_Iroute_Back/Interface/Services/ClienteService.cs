using Microsoft.EntityFrameworkCore;
using prueba_Iroute_Back.Domain.Dto;
using prueba_Iroute_Back.Infrastructure.Models;

namespace prueba_Iroute_Back.Interface.Services
{

    public class ClienteService : ICliente
    {
        public PruebaIrouteDbContext _context;

        public ClienteService(PruebaIrouteDbContext context)
        {
            _context = context;
        }





        public async Task<List<ClienteEntity>> GetCustomers()
        {
            try
            {
                var customer = await _context.ClienteEntity.ToListAsync();
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return new List<ClienteEntity>();
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<List<ClienteEntity>> GetCustomersById(string identification)
        {
            try
            {
                var customer = await _context.ClienteEntity.Where(x => x.Identificacion == identification).ToListAsync();
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return new List<ClienteEntity>();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }



        public async Task<bool> createCustomer(ClienteInsertDto clienteDto)
        {
            try
            {
                var res = await _context.ClienteEntity.AddAsync(new ClienteEntity()
                {
                    Identificacion = clienteDto.Identification,
                    PrimerNombre = clienteDto.Name,
                    SegundoNombre = clienteDto.SecondName,
                    Apellidos = clienteDto.LastName,
                    Mail = clienteDto.Email,
                    Estado = true
                });

                var customer = await _context.ClienteEntity.Where(x => x.Identificacion == clienteDto.Identification).FirstOrDefaultAsync();

                if (customer == null)
                {
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public async Task<bool> DeleteCustomer(EditarEstadoClienteDto editarEstadoClienteDto)
        {
            try
            {

                var response = await _context.ClienteEntity.Where(x => x.Id == editarEstadoClienteDto.Id).FirstOrDefaultAsync();


                if (response != null)
                {
                    if (response.Estado == true)
                    {
                        response.Estado = false;

                        _context.Update(response);
                        await _context.SaveChangesAsync();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
