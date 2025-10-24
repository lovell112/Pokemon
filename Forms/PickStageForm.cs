using AxWMPLib;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonProject.Models;

namespace PokemonProject.Forms
{
    public partial class PickStageForm : Form
    {
        private bool stage1Completed = false;
        private bool stage2Completed = false;
        private StageForm[] _stages;

        public StageForm[] Stages
        {
            get => _stages;
            set => _stages = value;
        }

        public PickStageForm(User player)
        {
            InitializeComponent();
            Stages = player.Stageses;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PickPokemonForm poke = new PickPokemonForm();
            poke.Show();
            this.Enabled = false;
            poke.FormClosed += (s, args) =>
            {
                this.Enabled = true; // Mở lại form chính
            };
        }

        private void Manchoi_Load(object sender, EventArgs e)
        {
            SetupPictureBoxHover(pictureBox1);
            SetupPictureBoxHover(pictureBox2);
            SetupPictureBoxHover(pictureBox3);

            // Chỉ cho màn 1 được chọn lúc đầu
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;

            pictureBox2.BackColor = Color.Gray;
            pictureBox3.BackColor = Color.Gray;
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

            PickPokemonForm poke = new PickPokemonForm();
            poke.Show();

            poke.FormClosed += (s, args) =>
            {
                stage1Completed = true;
                pictureBox2.Enabled = true;
                pictureBox2.BackColor = Color.Transparent;

                Program.CurrentUser.HighestLevelUnlock = 1; // Màn 1 đã hoàn thành
                Program.CurrentUser.SaveUserData();
            };
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!stage1Completed)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 1 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PickPokemonForm poke = new PickPokemonForm();
            poke.Show();

            poke.FormClosed += (s, args) =>
            {
                stage2Completed = true;
                pictureBox3.Enabled = true;
                pictureBox3.BackColor = Color.Transparent;

                Program.CurrentUser.HighestLevelUnlock = 2; // Màn 2 đã hoàn thành
                Program.CurrentUser.SaveUserData();
            };
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!stage2Completed)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 2 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Program.CurrentUser.HighestLevelUnlock = 3; // Màn 3 đã hoàn thành
            Program.CurrentUser.SaveUserData();
            PickPokemonForm poke = new PickPokemonForm();
            poke.Show();
        }
    }
}
