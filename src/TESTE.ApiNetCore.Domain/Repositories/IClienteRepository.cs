using TESTE.ApiNetCore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace TESTE.ApiNetCore.Domain.Repositories
{
    public interface IClienteRepository
    {
        void IncluirCliente(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ListarTodos();
    }
}
