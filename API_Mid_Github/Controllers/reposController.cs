using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using API_Mid_Github.DTO;
using System.Text.Json;
using Newtonsoft.Json;

namespace API_Mid_Github.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class reposController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> ListarRepositorios()
        {
            try
            {
                string urlApi = "https://api.github.com/orgs/takenet/repos";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "API");

                var resultado = await client.GetAsync(urlApi);

                var conteudo = await resultado.Content.ReadAsStringAsync();

                var repos = JsonConvert.DeserializeObject<List<Repositorio>>(conteudo.ToString());

                List<Repositorio> repositorios = new List<Repositorio>();

                int totalDeRepositorios = repos.Count;

                for (int i = 0; i < 6; i++)
                {
                    if (repos[i].language == "C#")
                    {
                        repositorios.Add(repos[i]);
                    }
                }

                return Ok(repositorios);
            }
            catch
            {
                return Forbid("Algo inesperado aconteceu");
            }

        }




    }
}
