using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemasASP.Models;
using SistemasASP.Aplicacao;
using System.Web.Mvc;
using PagedList;

namespace SistemasASP.Controllers
{
    public class HomeController : Controller
    {
        private PessoaAplicacao pessoaAplicacao;
        public HomeController()
        {
            pessoaAplicacao = new PessoaAplicacao();
        }
        public ActionResult Index(int? pagina)
        {

            var lis = new PessoaAplicacao();
            var listaAlunos = lis.ListarTodos();
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);

            return View(listaAlunos.ToPagedList(paginaNumero, paginaTamanho));



            /*
            var lista = pessoaAplicacao.ListarTodos();
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);
            return View(lista.ToPagedList(paginaNumero, paginaTamanho));
             */
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Editar(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Detalhe(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        public ActionResult Excluir(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            pessoaAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}