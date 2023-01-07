using Microsoft.AspNetCore.Mvc;

namespace DesafioBackend
{
    public class RouteTemplate : RouteAttribute
    {
        public RouteTemplate(string template = "") : base($"api/v1/{template}") { }
    }
}
