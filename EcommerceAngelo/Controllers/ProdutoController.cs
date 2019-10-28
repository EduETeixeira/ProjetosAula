using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAngelo.DAL;
using EcommerceAngelo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAngelo.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoController
            (ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_produtoDAO.Listar());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto p)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(p))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Este Produto já existe!!!");
                
            }return View(p);
            
        }

        public IActionResult Remover(int id)
        {
            _produtoDAO.Remover(id);
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int id)
        {
            return View
                (_produtoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Produto p)
        {
            _produtoDAO.Alterar(p);
            return RedirectToAction("Index");
        }
    }
}