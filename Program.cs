using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonProject.Forms;
using PokemonProject.Models;

namespace PokemonProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string lastUserName = User.LoadLastUser();

            if (!string.IsNullOrEmpty(lastUserName))
            {
                // Nếu đã có tên user -> tạo User và vào thẳng Lobby
                var pokemons = new Pokemon[0];
                var stages = new StageForm[0];
                var user = new User(lastUserName, stages, pokemons);
                Application.Run(new LobbyForm(user));
            }
            else
            {
                // Nếu chưa có -> vào form Login
                Application.Run(new LoginForm());
            }
        }
    }
}