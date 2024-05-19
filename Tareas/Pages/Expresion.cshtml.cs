using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tareas.Pages
{
    public class ExpresionModel : PageModel
    {
        [BindProperty]
        public int a { get; set; }

        [BindProperty]
        public int b { get; set; }

        [BindProperty]
        public int x { get; set; }

        [BindProperty]
        public int y { get; set; }

        [BindProperty]
        public int n { get; set; }

        public double[] resultados { get; set; }
        public double sumaResultado { get; set; }


        public void OnPost()
        {
            if (n < 0)
            {
                ModelState.AddModelError(string.Empty, "El valor de n no puede ser negativo.");
                return;
            }

            resultados = new double[n + 1];
            sumaResultado = 0;

            for (int k = 0; k <= n; k++)
            {
                resultados[k] = (CalcularFactorial(n) / (CalcularFactorial(k) * CalcularFactorial(n - k)))
                    * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);

                sumaResultado += resultados[k];
            }
        }

        private double CalcularFactorial(int numero)
        {
            double resultado = 1;
            for (int i = 1; i <= numero; i++)
            {
                resultado *= i;
            }
            return resultado;
        }
    }
}
