namespace NutricionApp.Models
{
    public class Usuario
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public int Edad { get; set; }
        public string Objetivo { get; set; } // "perder", "mantener", "ganar"
        public string NivelActividad { get; set; } // "sedentario", "ligero", "moderado", "intenso"
    }
}
