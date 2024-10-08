﻿using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IVendaRepository : IGenericRepository<Venda>
    {

        Task<Venda> GetVendaComItensByIdAsync(int id);
        Task<IEnumerable<Venda>> GetVendasComItensAsync();

    }
}
