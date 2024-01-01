using AutoMapper;
using BankingBackend.Application.Features.TransactionCategoryFeatures.Models;
using BankingBackend.Domain.Entities;

namespace BankingBackend.Application.Features.TransactionCategoryFeatures
{
    public sealed class TransactionCategoryMapper : Profile
    {
        public TransactionCategoryMapper()
        {
            CreateMap<TransactionCategory, TransactionCategoryModel>();
            CreateMap<TransactionCategoryModel, TransactionCategory>();
        }
    }
}
