using Database.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Business.models;

namespace WEB.Controllers
{
    public class ProdutosController : Controller
    {
        private static Produto produtoService = new Produto();

        public IActionResult Index()
        {
            ViewBag.produtos = produtoService.BuscaTodos();
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Cadastrar([FromForm] Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                ViewBag.erro = "O nome não pode ser vazio";
                return View();
            }

            produto.Gravar(produto);

            return Redirect("/produtos");
        }

        [Route("/produtos/{id}/editar")]
        public IActionResult Editar([FromRoute] int id)
        {
            ViewBag.produto = produtoService.BuscaPorId(id);
            return View();
        }

        [Route("/produtos/{id}/atualizar")]
        public IActionResult Atualizar([FromRoute] int id, [FromForm] Produto produto)
        {
            produto.Id = id;
            produtoService.Gravar(produto);
            return Redirect("/produtos");
        }

        [Route("/produtos/{id}/deletar")]
        public IActionResult Apagar([FromRoute] int id)
        {
            produtoService.ApagaPorId(id);
            return Redirect("/produtos");
        }

    }
}
