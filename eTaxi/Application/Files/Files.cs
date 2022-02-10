using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto;
using Model.Others;
using Model.Requests;
using Persistence;

namespace Application.Files
{
    public partial class Files : CRUD<FileDto, FileSearchRequest, File, FileInsert, FileUpsert>
    {
        private readonly ApplicationSettings _appSettings;

        public Files(eTaxiDbContext context, IMapper mapper, ApplicationSettings appSettings, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
            _appSettings = appSettings;
        }
    }
}
