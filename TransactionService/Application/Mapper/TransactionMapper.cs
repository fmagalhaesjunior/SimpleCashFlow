using Application.Commands;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Shared.Extensions;

namespace Application.Mapper
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper() 
        {
            CreateMap<Transaction, GetTransactionResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToEnumName()));

            CreateMap<CreateTransactionCommand, Transaction>()
                .ConstructUsing(req => new Transaction(req.TransactionDate, req.Amount, req.Type, req.Description));
        }
    }
}
