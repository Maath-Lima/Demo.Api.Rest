using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteVersionamentoController : MainController
    {
        private readonly ILogger _logger;

        public TesteVersionamentoController(
            INotificador notificador,
            IUser appUser,
            ILogger<TesteVersionamentoController> logger)
            : base(notificador, appUser)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public string WhatVersion()
        //{
        //    return "V2";
        //}

        [HttpGet]
        public void Logs()
        {
            //throw new Exception("Error");

            _logger.LogTrace("Log de Trace");
            _logger.LogDebug("Log de Debug");
            _logger.LogInformation("Log de Informação");
            _logger.LogWarning("Log de Aviso");
            _logger.LogError("Log de Erro");
            _logger.LogCritical("Log de Problema Critico");
        }
    }
}
