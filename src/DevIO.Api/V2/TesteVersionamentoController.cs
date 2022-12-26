using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteVersionamentoController : MainController
    {
        public TesteVersionamentoController(INotificador notificador, IUser appUser)
            : base(notificador, appUser)
        {
        }

        [HttpGet]
        public string WhatVersion()
        {
            return "V2";
        }
    }
}
