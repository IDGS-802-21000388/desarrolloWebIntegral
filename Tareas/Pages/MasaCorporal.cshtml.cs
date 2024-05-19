using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tareas.Pages
{
    public class MasaCorporalModel : PageModel
    {
        [BindProperty]
        public float peso { get; set; } = 0;

        [BindProperty]
        public float altura { get; set; } = 0;

        public float IMC { get; set; } = 0;
        public string mensaje { get; set; } = "";
        public string imagen { get; set; } = "";

        public void OnPost()
        {
            if (peso > 0 && altura > 0)
            {
                IMC = peso / (altura * altura);

                if (IMC < 18)
                {
                    mensaje = "peso Bajo";
                    imagen = "/images/peso_bajo.png";
                }
                else if (IMC >= 18 && IMC < 25)
                {
                    mensaje = "peso Normal";
                    imagen = "/images/peso_normal.png";
                }
                else if (IMC >= 25 && IMC < 27)
                {
                    mensaje = "Sobre peso";
                    imagen = "/images/sobre_peso.png";
                }
                else if (IMC >= 27 && IMC < 30)
                {
                    mensaje = "Obesidad grado I";
                    imagen = "/images/obesidad_grado_1.png";
                }
                else if (IMC >= 30 && IMC < 40)
                {
                    mensaje = "Obesidad grado II";
                    imagen = "/images/obesidad_grado_2.png";
                }
                else if (IMC >= 40)
                {
                    mensaje = "Obesidad grado III";
                    imagen = "/images/obesidad_grado_3.png";
                }
            }
        }
    }
}
