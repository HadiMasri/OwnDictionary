using MediatR;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Commands.LanguageCommands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Application.CommandHandlers.LanguageCommandHandler
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, LanguageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageDxos _dxos;
        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, ILanguageDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<LanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var language = await _unitOfWork.LanguageRepository.GetAsync(b => b.Id == request.LanguageDto.Id && b.IsDelete == false);
            if (language == null) throw new ApplicationException("not Found");
            {
                language.Update(request.LanguageDto.Name);
                _unitOfWork.LanguageRepository.Update(language);
                _unitOfWork.Commit();
                return _dxos.MapTermDto(language);
            }
        }
    }
}
