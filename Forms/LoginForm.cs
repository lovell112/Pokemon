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
using PokemonProject.Models.DataProcessor;
using StageForm = PokemonProject.Forms.StageForm;

namespace PokemonProject
{
    public partial class LoginForm : Form
    {
        Panel panelDangKy = new Panel();

        #region  player
        private User _player;
        public User Player
        {
            get => _player;
            set => _player = value;
        }
        #endregion

        #region pokemons
        private List<Pokemon> _pokemons = new List<Pokemon>();
        public List<Pokemon> Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }
        #endregion

        #region Stages
        private List<StageForm> _stages = new List<StageForm>();
        public List<StageForm> Stages
        {
            get => _stages;
            set => _stages = value;
        }
        #endregion

        #region các hàm giao diện
        private void Login_Resize(object sender, EventArgs e)
        {
            // Căn giữa panel trong form
            PanelNhapTen.Left = (panel2.Width - PanelNhapTen.Width) / 2;
            PanelNhapTen.Top = (panel2.Height - PanelNhapTen.Height) / 2;
        }

        private void Login_Load(object sender, EventArgs e)
        {

            LoadData();

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

        private List<User> users;
        public void LoadData()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User_Data.txt");
            users = DataReader.ReadUsersFrom(path);

            Console.WriteLine($"Đọc file thành công, số lượng users: {users.Count}");

            if (users.Count == 0)
            {
                Console.WriteLine("Không tìm thấy người dùng nào trong dữ liệu!");
                return;
            }

            Player = users.Last();
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            var lobby = new LobbyForm(Player);
            lobby.FormClosed += (s, e) =>
            {
                this.Show();
                lobby.Dispose();
            }; // Giải phóng form hiện tại khi lobby đóng
            lobby.ShowDialog();
            this.Hide();
        }

        public void SaveData()
        {
            DataWriter.WriteUsersTo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User_Data.txt"), users);
            Console.WriteLine("Luu thanh cong");
        }
        public LoginForm()
        {
            InitializeComponent();
            // StageForm Stage1 = new StageForm()
        }



        ~LoginForm()
        {
            SaveData();
        }

        private void initPokemon(List<Pokemon> args)
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

        private void initStageForms(List<StageForm> args, List<Pokemon> poke)
        {
            args.Add(new StageForm(true, null, poke[0]));
            args.Add(new StageForm(false, null, poke[1]));
            args.Add(new StageForm(false, null, poke[2]));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (HoTen.Text == null)
                return;

            bool isFind = false;
            foreach (var user in users)
            {
                if (HoTen.Text == user.Name)
                {
                    Player = user;
                    isFind = true;
                    break;
                }
            }

            if (isFind)
            {
                Console.WriteLine($"player : {Player.Name}, {Stages[0].Unlock}, {Pokemons[0].Name}");
                LobbyForm lob = new LobbyForm(Player);
                this.Hide();
                SaveData();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                return;
            }

            initPokemon(Pokemons);
            initStageForms(Stages, Pokemons);
            users.Add(new User(HoTen.Text, Stages, Pokemons));
            Player = users[users.Count - 1];
            //  Chuyển sang Lobby
            Console.WriteLine($"player : {Player.Name}, {Stages[0].Unlock}, {Pokemons[0].Name}");
            LobbyForm lobby = new LobbyForm(Player);
            lobby.Show();
            this.Hide();
            SaveData();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
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