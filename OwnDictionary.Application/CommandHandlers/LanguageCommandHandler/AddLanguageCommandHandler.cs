using MediatR;
using OwnDictionary.Application.Dxos;
using OwnDictionary.Contracts.Commands.LanguageDictionaryCommands;
using OwnDictionary.Contracts.Dtos;
using OwnDictionary.Models.Entities;
using OwnDictionary.Repositories.UnitOfWork;


namespace OwnDictionary.Application.CommandHandlers.LanguageCommandHandler
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommand, LanguageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageDxos _dxos;
        public AddLanguageCommandHandler(IUnitOfWork unitOfWork, ILanguageDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }

        public async Task<LanguageDto> Handle(AddLanguageCommand request, CancellationToken cancellationToken)
        {
            Language l = new Language();
            l.Name = request.Name;
            _unitOfWork.LanguageRepository.Add(l);
            _unitOfWork.Commit();
            return _dxos.MapTermDto(l);
        }

    }
}
