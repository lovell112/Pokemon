using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonProject.Models;

namespace PokemonProject.Forms
{
    public partial class StageForm : Form
    {
        Random random = new Random(); // 🔹 Sinh số ngẫu nhiên cho phản công

        private Pokemon pokemon_1;
        private Pokemon pokemon_2;
        private bool _unlock;

        public bool Unlock
        {
            get => _unlock;
            set => _unlock = value;
        }

        public StageForm(Pokemon selectedPokemon)
        {
            InitializeComponent();
            pokemon_1 = selectedPokemon;
            //pokemon_2 = pokemonboss;
        }
       

        private void Fight_Load(object sender, EventArgs e)
        {

            //đổi theo pokemon
            lblPokemonName.Text = pokemon_1.Name;
            pictureBoxPokemon.Image = pokemon_1.Image.Image;
            skill1.Text = pokemon_1.Skill1.Name;
            skill2.Text = pokemon_1.Skill2.Name;



            // Nhạc nền
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "Resources/Audio/Fight.mp3");
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();

            // Cài đặt máu
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            progressBar1.Value = 10;

            progressBar2.Minimum = 0;
            progressBar2.Maximum = 10;
            progressBar2.Value = 10;

            // Gán sự kiện hover
            skill1.MouseEnter += MouseEnter;
            skill1.MouseLeave += MouseLeave;
            skill2.MouseEnter += MouseEnter;
            skill2.MouseLeave += MouseLeave;

            UpdateHPLabels();
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Green;
            btn.ForeColor = Color.White;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control;
            btn.ForeColor = SystemColors.ControlText;
        }

        #region Chiến đấu

        private void UpdateHPLabels()
        {
            lblHpenemy.Text = $"HP: {progressBar2.Value}/{progressBar1.Maximum}";
            lblHpPokemon.Text = $"HP: {progressBar1.Value}/{progressBar2.Maximum}";
        }

        // Biến toàn cục
        private Random r = new Random();
        private int turnCount = 0;

        // Hiệu ứng giảm máu dần dần
        private async Task AnimateHPDecrease(ProgressBar pb, int amount)
        {
            int target = Math.Max(pb.Minimum, pb.Value - amount);
            while (pb.Value > target)
            {
                pb.Value--;
                await Task.Delay(100); // giảm mỗi 0.1 giây
            }
        }

        // Hiệu ứng tăng máu
        private async Task AnimateHPIncrease(ProgressBar pb, int amount)
        {
            int target = Math.Min(pb.Maximum, pb.Value + amount);
            while (pb.Value < target)
            {
                pb.Value++;
                await Task.Delay(100);
            }
        }

        // Khi bạn dùng chiêu
        private async void chieu1_Click(object sender, EventArgs e)
        {
            await PlayerAttack(3, "Skill 1");
        }

        private async void chieu2_Click(object sender, EventArgs e)
        {
            await PlayerAttack(1, "Skill 2");
        }

        // Hàm xử lý tấn công và phản công
        private async Task PlayerAttack(int damage, string skillName)
        {
            skill1.Enabled = false;
            skill2.Enabled = false;

            turnCount++;
            AddComment($"🌀 Lượt {turnCount}: Pokémon phe ta dùng {skillName}, gây {damage} sát thương!");
            await Task.Delay(800);

            // Phe ta tấn công trước
            await HitEffect(pictureBoxEnemy);
            await AnimateHPDecrease(progressBar2, damage);
            UpdateHPLabels();

            // Kiểm tra nếu địch thua
            if (progressBar2.Value == progressBar2.Minimum)
            {
                pictureBoxEnemy.Visible = false;
                txtComment.AppendText($"🎉 Đối thủ đã gục ngã! Bạn chiến thắng!\r\n");
                await Task.Delay(800);
                MessageBox.Show("🎉 Bạn đã chiến thắng!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            // Đối thủ phản công
            await Task.Delay(600);
            int enemyDamage = r.Next(1, 4); // từ 1–3
            AddComment($"⚔️ Đối thủ phản công, gây {enemyDamage} sát thương!");

            await HitEffect(pictureBoxPokemon);
            await AnimateHPDecrease(progressBar1, enemyDamage);
            UpdateHPLabels();
            
            // Kiểm tra nếu phe ta thua
            if (progressBar1.Value == progressBar1.Minimum)
            {
                AddComment("💀 Pokémon của bạn đã ngã gục!");
                await Task.Delay(800);
                MessageBox.Show("💀 Bạn đã thua!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Kết thúc lượt
            await Task.Delay(800);
            AddComment("✨ Hãy chọn chiêu tiếp theo!");

            skill1.Enabled = true;
            skill2.Enabled = true;
        }

        // 🌀 Hiệu ứng rung + flash đỏ khi bị đánh
        private async Task HitEffect(PictureBox pb, int intensity = 6, int shakes = 12, int delay = 20)
        {
            Point originalLocation = pb.Location;
            Color originalColor = pb.BackColor;
            Random rand = new Random();

            // Flash đỏ 3 lần
            for (int i = 0; i < 3; i++)
            {
                pb.BackColor = Color.FromArgb(180, Color.Red);
                await Task.Delay(80);
                pb.BackColor = Color.Transparent;
                await Task.Delay(80);
            }

            // Rung
            for (int i = 0; i < shakes; i++)
            {
                int offsetX = rand.Next(-intensity, intensity + 1);
                int offsetY = rand.Next(-intensity, intensity + 1);
                pb.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY);
                await Task.Delay(delay);
            }

            // Trở về trạng thái ban đầu
            pb.Location = originalLocation;
            pb.BackColor = originalColor;
        }



        #endregion

        private void AddComment(string text)
        {
            txtComment.AppendText(text + Environment.NewLine);
            txtComment.SelectionStart = txtComment.Text.Length;
            txtComment.ScrollToCaret();
        }

        private void btnNhac_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btnNhac.Text = "🔇";

            }
            else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btnNhac.Text = "🔊";
            }
        }

    }
}
