using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tareas.Pages
{
    public class AlfabetoLatinoModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int ValorN { get; set; }

        public char[] Alfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public string Resultado { get; set; } = "";

        public void OnPost()
        {
            string accion = Request.Form["accion"];
            string mensajeCifrado = "";
            int desplazamiento = ValorN % 26;

            foreach (char caracter in Mensaje.ToUpper())
            {
                if (char.IsLetter(caracter))
                {
                    int posicion = Array.IndexOf(Alfabeto, caracter);

                    switch (accion)
                    {
                        case "Cifrar":
                            posicion = (posicion + desplazamiento) % Alfabeto.Length;
                            if (posicion < 0) posicion += Alfabeto.Length;
                            break;

                        case "Descifrar":
                            posicion = (posicion - desplazamiento) % Alfabeto.Length;
                            if (posicion < 0) posicion += Alfabeto.Length;
                            break;
                    }

                    char caracterCifrado = Alfabeto[posicion];
                    mensajeCifrado += caracterCifrado;
                }
                else
                {
                    mensajeCifrado += caracter;
                }
            }

            Resultado = mensajeCifrado;
        }
    }
}
