using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App2.Data;
using App2.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace App2.Controllers
{
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;      

        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rubros
        public async Task<IActionResult> Index()
        {
            ViewBag.RubrosID = new SelectList(_context.Rubros.OrderBy(p => p.RubroID), "RubroID", "Descripcion");
            return View(await _context.Rubros.ToListAsync());
        }

        public JsonResult BuscarRubros()
        {
            var rubros = _context.Rubros.ToList();

            return Json(rubros);
        }

        public JsonResult GuardarImagen(string rubroNombre, IFormFile archivo)
        {

            if (archivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    archivo.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var tipoDeArchivo = archivo.ContentType;
                    string base64 = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }

            //aqui va el codigo que deseemos para manipular el archivo
            return Json(true);
        }

        public JsonResult GuardarRubro(int RubroID, string Descripcion)
        {
            int resultado = 0;

            //SI ES 0 - ES CORRECTO
            //SI ES 1 - CAMPO DESCRIPCION ESTÁ VACIO
            //SI ES 2 - EL REGISTRO YA EXISTE CON LA MISMA DESCRIPCION

            if (!string.IsNullOrEmpty(Descripcion))
            {
                Descripcion = Descripcion.ToUpper();
                if (RubroID == 0)
                {
                    //ANTES DE CREAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Rubros.Any(e => e.Descripcion == Descripcion))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //CREA EL REGISTRO DE RUBRO
                        //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                        var rubro = new Rubro
                        {
                            Descripcion = Descripcion
                        };
                        _context.Add(rubro);
                        _context.SaveChanges();
                    }                  
                }
                else
                {
                    //ANTES DE EDITAR EL REGISTRO DEBEMOS PREGUNTAR SI EXISTE UNO CON LA MISMA DESCRIPCION
                    if (_context.Rubros.Any(e => e.Descripcion == Descripcion && e.RubroID != RubroID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //EDITA EL REGISTRO
                        //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                        var rubro = _context.Rubros.Single(m => m.RubroID == RubroID);
                        //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                        rubro.Descripcion = Descripcion;
                        _context.SaveChanges();
                    }                  
                }
            }
            else
            {
                resultado = 1;
            }

            return Json(resultado);
        }

        //Add-Migration InitialCreated
        //Update-Database

        public JsonResult BuscarRubro(int RubroID)
        {
            var rubro = _context.Rubros.FirstOrDefault(m => m.RubroID == RubroID);

            return Json(rubro);
        }

        public JsonResult EliminarRubro(int RubroID, int Elimina)
        {
            int resultado = 0;

            var rubro = _context.Rubros.Find(RubroID);
            if (rubro != null)
            {
                if (Elimina == 0)
                {
                    rubro.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR RUBRO SI TIENE SUBRUBROS ACTIVOS
                    var cantidadSubRubros = (from o in _context.Subrubros where o.RubroID == RubroID && o.Eliminado == false select o).Count();
                    if (cantidadSubRubros == 0)
                    {
                        rubro.Eliminado = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        resultado = 1;
                    }
                }                              
            }

            return Json(resultado);
        }
      
        private bool RubroExists(int id)
        {
            return _context.Rubros.Any(e => e.RubroID == id);
        }
    }
}
