using System.IO;

namespace Entity.Utilitarios
{
    public class ControlError
    {
        public void LogErrorMetodos(string clase, string Metodo, string error)
        {
			var ruta = string.Empty;
			var archivo = string.Empty;
			DateTime fecha = DateTime.Now;

			try
			{
				ruta = "C:\\ProyectoIntegrador\\Logs";
				archivo = $"Log_{fecha.ToString("dd-MM-yyyy")}";

				if (!Directory.Exists(ruta))
				{
					Directory.CreateDirectory(ruta);
                }

				StreamWriter write = new StreamWriter($"{ruta}\\{archivo}", true);
				write.WriteLine($"Se presentó una novedad en la clase: {clase}, en el método: {Metodo}, con el siguiente error: {error}");
				write.Close();

            }
			catch (Exception ex)
			{
				throw;
			}
        }
    }
}
