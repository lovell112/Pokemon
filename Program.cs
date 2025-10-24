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
        public static User CurrentUser; // Biến toàn cục để giữ user hiện tại
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo danh sách Pokémon và Stage mặc định
            Pokemon[] pokemons = new Pokemon[4]
            {
                new Pokemon("Charmander", new PictureBox(), 100, Systems.Fire, new Skill("Phun lua", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox())),
                new Pokemon("Bulbasaur", new PictureBox(), 100, Systems.Grass, new Skill("Bao la", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox())),
                new Pokemon("Squirtle", new PictureBox(), 100, Systems.Water, new Skill("Phun nuoc", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox())),
                new Pokemon("Pikachu", new PictureBox(), 100, Systems.Thunder, new Skill("Dien 100k vol", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()))
            };

            StageForm[] stages = new StageForm[3]
            {
                new StageForm(pokemons[0]),
                new StageForm(pokemons[1]),
                new StageForm(pokemons[2])
            };

            User lastUser = User.LoadLastUser(pokemons, stages);



            if (lastUser != null)
            {
                Program.CurrentUser = lastUser;
                // Vào thẳng Lobby
                Application.Run(new LobbyForm(lastUser));
            }
            else
            {
                // Chưa có user -> Login
                Application.Run(new LoginForm());
            }
        }
    }
}