using MvcCadastroDeProduto.AdoDAO;
using MvcCadastroDeProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCadastroDeProduto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new ProdutoAdoDAO().RetornarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(new ProdutoAdoDAO().RetornarPorId(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Produto obj = new Produto();
                UpdateModel(obj);

                new ProdutoAdoDAO().Inserir(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new ProdutoAdoDAO().RetornarPorId(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Produto obj = new Produto();
                UpdateModel(obj);

                new ProdutoAdoDAO().Alterar(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new ProdutoAdoDAO().RetornarPorId(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                new ProdutoAdoDAO().Excluir(new Produto { Id = id });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
