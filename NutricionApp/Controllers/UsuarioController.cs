using Microsoft.AspNetCore.Mvc;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    
    public class UsuarioController : Controller
    {
        //accion para mostrar el formulario
        public IActionResult Formulario()
        {
            return View();
        }
        //accion para procesar el formulario
        [HttpPost]
        public IActionResult Calcular(Usuario usuario)
        {
            //aqui vamos a calcular las calorias mas tarde
            double calorias = CalcularCalorias(usuario);

            //enviamos el resultado a la vista
            ViewBag.Calorias = calorias;
            return View("Resultado", usuario);
         }
        //metodo para calcular calorias
        private double CalcularCalorias(Usuario usuario)
        {
            double caloriasBase = 10 * usuario.Peso + 6.25 * usuario.Altura - 5 * usuario.Edad;

            // ajuste segun el objetivo del usuario
            if (usuario.Objetivo == "ganar") caloriasBase += 500;
            else if (usuario.Objetivo == "perder") caloriasBase -= 500;

            // ajuste por nivel de actividad
            switch (usuario.NivelActividad)
            {
                case "sedentario": return caloriasBase * 1.2;
                case "ligero": return caloriasBase * 1.375;
                case "moderado": return caloriasBase * 1.55;
                case "intenso": return caloriasBase * 1.725;
                default: return caloriasBase;
            }

       
        }
    }


}
