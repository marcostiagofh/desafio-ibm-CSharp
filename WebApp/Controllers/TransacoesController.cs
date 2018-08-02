using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.DAL;

namespace WebApp.Controllers
{
    public class TransacoesController : Controller
    {
        public BancoDbContext db = new BancoDbContext();

        // GET: Transacoes
        public ActionResult Index()
        {
            return View(db.Transacoes.ToList());
        }

        // GET: Transacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Transacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDContaRemetente,IDContaDestino,DataHora,Valor")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {               
                //Atualiza saldo das contas remetente e destino
                Cliente cliente = db.Clientes.Find(transacao.IDContaDestino);
                if (cliente != null)
                {
                    decimal saldo = cliente.Saldo;
                    cliente.Saldo = saldo + transacao.Valor;
                }
                db.Entry(cliente).State = EntityState.Modified;
                cliente = db.Clientes.Find(transacao.IDContaRemetente);
                if (cliente != null)
                {
                    decimal saldo = cliente.Saldo;
                    cliente.Saldo = saldo - transacao.Valor;
                }
                db.Entry(cliente).State = EntityState.Modified;

                db.Transacoes.Add(transacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transacao);            
        } 

        // GET: Transacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDContaRemetente,IDContaDestino,DataHora,Valor")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.Transacoes.Find(id);
            db.Transacoes.Remove(transacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }     
    }
}
