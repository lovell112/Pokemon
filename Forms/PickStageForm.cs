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
        private User _player;
        public User Player
        {
            get => _player;
            set => _player = value;
        }

        private StageForm[] _stages;

        public StageForm[] Stages
        {
            get => _stages;
            set => _stages = value;
        }

        public PickStageForm(User player)
        {
            InitializeComponent();
            Player = player;
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

            //LOGIC TẢI TRẠNG THÁI MỞ KHÓA
            UpdateStageLockStatus();
        }


        //Hàm cập nhật trạng thái các màn chơi
        private void UpdateStageLockStatus()
        {
            // Stage 1: Level 1
            pictureBox1.Enabled = true;
            pictureBox1.BackColor = Color.Transparent;

            // Stage 2: Level 2
            if (Player.HighestLevelUnlock > 2)
            {
                pictureBox2.Enabled = true;
                pictureBox2.BackColor = Color.Transparent;
            }
            else
            {
                pictureBox2.Enabled = false;
                pictureBox2.BackColor = Color.Gray;
            }

            // Stage 3: Level 3
            if (Player.HighestLevelUnlock > 3)
            {
                pictureBox3.Enabled = true;
                pictureBox3.BackColor = Color.Transparent;
            }
            else
            {
                pictureBox3.Enabled = false;
                pictureBox3.BackColor = Color.Gray;
            }
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

        //Hàm xử lý khi hoàn thành Stage
        private void HandleStageCompletion(DialogResult result, int completedStageLevel)
        {
            if (result == DialogResult.OK && Player.HighestLevelUnlock == completedStageLevel)
            {
                int nextLevel = completedStageLevel + 1;

                // Đảm bảo không vượt quá giới hạn màn chơi
                if (nextLevel < Stages.Length + 1)
                {
                    Player.HighestLevelUnlock = nextLevel;

                    // Cập nhật giao diện ngay lập tức
                    UpdateStageLockStatus();

                    MessageBox.Show($"Chúc mừng! Màn {nextLevel} đã được mở khóa!", "Thành tích mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!pictureBox1.Enabled) return;

            //Lấy StageForm tương ứng với màn 1 (Stages[0])
            StageForm fightForm = Stages[0];

            // Mở form chiến đấu
            fightForm.ShowDialog();

            // Kiểm tra kết quả
            HandleStageCompletion(fightForm.DialogResult, 1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!pictureBox2.Enabled)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 1 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lấy StageForm tương ứng với màn 2(Stages[1])
            StageForm fightForm = Stages[1];

            fightForm.ShowDialog();

            // Kiểm tra kết quả
            HandleStageCompletion(fightForm.DialogResult, 2);
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!pictureBox3.Enabled)
            {
                MessageBox.Show("⚠️ Bạn phải hoàn thành Màn 2 trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lấy StageForm tương ứng với màn 2(Stages[1])
            StageForm fightForm = Stages[2];

            fightForm.ShowDialog();

            // Kiểm tra kết quả
            HandleStageCompletion(fightForm.DialogResult, 3);
        }
    }
}
