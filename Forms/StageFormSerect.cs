using PokemonProject.Models;
using PokemonProject.Models.DataProcessor;
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

namespace PokemonProject.Forms
{
    public partial class StageFormSerect : Form
    {
        Random random = new Random(); // Sinh số ngẫu nhiên cho phản công

        private Pokemon pokemon_1;

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

        public Pokemon Pokemon_1
        {
            get => pokemon_1;
            set => pokemon_1 = value;
        }

        private Pokemon pokemon_2;
        public Pokemon Pokemon_2
        {
            get => pokemon_2;
            set => pokemon_2 = value;
        }
        private bool _unlock;

        public bool Unlock
        {
            get => _unlock;
            set => _unlock = value;
        }

        private bool _heal;

        public bool Heal
        {
            get => _heal;
            set => _heal = value;
        }
            

        public StageFormSerect(bool state, Pokemon selectedPokemon,User player, List<User> players)
        {
            InitializeComponent();
            Heal = true;
            Unlock = state;
            pokemon_1 = selectedPokemon;
            Player = player;
            Players = players;
            pokemon_2 = new Pokemon("Lugie ", new PictureBox(), 40, Systems.Water,
                new Skill("Nha nuoc mieng", 6, new PictureBox()), new Skill("Tan Cong Toc Do", 4, new PictureBox()));
            pokemon_2.Skill1.Image.Image = global::PokemonProject.Properties.Resources.WaterAttack;
        }
        //public StageForm(Pokemon pokemonBoss)
        //{
        //    InitializeComponent();
        //    pokemon_2 = pokemonBoss;
        //}

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
            progressBar1.Maximum = Pokemon_1.HP;
            progressBar1.Value = 20;

            progressBar2.Minimum = 0;
            progressBar2.Maximum = Pokemon_2.HP;
            progressBar2.Value = 40;

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
            lblHpenemy.Text = $"HP: {progressBar2.Value}/{progressBar2.Maximum}";
            lblHpPokemon.Text = $"HP: {progressBar1.Value}/{progressBar1.Maximum}";
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

        

        // Khi bạn dùng chiêu
        private async void chieu1_Click(object sender, EventArgs e)
        {
            await PlayerAttack(pokemon_1.Skill1.Damage, "Skill 1");
        }

        private async void chieu2_Click(object sender, EventArgs e)
        {
            await PlayerAttack(pokemon_1.Skill2.Damage, "Skill 2");
        }

        // Hàm xử lý tấn công và phản công
        private async Task PlayerAttack(int damage, string skillName)
        {
            AddComment($"🌀 Lượt {turnCount}: Pokémon phe ta dùng {skillName}!", Color.Black);
            skill1.Enabled = false;
            skill2.Enabled = false;

            turnCount++;
            await SkillFlyEffect(pokemon_1.Skill1.Image.Image);

            if (pokemon_1.IsCounter(pokemon_2))
            {
                damage *= 2;
                AddComment($"Gây {damage} sát thương (siêu hiệu quả)!", Color.Blue);
            }
            else if (pokemon_2.IsCounter(pokemon_1))
            {
                damage /= 2;
                AddComment($"Gây {damage} sát thương (hiệu quả thấp)!", Color.Red);
            }
            else
            {
                AddComment($"Gây {damage} sát thương!", Color.Black);
            }


            await Task.Delay(800);

            // Phe ta tấn công trước
            await HitEffect(pictureBoxEnemy);
            await AnimateHPDecrease(progressBar2, damage);
            UpdateHPLabels();
            if (Heal == true && progressBar2.Value <= progressBar2.Maximum / 2)
            {
                Heal = false;
                progressBar2.Value = progressBar2.Maximum;
                Healer(pictureBoxEnemy);
                AddComment($"Kẻ địch hồi lại full hp!", Color.Green);
                UpdateHPLabels();
            }

            // Kiểm tra nếu địch thua
            if (progressBar2.Value == progressBar2.Minimum)
            {
               
                Player.Level[3] = pokemon_1.Name;
                DataWriter.WriteUsersTo("Scoreboard.txt", Players);

                pictureBoxEnemy.Visible = false;

                txtComment.AppendText($"🎉 Đối thủ đã gục ngã! Bạn chiến thắng!\r\n");
                await Task.Delay(800);
                MessageBox.Show("🎉 Bạn đã chiến thắng!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EndForm s = new EndForm();
                s.Show();

                this.Close();
                return;
            }

            // Đối thủ phản công
            await Task.Delay(600);
            int randomSkill = r.Next(1, 10);
            int enemyDamage = randomSkill % 2 == 0 ? pokemon_2.Skill2.Damage : pokemon_2.Skill1.Damage;
            AddComment($"Pokémon phe địch phản công !", Color.Black);
            await SkillFlyEffectEnemy(pokemon_2.Skill1.Image.Image);
            if (pokemon_2.IsCounter(pokemon_1))
            {
                enemyDamage *= 2;
                AddComment($"Gây {enemyDamage} sát thương (siêu hiệu quả)!", Color.Blue);
            }
            else if (pokemon_1.IsCounter(pokemon_2))
            {
                enemyDamage /= 2;
                AddComment($"Gây {enemyDamage} sát thương (hiệu quả thấp)!", Color.Red);
            }
            else
            {
                AddComment($"Gây {enemyDamage} sát thương!", Color.Black);
            }

            await HitEffect(pictureBoxPokemon);
            await AnimateHPDecrease(progressBar1, enemyDamage);
            UpdateHPLabels();

            // Kiểm tra nếu phe ta thua
            if (progressBar1.Value == progressBar1.Minimum)
            {
                AddComment("💀 Pokémon của bạn đã ngã gục!", Color.Red);
                await Task.Delay(800);
                MessageBox.Show("💀 Bạn đã thua!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Kết thúc lượt
            await Task.Delay(800);
            AddComment("✨ Hãy chọn chiêu tiếp theo!", Color.DarkBlue);

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

        // 🌀 Hiệu ứng rung + flash đỏ khi bị đánh
        private async Task Healer(PictureBox pb, int intensity = 6, int shakes = 12, int delay = 20)
        {
            Point originalLocation = pb.Location;
            Color originalColor = pb.BackColor;
            Random rand = new Random();

            // Flash đỏ 3 lần
            for (int i = 0; i < 3; i++)
            {
                pb.BackColor = Color.FromArgb(180, Color.Green);
                await Task.Delay(80);
                pb.BackColor = Color.Transparent;
                await Task.Delay(80);
            }

            // Trở về trạng thái ban đầu
            pb.Location = originalLocation;
            pb.BackColor = originalColor;
        }

        // 🌀 Hiệu ứng skill bay từ Pokemon phe ta đến góc trên bên phải
        private async Task SkillFlyEffect(Image skillImage)
        {
            // Tạo PictureBox tạm cho hiệu ứng
            PictureBox skillFx = new PictureBox
            {
                Image = skillImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(80, 80), // kích thước chiêu
                BackColor = Color.Transparent
            };

            // 🌀 Lấy vị trí thật của Pokemon phe ta
            Point absolutePokemonPos = this.PointToClient(pictureBoxPokemon.Parent.PointToScreen(pictureBoxPokemon.Location));

            Point start = new Point(
                absolutePokemonPos.X + pictureBoxPokemon.Width / 2 - skillFx.Width / 2,
                absolutePokemonPos.Y + pictureBoxPokemon.Height / 2 - skillFx.Height / 2
            );


            // Vị trí kết thúc: góc phải trên (ví dụ 50px lề phải, 50px lề trên)
            Point end = new Point(this.ClientSize.Width - skillFx.Width - 50, 50);

            // Đặt vị trí ban đầu và thêm vào form
            skillFx.Location = start;
            this.Controls.Add(skillFx);
            skillFx.BringToFront();

            // Bay mượt
            int steps = 40;
            for (int i = 0; i < steps; i++)
            {
                int newX = start.X + (end.X - start.X) * i / steps;
                int newY = start.Y + (end.Y - start.Y) * i / steps;
                skillFx.Location = new Point(newX, newY);
                await Task.Delay(15); // tốc độ bay
            }

            // Hiệu ứng nổ nhẹ (zoom to rồi mờ dần)
            for (int i = 0; i < 10; i++)
            {
                skillFx.Size = new Size(skillFx.Width + 4, skillFx.Height + 4);
                skillFx.Location = new Point(skillFx.Location.X - 2, skillFx.Location.Y - 2);
                skillFx.Image = skillImage;
                skillFx.Refresh();
                await Task.Delay(25);
            }

            // Biến mất
            skillFx.Visible = false;
            this.Controls.Remove(skillFx);
            skillFx.Dispose();
        }

        // 🌀 Hiệu ứng skill bay từ  góc trên bên phải đến Pokemon phe ta
        private async Task SkillFlyEffectEnemy(Image skillImage)
        {
            // Tạo PictureBox tạm cho hiệu ứng
            PictureBox skillFx = new PictureBox
            {
                Image = skillImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(80, 80), // kích thước chiêu
                BackColor = Color.Transparent
            };

            // 🌀 Lấy vị trí thật của Pokemon phe ta
           

            Point start = new Point(this.ClientSize.Width - skillFx.Width - 50, 50);


            // Vị trí kết thúc: góc phải trên (ví dụ 50px lề phải, 50px lề trên)
            Point absolutePokemonPos = this.PointToClient(pictureBoxPokemon.Parent.PointToScreen(pictureBoxPokemon.Location));
            Point end = new Point(
                absolutePokemonPos.X + pictureBoxPokemon.Width / 2 - skillFx.Width / 2,
                absolutePokemonPos.Y + pictureBoxPokemon.Height / 2 - skillFx.Height / 2
            );

            // Đặt vị trí ban đầu và thêm vào form
            skillFx.Location = start;
            this.Controls.Add(skillFx);
            skillFx.BringToFront();

            // Bay mượt
            int steps = 40;
            for (int i = 0; i < steps; i++)
            {
                int newX = start.X + (end.X - start.X) * i / steps;
                int newY = start.Y + (end.Y - start.Y) * i / steps;
                skillFx.Location = new Point(newX, newY);
                await Task.Delay(15); // tốc độ bay
            }

            // Hiệu ứng nổ nhẹ (zoom to rồi mờ dần)
            for (int i = 0; i < 10; i++)
            {
                skillFx.Size = new Size(skillFx.Width + 4, skillFx.Height + 4);
                skillFx.Location = new Point(skillFx.Location.X - 2, skillFx.Location.Y - 2);
                skillFx.Image = skillImage;
                skillFx.Refresh();
                await Task.Delay(25);
            }

            // Biến mất
            skillFx.Visible = false;
            this.Controls.Remove(skillFx);
            skillFx.Dispose();
        }


        #endregion

        private void AddComment(string text, Color color)
        {
            // Đặt con trỏ về cuối
            txtComment.SelectionStart = txtComment.TextLength;
            txtComment.SelectionLength = 0;

            // Đặt màu chữ
            txtComment.SelectionColor = color;

            // Thêm text + xuống dòng
            txtComment.AppendText(text + Environment.NewLine);

            // Reset màu về mặc định (đen)
            txtComment.SelectionColor = txtComment.ForeColor;

            // Cuộn xuống cuối
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

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
