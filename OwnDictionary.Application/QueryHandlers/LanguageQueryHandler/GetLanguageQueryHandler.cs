using MediatR;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Contracts.Queries.LanguageQueries;
using OwnDictionary.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.QueryHandlers.LanguageQueryHandler
{
    public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, LanguageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageDxos _dxos;

        public GetLanguageQueryHandler(IUnitOfWork unitOfWork, ILanguageDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }

        public async Task<LanguageDto> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            var term = await _unitOfWork.LanguageRepository.GetAsync(s => s.Id == request.Id && s.IsDelete == false);
            if (term is null) throw new Exception("Not Found");
            return _dxos.MapTermDto(term);
        }
    }
}
