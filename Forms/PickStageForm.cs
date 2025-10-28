using AxWMPLib;
using PokemonProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonProject.Forms
{
    public partial class PickStageForm : Form
    {
        private bool stage1Completed = false;
        private bool stage2Completed = false;


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


        private List<StageForm1> _stages;

        public List<StageForm1> Stages
        {
            get => _stages;
            set => _stages = value;
        }

        public PickStageForm(User player, List<User> players)
        {
            InitializeComponent();
            Player = player;
            Players = players;
        }

        private void PickStage_Load(object sender, EventArgs e)
        {
            SetupPictureBoxHover(pictureBox1);
            SetupPictureBoxHover(pictureBox2);
            SetupPictureBoxHover(pictureBox3);

            // Chỉ cho màn 1 được chọn lúc đầu
        }


        // 🧩 Hiệu ứng hover rung nhẹ
        private void SetupPictureBoxHover(PictureBox pb)
        {
            Point originalLocation = pb.Location;

            pb.MouseEnter += async (s, e) =>
            {
                if (!pb.Enabled) return; // Không rung nếu bị khóa

                int amplitude = 5;
                int speed = 20;
                int shakes = 6;

                for (int i = 0; i < shakes; i++)
                {
                    pb.Location = new Point(originalLocation.X + amplitude, originalLocation.Y);
                    await Task.Delay(speed);
                    pb.Location = new Point(originalLocation.X - amplitude, originalLocation.Y);
                    await Task.Delay(speed);
                }

                pb.Location = originalLocation;
            };

            pb.MouseLeave += (s, e) =>
            {
                pb.Location = originalLocation;
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!pictureBox1.Enabled) return;
            PickPokemonForm poke = new PickPokemonForm(1,Player, Players);
            poke.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!Player.Man2)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 1 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PickPokemonForm poke = new PickPokemonForm(2,Player, Players);
            poke.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!Player.Man3)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 2 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PickPokemonForm poke = new PickPokemonForm(3, Player, Players);
            poke.Show();
        }

        private void btnSecrect_Click(object sender, EventArgs e)
        {
            if (!Player.Manserect)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 3 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PickPokemonForm poke = new PickPokemonForm(4, Player, Players);
            poke.Show();
        }
    }
}