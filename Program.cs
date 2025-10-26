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
        public static List<User> AllUsers;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}