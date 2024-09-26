using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Venda, VendaDto>().ReverseMap();
        CreateMap<ItemVenda, ItemVendaDto>().ReverseMap();

        

    }
}
