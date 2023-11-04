using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdocaoPets.Data;
using Microsoft.AspNetCore.Mvc;
using AdocaoPets.Models;
using AdocaoPets.Models.ViewModels;
using AdocaoPets.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using X.PagedList;
using DateTime = System.DateTime;

namespace AdocaoPets.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdocaoPetsContext _context;
        private readonly AnimalService _animalService;
        private readonly SolicitanteService _solicitanteService;

        public HomeController( AnimalService animalService, AdocaoPetsContext context, SolicitanteService solicitanteService)
        {
            _animalService = animalService;
            _context = context;
            _solicitanteService = solicitanteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> QueroAdotar(int? pagina, int codigo)
        {
            // Buscando 
            var buscarTodos = await _animalService.BuscarTodoAsync();
            var especieAnimais = await _animalService.BuscarEspecieAsync();
            var racaAnimais = await _animalService.BuscarRacaAsync();
            var porteAnimais = await _animalService.BuscarPorteAsync();

            ViewBag.Animais = buscarTodos;
            ViewBag.Especie = especieAnimais;
            ViewBag.Raca = racaAnimais;
            ViewBag.Porte = porteAnimais;

            int numeroPagina = pagina ?? 1;
            int tamanhoPagina = 4;

            var animaisAtivos = (await _animalService.BuscarAtivosAsync()).ToPagedList(numeroPagina, tamanhoPagina);
          
            return View(animaisAtivos);
        }
        
        public async Task<IActionResult> Integra(int codigo)
        {
            var animal = await _animalService.ObterDetalhesPorCodigoAsync(codigo);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }
       
        public async Task<IActionResult> Formulario(string nomeAnimal)
        {
            var solicitantes = await _solicitanteService.BuscarTudoAsync();
            var viewModel = new FormViewModel { Solicitante = solicitantes };
            ViewBag.NomeAnimal = nomeAnimal;
            return View();
        }

        private string GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return string.Join("<br/>", errors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Formulario(Solicitante solicitante)
        {
            if (!ModelState.IsValid)
            {
                var solicitacao = await _solicitanteService.BuscarTudoAsync();
                var viewModel = new FormViewModel { Solicitante = solicitacao };
                return Json(new { success = false, validationSummary = GetModelStateErrors(ModelState) });
            }

            var novoSolicitante = new Solicitante()
            {
                Nome = solicitante.Nome,
                Email = solicitante.Email,
                Cpf = solicitante.Cpf,
                Celular = solicitante.Celular,
                DataNascimento = solicitante.DataNascimento,
                DataInsercao = DateTime.Now
            };
    
            await _solicitanteService.CriarSolicitante(novoSolicitante);
            ViewBag.MensagemSucesso = "Solicitação realizada com sucesso!";
           
            return Json(new { success = true, redirectUrl = Url.Action(nameof(QueroAdotar)) });

        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
