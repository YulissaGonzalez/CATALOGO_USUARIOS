using CATALOGO_USUARIOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CATALOGO_USUARIOS.Controllers
{
    public class RolesController : Controller
    {
        // GET: /Roles
        public List<Roles> IndexRoles()
        {
            using (DbModels context = new DbModels())
            {
                var roles = context.Roles.ToList();
                return roles;
            }
        }

        // Acción que llama a IndexRoles y muestra los datos en una vista
        public ActionResult Index()
        {
            var roles = IndexRoles();
            return View(roles);
        }



        // GET: /Roles/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
            }
        }

        // GET: /Roles/Create
        public ActionResult CreateRol()
        {
            return View();
        }

        // POST: /Roles/Create
        [HttpPost]
        public ActionResult CreateRol(Roles rol)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Roles.Add(rol);
                    context.SaveChanges();
                }

                return RedirectToAction("IndexRoles");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Roles/Edit/5
        public ActionResult EditRol(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
            }
        }

        // POST: /Roles/Edit/5
        [HttpPost]
        public ActionResult EditRol(int id, Roles rol)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(rol).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("IndexRoles");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult DeleteRol(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
            }
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult DeleteRol(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Roles rol = context.Roles.Where(x => x.idRol == id).FirstOrDefault();
                    context.Roles.Remove(rol);
                    context.SaveChanges();
                }

                return RedirectToAction("IndexRoles");
            }
            catch
            {
                return View();
            }
        }
    }
}
