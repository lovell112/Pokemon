using AxWMPLib;
using PokemonProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PokemonProject.Models;
using StageForm = PokemonProject.Forms.StageForm;

namespace PokemonProject
{
    public partial class LoginForm : Form
    {
        Panel panelDangKy = new Panel();
        private User _player;

        public User Player
        {
            get => _player;
            set => _player = value;
        }

        private Pokemon[] _pokemons;

        public Pokemon[] Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }

        private StageForm[] _stages;

        public StageForm[] Stages
        {
            get => _stages;
            set => _stages = value;
        }
        
        #region các hàm giao diện
        private void Login_Resize(object sender, EventArgs e)
        {
            // Căn giữa panel trong form
            PanelNhapTen.Left = (panel2.Width - PanelNhapTen.Width) / 2;
            PanelNhapTen.Top = (panel2.Height - PanelNhapTen.Height) / 2;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "Resources/Audio/Littletown.mp3");
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();

            btnXacnhan.MouseEnter += MouseEnter;
            btnXacnhan.MouseLeave += MouseLeave;
            btnNhac.MouseEnter += MouseEnter;
            btnNhac.MouseLeave += MouseLeave;

            // 🔹 Ban đầu tắt nút xác nhận
            btnXacnhan.Enabled = false;

            // 🔹 Gắn sự kiện theo dõi khi nhập tên
            HoTen.TextChanged += (s, args) =>
            {
                bool coTen = !string.IsNullOrWhiteSpace(HoTen.Text);
                btnXacnhan.Enabled = coTen;
                btnXacnhan.BackColor = coTen ? Color.FromArgb(180, 0, 128, 0) : Color.Gray;
                btnXacnhan.ForeColor = coTen ? Color.White : Color.LightGray;
            };
        }
        private void MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            btn.BackColor = Color.FromArgb(180, 0, 128, 0);  //Xanh lá trong mờ
            btn.ForeColor = Color.White;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            btn.BackColor = Color.FromArgb(100, Color.White);
            btn.ForeColor = SystemColors.ControlText;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (HoTen.Text.Length >= 30 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Tên không được vượt quá 30 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        #endregion
        public LoginForm()
        {
            InitializeComponent();
            // StageForm Stage1 = new StageForm()
        }

        private void initPokemon()
        {
            Pokemons= new Pokemon[4];
            Pokemons[0] = new Pokemon("Charmander", new PictureBox(), 100, Systems.Fire,
                new Skill("Phun lua", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[0].Image.Image = global::PokemonProject.Properties.Resources.charmanderEnemy;
            Pokemons[1] = new Pokemon("Bulbasaur", new PictureBox(), 100, Systems.Grass,
                new Skill("Bao la", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[1].Image.Image = global::PokemonProject.Properties.Resources.Bulbasaur;
            Pokemons[2] = new Pokemon("Squirtle", new PictureBox(), 100, Systems.Water,
                new Skill("Phun nuoc", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[2].Image.Image = global::PokemonProject.Properties.Resources.squirtleEnemy;
            Pokemons[3] = new Pokemon("Pikachu", new PictureBox(), 100, Systems.Thunder,
                new Skill("Dien 100k vol", 10, new PictureBox()), new Skill("Tan Cong Toc Do", 5, new PictureBox()));
            Pokemons[3].Image.Image = global::PokemonProject.Properties.Resources.pikachuEnemy;
        }

        private void initStageForm()
        {
            Stages = new StageForm[3];
            Stages[0] = new StageForm(Pokemons[0]);
            Stages[1] = new StageForm(Pokemons[1]);
            Stages[2] = new StageForm(Pokemons[2]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player = new User(HoTen.Text.Trim(), Stages, Pokemons);
            Player.SaveUserData();

            LobbyForm s = new LobbyForm(Player); // 🔹 Truyền tên qua constructor
            s.Show();
            this.Hide();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnNhac_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btnNhac.Text = "🔇";
                
            }
            else if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btnNhac.Text = "🔊";
            }
        }
    }
}