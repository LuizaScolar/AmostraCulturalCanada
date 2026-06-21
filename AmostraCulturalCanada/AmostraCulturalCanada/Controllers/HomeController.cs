using AmostraCulturalCanada.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AmostraCulturalCanada.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Historia()
        {
            return View();
        }

        public IActionResult Cultura()
        {
            return View();
        }

        public IActionResult Folclore()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            // Tenta pegar o ID do usuário na sessão
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            // Se não tiver ID, significa que não está logado
            if (usuarioId == null)
            {
                ViewBag.Erro = "Você precisa fazer login para acessar o Quiz!";
                return View("Login"); // Manda de volta pra tela de login
            }

            // Se estiver logado, pega o nome dele para darmos boas-vindas na tela!
            ViewBag.NomeUsuario = HttpContext.Session.GetString("UsuarioNome");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Tela de Login / Cadastro
        public IActionResult Login()
        {
            return View();
        }

        // POST: Processar o Cadastro de um novo usuário
        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o e-mail já existe
                var existe = _context.Usuarios.Any(u => u.Email == usuario.Email);
                if (existe)
                {
                    ModelState.AddModelError("Email", "Este e-mail já está cadastrado.");
                    return View("Login", usuario);
                }

                // Salva no Banco de Dados
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                TempData["Sucesso"] = "Cadastro realizado com sucesso! Faça seu login.";
                return RedirectToAction("Login");
            }
            return View("Login", usuario);
        }

        // POST: Processar o Login
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            // Procura o usuário com o email e senha digitados
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                // Guarda o ID e o Nome do usuário na sessão para dizer que ele está logado
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

                return RedirectToAction("Quiz"); // Manda direto para o Quiz!
            }

            ViewBag.Erro = "E-mail ou senha incorretos.";
            return View("Login");
        }

        // Ação para deslogar (Logout)
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpa a sessão
            return RedirectToAction("Index");
        }
    }
}
