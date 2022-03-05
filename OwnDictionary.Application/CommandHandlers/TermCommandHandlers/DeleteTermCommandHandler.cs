using MediatR;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Commands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.CommandHandlers
{
    public class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand, TermDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDxos _dxos;

        public DeleteTermCommandHandler(IUnitOfWork unitOfWork, ITermDxos dxos)
        {
            IUnitOfWork unitOfWork1 = unitOfWork;
            _unitOfWork = unitOfWork1;
            _dxos = dxos;
        }
        public async Task<TermDto> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
        {
            var term = await _unitOfWork.TermRepository.GetAsync(b => b.Id == request.Id && b.IsDelete == false);
            if (term == null) throw new Exception("Not Found");
            term.Delete();
            _unitOfWork.TermRepository.Update(term);
            _unitOfWork.Commit();
            return _dxos.MapTermDto(term);
        }
    }
}
