using AutoMapper;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Domain.Entities;

namespace BankingBackend.Application.Features.TransactionFeatures
{
    public sealed class TransactionMapper : Profile
    {
        public TransactionMapper()
        {
            CreateMap<Transaction, TransactionViewModel>();

            CreateMap<TransactionBaseModel, Transaction>()
                .ForMember(m => m.OccuredAt, o => o.MapFrom(s => s.OccuredAt.ToUniversalTime()))
                .ForMember(m => m.CategoryId, o => o.MapFrom(s => s.Category.Id))
                .ForMember(m => m.Category, o => o.Ignore());
        }
    }
}
