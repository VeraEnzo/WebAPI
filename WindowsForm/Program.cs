using System; // <-- Aseg�rate de tener este using
using System.Windows.Forms; // <-- Aseg�rate de tener este using

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Quitamos ApplicationConfiguration.Initialize() si no es necesaria, 
            // o la dejamos si s� lo es.
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Bucle principal de la aplicaci�n
            while (true)
            {
                // 1. Mostrar el formulario de Login
                using (var loginForm = new LoginForm())
                {
                    // Si el usuario cierra el login sin loguearse (ej. clic en la 'X')
                    // rompemos el bucle y la aplicaci�n se cierra.
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                // 2. Si el login fue exitoso (DialogResult.OK), mostramos el MainForm
                using (var mainForm = new MainForm())
                {
                    mainForm.ShowDialog();
                }

                // 3. Cuando el MainForm se cierra (por "Cerrar Sesi�n"),
                // el bucle vuelve a empezar desde el paso 1.
            }

            // Si el bucle se rompe (paso 1), la aplicaci�n termina.
        }
    }
}