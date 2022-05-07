using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Dto;
using Model.Requests;
using Application.Interfaces;
using Rezervisi.Controllers;

namespace eTaxi.Controllers
{
    public class NotificationController : CRUDController<NotificationDto, NotificationSearchRequest, NotificationInsertRequest, NotificationInsertRequest>
    {
        public NotificationController(ICRUD<NotificationDto, NotificationSearchRequest, NotificationInsertRequest, NotificationInsertRequest> service) : base(service)
        {

        }
    }
}
