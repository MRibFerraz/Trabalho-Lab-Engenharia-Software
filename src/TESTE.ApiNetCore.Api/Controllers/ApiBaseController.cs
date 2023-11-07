﻿using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using TESTE.ApiNetCore.Application.Models;
using System.Collections.Generic;

namespace TESTE.ApiNetCore.Api.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }
    }
}