﻿using OwnDictionary.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnDictionary.Contracts.Queries.LanguageQueries
{
    public class GetLanguageQuery : QueryBase<LanguageDto>
    {
        public Guid Id { get; set; }
    }
}
