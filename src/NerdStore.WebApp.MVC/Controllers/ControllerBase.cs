using System;
using Microsoft.AspNetCore.Mvc;


namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        // Para simular que existe um cliente logado por enquanto
        protected Guid ClienteId = Guid.Parse("7ABC988A-2A69-41D6-89A6-93A6B478C500");
    }
}
