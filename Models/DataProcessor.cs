using PokemonProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PokemonProject.Models
{
    namespace DataProcessor
    {
        public static class DataReader
        {
            private static void initPokemon(List<Pokemon> args)
            {
                args.Add(new Pokemon("Charmander", new PictureBox(), 10, Systems.Fire,
                    new Skill("Phun lua", 2, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox())));
                args[0].Image.Image = global::PokemonProject.Properties.Resources.charmanderEnemy;

                args.Add(new Pokemon("Bulbasaur", new PictureBox(), 10, Systems.Grass,
                    new Skill("Bao la", 2, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox())));
                args[1].Image.Image = global::PokemonProject.Properties.Resources.Bulbasaur;

                args.Add(new Pokemon("Squirtle", new PictureBox(), 10, Systems.Water,
                    new Skill("Phun nuoc", 2, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox())));
                args[2].Image.Image = global::PokemonProject.Properties.Resources.squirtleEnemy;

                args.Add(new Pokemon("Pikachu", new PictureBox(), 10, Systems.Thunder,
                    new Skill("Dien 100k vol", 2, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox())));
                args[3].Image.Image = global::PokemonProject.Properties.Resources.pikachuEnemy;
            }

            private static void initStageForm(List<StageForm> args, List<Pokemon> poke)
            {
                args.Add(new StageForm(true, poke[3], poke[0]));
                args.Add(new StageForm(false, poke[3], poke[1]));
                args.Add(new StageForm(false, poke[3], poke[2]));
            }

            public static List<User> ReadUsersFrom(string path)
            {
                List<User> users = new List<User>();
                try
                {
                    if (File.Exists(path))
                    {
                        string[] lines = File.ReadAllLines(path);
                        foreach (var line in lines)
                        {
                            List<Pokemon> pokemons = new List<Pokemon>();
                            initPokemon(pokemons);
                            List<StageForm> stages = new List<StageForm>();
                            initStageForm(stages, pokemons);

                            //SỬA: Đọc toàn bộ nội dung file (chỉ 1 dòng duy nhất sau khi SaveUserData được sửa)
                            if (!string.IsNullOrEmpty(line))
                            {
                                string[] parts = line.Split('|');
                                string name = parts[0];
                                stages[0].Unlock = parts[1] == "True";
                                stages[1].Unlock = parts[2] == "True";
                                stages[2].Unlock = parts[3] == "True";

                                User user = new User(name, stages, pokemons);
                                users.Add(user);
                            }
                        }
                    }
                    return users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc dữ liệu người dùng: {ex.Message}");
                    return null;
                }
            }
        }

        public static class DataWriter
        {
            public static void WriteUsersTo(string path, List<User> users)
            {
                List<string> Lines = new List<string>();
                foreach (var user in users)
                {
                    string line = $"{user.Name}|{user.Stageses[0].Unlock}|{user.Stageses[1].Unlock}|{user.Stageses[2].Unlock}";
                    Lines.Add(line);
                }

                File.WriteAllLines(path, Lines);
            }
        }
    }
}
