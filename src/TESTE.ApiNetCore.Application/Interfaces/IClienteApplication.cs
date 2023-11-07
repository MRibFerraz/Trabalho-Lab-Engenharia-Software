using TESTE.ApiNetCore.Application.Models;
using TESTE.ApiNetCore.Domain.Entities;

namespace TESTE.ApiNetCore.Application.Interfaces
{
    public interface IClienteApplication
    {
        Result<Cliente> Salvar(ClienteModel clienteModel);
    }
}