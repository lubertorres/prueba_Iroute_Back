using Microsoft.EntityFrameworkCore;
using prueba_Iroute_Back.Domain.Dto;
using prueba_Iroute_Back.Infrastructure.Models;

namespace prueba_Iroute_Back.Interface
{
    public interface ICliente
    {
        public Task<List<ClienteEntity>> GetCustomers();
        public Task<List<ClienteEntity>> GetCustomersById(string identification);
        public Task<bool> createCustomer(ClienteInsertDto clienteDto);
        public Task<bool> DeleteCustomer(EditarEstadoClienteDto editarEstadoClienteDto);



    }

}
