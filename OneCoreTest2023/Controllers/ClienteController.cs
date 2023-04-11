using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneCoreTest2023.Models;
using OneCoreTest2023.Models.ViewModels;

namespace OneCoreTest2023.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClienteViewModel> lst;

            using (OneCoreDb2023Entities db = new OneCoreDb2023Entities())

            {
                lst = (from d in db.CLIENTES
                       select new ListClienteViewModel

                {
                           ID = d.ID,
                           NOMBRE = d.NOMBRE,
                           RFC = d.RFC,
                           DIRECCION= d.DIRECCION,
                           CP= d.CP,
                           CORREO=d.CORREO
                       }).ToList();


            }
            return View(lst);

        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OneCoreDb2023Entities db = new OneCoreDb2023Entities())
                    {
                        var oNuevoUsuario = new CLIENTES();

                        oNuevoUsuario.ID = model.ID;
                        oNuevoUsuario.NOMBRE = model.NOMBRE;
                        oNuevoUsuario.RFC = model.RFC;
                        oNuevoUsuario.DIRECCION = model.DIRECCION;
                        oNuevoUsuario.CP = model.CP;
                        oNuevoUsuario.CORREO = model.CORREO;

                        db.CLIENTES.Add(oNuevoUsuario);
                        db.SaveChanges();
                    }
                }
                return Redirect("Index");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Id)
        {
            ClienteViewModel model = new ClienteViewModel();
            using (OneCoreDb2023Entities db = new OneCoreDb2023Entities())
            {

                var oTabla = db.CLIENTES.Find(Id);
                model.NOMBRE = oTabla.NOMBRE;
                model.RFC= oTabla.RFC;
                model.DIRECCION = oTabla.DIRECCION;
                model.CP = oTabla.CP;
                model.CORREO = oTabla.CORREO;

                model.ID= Id;
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OneCoreDb2023Entities db = new OneCoreDb2023Entities())
                    {
                        var oTabla = db.CLIENTES.Find(model.ID);

                        oTabla.ID = model.ID;
                        oTabla.NOMBRE = model.NOMBRE;
                        oTabla.RFC = model.RFC;
                        oTabla.DIRECCION = model.DIRECCION;
                        oTabla.CP = model.CP;
                        oTabla.CORREO = model.CORREO;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {

            using (OneCoreDb2023Entities db = new OneCoreDb2023Entities())
            {
                var oNuevoUsuario = db.CLIENTES.Find(Id);
                db.CLIENTES.Remove(oNuevoUsuario);
                db.SaveChanges();
            }
            return Redirect("~/Cliente/");
        }

    }
}