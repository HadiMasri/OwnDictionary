using MediatR;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Contracts.Queries;
using OwnDictionary.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.QueryHandlers
{
    public class GetTermQueryHandler : IRequestHandler<GetTermQuery, TermDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDxos _dxos;

        public GetTermQueryHandler(IUnitOfWork unitOfWork, ITermDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<TermDto> Handle(GetTermQuery request, CancellationToken cancellationToken)
        {
            var term = await _unitOfWork.TermRepository.GetAsync(s => s.Id == request.Id);
            return _dxos.MapTermDto(term);
        }
    }
}
