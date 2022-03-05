using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
    public class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand, TermDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDxos _dxos;
        private readonly IMemoryCache _memoryCache;
        public UpdateTermCommandHandler(IUnitOfWork unitOfWork, ITermDxos dxos, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
            _memoryCache = memoryCache;
        }
        public async Task<TermDto> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
        {
            var term = await _unitOfWork.TermRepository.GetAsync(b => b.Id == request.TermDto.Id && b.IsDelete == false);
            if (term == null) throw new ApplicationException("not Found");
            {
                term.Update(request.TermDto.Word, request.TermDto.Description, request.TermDto.Synonyms, request.TermDto.Examples);
                _unitOfWork.TermRepository.Update(term);
                _unitOfWork.Commit();
                if (!_memoryCache.TryGetValue("term", out TermDto termDto))
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                    _memoryCache.Set("term", termDto, cacheEntryOptions);
                }
                return _dxos.MapTermDto(term);
            }
        }
    }
}
