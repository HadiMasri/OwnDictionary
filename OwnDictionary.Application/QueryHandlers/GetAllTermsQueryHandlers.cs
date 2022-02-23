using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
    public class GetAllTermsQueryHandlers : IRequestHandler<GetAllTermsQuery, IEnumerable<TermDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDxos _dxos;
        private readonly IMemoryCache _memoryCache;

        public GetAllTermsQueryHandlers(IUnitOfWork unitOfWork, ITermDxos dxos, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<TermDto>> Handle(GetAllTermsQuery request, CancellationToken cancellationToken)
        {
            var cacheEntry = _memoryCache.GetOrCreateAsync("term", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                var data = await _unitOfWork.TermRepository.GetListAsync(b => b.IsDelete == false);
                var dxos = _dxos.MapTermDtos(data);
                return dxos;
            });
            return await cacheEntry;
        }

    
    }
}
