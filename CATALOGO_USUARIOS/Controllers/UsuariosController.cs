using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CATALOGO_USUARIOS.Models; 
using System.Data.Entity;
using System.Data;
using System.Web.ApplicationServices;

namespace CATALOGO_USUARIOS.Controllers
{
    public class UsuariosController : Controller
    {
        private DbModels db = new DbModels();
        private RolesController rc = new RolesController();

        public ActionResult IndexUsuario()
        {
            var usuarios = db.Usuarios.Include(u => u.Roles).ToList();
            var roles = db.Roles.ToList();

            ViewBag.Lista = roles;

            return View(usuarios);
        }


        // GET: Usuarios/Create
        public ActionResult CreateUsuario()
        {
            var Lista = rc.IndexRoles();
            ViewBag.Lista = Lista;
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsuario([Bind(Include = "id,Nombre,Correo,Curp,Edad,Genero,IdRol")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception();

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario agregado con éxito.";
                    return RedirectToAction("IndexUsuario");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = " Error al guardar el usuario";
                }
            }

            ViewBag.Roles = rc.IndexRoles();
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult EditUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            ViewBag.Lista = rc.IndexRoles();
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUsuario([Bind(Include = "id,Nombre,Correo,Curp,Edad,Genero,IdRol")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception();

                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario editado con éxito.";
                    return RedirectToAction("IndexUsuario");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = " Error al editar el usuario";
                }
            }
            ViewBag.Lista = rc.IndexRoles();
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult DeleteUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("DeleteUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Usuarios usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.IsDeleted = true;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario eliminado con éxito.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el usuario: ";
            }

            return RedirectToAction("IndexUsuario");
            /*try
            {
                
                {
                    Usuarios usuario = db.Usuarios.Find(id);
                    if (usuario != null)
                    {
                        db.Usuarios.Remove(usuario);
                        db.SaveChanges();
                        TempData["SuccessMessage"] = "Usuario eliminado correctamente.";
                        return RedirectToAction("IndexUsuarios");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Usuario no encontrado.";
                    }
                }

                return RedirectToAction("IndexUsuarios");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el usuario: " + ex.Message;
                return RedirectToAction("IndexUsuarios");
            }*/

        }
    }
}
