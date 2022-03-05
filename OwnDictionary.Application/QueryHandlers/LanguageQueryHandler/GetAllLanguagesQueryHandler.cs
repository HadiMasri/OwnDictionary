using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
    public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<LanguageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageDxos _dxos;
        private readonly IMemoryCache _memoryCache;

        public GetAllLanguagesQueryHandler(IUnitOfWork unitOfWork, ILanguageDxos dxos, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<LanguageDto>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
        {

            var cacheEntry = _memoryCache.GetOrCreateAsync("language", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                var data = await _unitOfWork.LanguageRepository.GetListAsync(b => b.IsDelete == false);
                var dxos = _dxos.MapTermDtos(data);
                return dxos;
            });
            return await cacheEntry;
        }
    }
}
