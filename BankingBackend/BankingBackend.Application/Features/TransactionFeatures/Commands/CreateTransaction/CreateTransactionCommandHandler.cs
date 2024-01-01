using AutoMapper;
using BankingBackend.Application.Common.Exceptions;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Application.Repositories;
using BankingBackend.Domain.Entities;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Commands.CreateTransaction
{
    internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransactionViewModel> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            if (request.Model == null)
                throw new BadRequestException("Transaction data is required.");

            var entity = _mapper.Map<Transaction>(request.Model);

            _transactionRepository.Create(entity);

            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<TransactionViewModel>(entity);
        }
    }
}
