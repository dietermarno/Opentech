using Opentech.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
namespace Opentech.Controllers
{
    public class EmpresasController : Controller
    {
        OpentechDbContext db;
        public EmpresasController()
        {
            db = new OpentechDbContext();
        }
        // GET: Empresas
        public ActionResult Index()
        {
            var produtos = db.Empresas.ToList();
            return View(produtos);
        }

        public ActionResult Create()
        {
            var model = new Empresa();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa model)
        {
            var empresa = new Empresa();
            empresa.Nome = model.Nome;
            empresa.Site = model.Site;
            empresa.QuantidadeFuncionarios = model.QuantidadeFuncionarios;
            db.Empresas.Add(empresa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Site,QuantidadeFuncionarios")] Empresa model)
        {
            if (ModelState.IsValid)
            {
                var empresa = db.Empresas.Find(model.Id);
                if (empresa == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                empresa.Nome = model.Nome;
                empresa.Site = model.Site;
                empresa.QuantidadeFuncionarios = model.QuantidadeFuncionarios;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }
        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa produto = db.Empresas.Find(id);
            db.Empresas.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }
    }
}