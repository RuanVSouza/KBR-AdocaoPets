using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using AdocaoPets.Data;
using AdocaoPets.Models;
using AdocaoPets.Models.ViewModels;
using AdocaoPets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace AdocaoPets.Controllers
{
    public class AdministrativoController : Controller
    {
        private readonly AdocaoPetsContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly AdminService _adminService;
        private readonly AnimalService _animalService;
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;


        public AdministrativoController(AdocaoPetsContext context, ILogger<HomeController> logger, AdminService adminService,AnimalService animalService)
        {
            _logger = logger;
            _context = context;
            _adminService = adminService;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public Task<IActionResult> Login(AdminViewModel adminViewModel)
        {
            return Task.FromResult<IActionResult>(RedirectToAction("Painel"));
        }

        public async Task<IActionResult> Painel()
        {  
            var admins = await _adminService.BuscandoAdmin();
            return View(admins);
        }

        public async Task<IActionResult> RecuperarSenha()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                var admins = await _adminService.BuscarTodosAsync();
                var viewModel = new AdminViewModel { Admin = admin }; 
        
                // Armazena a mensagem de erro na TempData
                TempData["ErrorMessage"] = "Erro ao cadastrar o administrador. Verifique os dados e tente novamente.";
        
                return RedirectToAction(nameof(Painel));
            }
        
            var novoAdmin = new Admin()
            {
                Nome = admin.Nome,
                Email = admin.Email,
                Senha = admin.Senha,
                ConfirmaSenha = admin.ConfirmaSenha
            };
        
            await _adminService.CriarAdmin(novoAdmin);  // Corrija para novoAdmin
            ViewBag.MensagemSucesso = "Solicitação realizada com sucesso!";
        
            return RedirectToAction(nameof(Painel));
        }

        
        // public IActionResult Editar()
        // {
        //     
        //     var nomeAdmin =  _adminService.BuscarNomeAdmin();
        //     var emailAdmin = _adminService.BuscarEmailAdmin();
        //     var senhaAdmin = _adminService.BuscarSenhaAdmin();
        //     ViewBag.NomeAdmin = nomeAdmin;
        //     ViewBag.EmailAdmin = emailAdmin;
        //
        //     return View();
        // }
        
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Admin ad = await _adminService.FindByIdAsync(id);
            Admin email = await _adminService.BuscarEmailAdmin();
            Admin adminResult = await _adminService.BuscarNomeAdmin();

            var adminViewModel = new AdminViewModel
            {
                Nome = adminResult.Nome,
                Email = email.Email
            };

            return View(adminViewModel); // Passa o modelo para a view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(AdminViewModel adminViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(adminViewModel); // Retorna a view com o modelo se houver erros de validação
            }

            // Converta AdminViewModel para Admin antes de atualizar
            var admin = new Admin
            {
                Nome = adminViewModel.Nome,
                Email = adminViewModel.Email,
                // Outros campos, se necessário
            };

            await _adminService.Atualizar(admin);
            return RedirectToAction("Painel");
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Editar(int id, [Bind("Id, Nome, Email, Senha, ConfirmaSenha")] Admin admin)
        // {
        //     if (id != admin.Id)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             await _adminService.EditarAdmin(admin);
        //         }
        //         catch (Exception ex)
        //         {
        //             throw new Exception("Não foi possivel deletar o Usuario");
        //         }
        //
        //         return Redirect(nameof(Painel));
        //     }
        //
        //     return RedirectToAction(nameof(Painel));
        // }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
       
    }
}