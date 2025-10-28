using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonProject.Models;

namespace PokemonProject.Forms
{
    public partial class PickPokemonForm : Form
    {
        private User _player;

        public User Player
        {
            get => _player;
            set => _player = value;
        }

        private List<User> _players = new List<User>();
        public List<User> Players
        {
            get => _players;
            set => _players = value;
        }

        private Pokemon[] _pokemons = new Pokemon[4];

        int selected;
        public Pokemon[] Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }
        public PickPokemonForm(int _selected,User player, List<User> players)
        {
            InitializeComponent();
            Player = player;
            Players = players;

            selected = _selected;
            Pokemons[0] = new Pokemon("Charmander", new PictureBox(), 20, Systems.Fire,
                new Skill("Phun lua", 4, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox()));
            Pokemons[0].Image.Image = global::PokemonProject.Properties.Resources.Charmande;
            Pokemons[0].Skill1.Image.Image = global::PokemonProject.Properties.Resources.FireAttack;
            Pokemons[0].Skill2.Image.Image = global::PokemonProject.Properties.Resources.Skill2;

            Pokemons[1] = new Pokemon("Bulbasaur", new PictureBox(), 20, Systems.Grass,
                new Skill("Bao la", 4, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox()));
            Pokemons[1].Image.Image = global::PokemonProject.Properties.Resources.Bulbasaur;
            Pokemons[1].Skill1.Image.Image = global::PokemonProject.Properties.Resources.GrassAtk;
            Pokemons[1].Skill2.Image.Image = global::PokemonProject.Properties.Resources.Skill2;

            Pokemons[2] = new Pokemon("Squirtle", new PictureBox(), 20, Systems.Water,
                new Skill("Phun nuoc", 4, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox()));
            Pokemons[2].Image.Image = global::PokemonProject.Properties.Resources.Squirtle;
            Pokemons[2].Skill1.Image.Image = global::PokemonProject.Properties.Resources.WaterAttack;
            Pokemons[2].Skill2.Image.Image = global::PokemonProject.Properties.Resources.Skill2;

            Pokemons[3] = new Pokemon("Pikachu", new PictureBox(), 20, Systems.Thunder,
                new Skill("Dien 100k vol", 6, new PictureBox()), new Skill("Tan Cong Toc Do", 2, new PictureBox()));
            Pokemons[3].Image.Image = global::PokemonProject.Properties.Resources.pikachuu;
            Pokemons[3].Skill1.Image.Image = global::PokemonProject.Properties.Resources.ThunderAttack;
            Pokemons[3].Skill2.Image.Image = global::PokemonProject.Properties.Resources.Skill2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (selected == 1)
            {
                StageForm1 fightForm = new StageForm1(true, Pokemons[0],Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 2)
            {
                StageForm2 fightForm = new StageForm2(true, Pokemons[0], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 3)
            {
                StageForm3 fightForm = new StageForm3(true, Pokemons[0], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 4)
            {
                StageFormSerect fightForm = new StageFormSerect(true, Pokemons[0], Player, Players);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (selected == 1)
            {
                StageForm1 fightForm = new StageForm1(true, Pokemons[1],Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 2)
            {
                StageForm2 fightForm = new StageForm2(true, Pokemons[1], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 3)
            {
                StageForm3 fightForm = new StageForm3(true, Pokemons[1], Player , Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 4)
            {
                StageFormSerect fightForm = new StageFormSerect(true, Pokemons[1],  Player, Players);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (selected == 1)
            {
                StageForm1 fightForm = new StageForm1(true, Pokemons[2], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 2)
            {
                StageForm2 fightForm = new StageForm2(true, Pokemons[2], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 3)
            {
                StageForm3 fightForm = new StageForm3(true, Pokemons[2], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 4)
            {
                StageFormSerect fightForm = new StageFormSerect(true, Pokemons[2], Player, Players);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (selected == 1)
            {
                StageForm1 fightForm = new StageForm1(true, Pokemons[3], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 2)
            {
                StageForm2 fightForm = new StageForm2(true, Pokemons[3], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 3)
            {
                StageForm3 fightForm = new StageForm3(true, Pokemons[3], Player, Players);
                fightForm.Show();
                this.Close();
            }

            if (selected == 4)
            {
                StageFormSerect fightForm = new StageFormSerect(true, Pokemons[3], Player, Players);
                fightForm.Show();
                this.Close();
            }
        }

        private void PickPokemonForm_Load(object sender, EventArgs e)
        {

        }
    }
}