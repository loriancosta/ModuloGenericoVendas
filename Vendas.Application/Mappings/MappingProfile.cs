using AutoMapper;
using Vendas.Application.Dtos;
using Vendas.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Venda <-> VendaDto
        CreateMap<Venda, VendaDto>()
            .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda))
            .ReverseMap();

        // ItemVenda <-> ItemVendaDto
        CreateMap<ItemVenda, ItemVendaDto>().ReverseMap();

        // Produto <-> ProdutoDto
        CreateMap<Produto, ProdutoDto>().ReverseMap();




    }
}
