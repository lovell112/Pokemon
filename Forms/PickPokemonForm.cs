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
        private Pokemon[] _pokemons = new Pokemon[4];

        public Pokemon[] Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }
        public PickPokemonForm()
        {
            InitializeComponent();
            Pokemons[0] = new Pokemon("Charmander", new PictureBox(), 100, Systems.Fire,
                new Skill("Phun lua", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[0].Image.Image = global::PokemonProject.Properties.Resources.Charmande;

            Pokemons[1] = new Pokemon("Bulbasaur", new PictureBox(), 100, Systems.Grass,
                new Skill("Bao la", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[1].Image.Image = global::PokemonProject.Properties.Resources.Bulbasaur;

            Pokemons[2] = new Pokemon("Squirtle", new PictureBox(), 100, Systems.Water,
                new Skill("Phun nuoc", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[2].Image.Image = global::PokemonProject.Properties.Resources.Squirtle;

            Pokemons[3] = new Pokemon("Pikachu", new PictureBox(), 100, Systems.Thunder,
                new Skill("Dien 100k vol", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[3].Image.Image = global::PokemonProject.Properties.Resources.pikachuu;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chọn Charmander không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StageForm fightForm = new StageForm(true, Pokemons[0], Pokemons[0]);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chọn Bulbasaur không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StageForm fightForm = new StageForm(true, Pokemons[1], Pokemons[0]);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chọn Squirtle không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StageForm fightForm = new StageForm(true, Pokemons[2], Pokemons[0]);
                fightForm.Show();
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chọn Pikachu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StageForm fightForm = new StageForm(true, Pokemons[3], Pokemons[0]);
                fightForm.Show();
                this.Close();
            }
        }
    }
}