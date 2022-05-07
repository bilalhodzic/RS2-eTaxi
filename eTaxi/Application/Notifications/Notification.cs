using Application.CRUD;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Model.Dto;
using Model.Requests;
using Persistence;

namespace Application.Notifications
{
    public partial class Notifications : CRUD<NotificationDto, NotificationSearchRequest, Notification, NotificationInsertRequest, NotificationInsertRequest>
    {
        public Notifications(eTaxiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
