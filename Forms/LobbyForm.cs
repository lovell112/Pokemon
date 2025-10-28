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
using System.Xml.Linq;
using PokemonProject.Models;

namespace PokemonProject.Forms
{
    public partial class LobbyForm : Form
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
        public LobbyForm(User player, List<User> players)
        {
            InitializeComponent();
            this.Resize += Sanh_Resize; // Gọi lại khi thay đổi kích thước
            Player = player;
            Players = players;
        }
        #region hàm giao diện
        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabelLogout.Text = $"{Player.Name} — Đăng xuất";

            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "Resources/Audio/Music.mp3");
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();

            // Gắn sự kiện hover
            Play.MouseEnter += MouseEnter;
            Play.MouseLeave += MouseLeave;
            Exit.MouseEnter += MouseEnter1;
            Exit.MouseLeave += MouseLeave;

            
            SetupButtonStyle(Play);
            SetupButtonStyle(SelectPoke);
            SetupButtonStyle(Exit);

            
            CenterButtons();
        }

        // Dùng API để bo tròn góc
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        // Hàm bo tròn và làm mờ nền
        private void SetupButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(100, Color.White); // Nền mờ trắng
            btn.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 25, 25)); // Bo góc 25px
        }

        //Hàm canh giữa các nút theo kích thước form
        private void CenterButtons()
        {
            int spacing = 20;
            int totalHeight = Play.Height + SelectPoke.Height + Exit.Height + spacing * 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            Play.Left = (this.ClientSize.Width - Play.Width) / 2;
            Play.Top = startY;

            Exit.Left = (this.ClientSize.Width - Exit.Width) / 2;
            Exit.Top = Play.Bottom + spacing;
        }

        // Cập nhật vị trí khi đổi kích thước
        private void Sanh_Resize(object sender, EventArgs e)
        {
            CenterButtons();
        }

        // Sự kiện hover
        private void MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(180, 0, 128, 0);  //Xanh lá trong mờ
            btn.ForeColor = Color.White;
        }

        private void MouseEnter1(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(180, 255, 0, 0);  // Đỏ trong mờ
            btn.ForeColor = Color.White;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(100, Color.White);
            btn.ForeColor = SystemColors.ControlText;
        }

        #endregion
        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            PickStageForm pickStageForm = new PickStageForm(Player, Players);
            pickStageForm.Show();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            // this.Hide();
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

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?",
                                         "Đăng xuất",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Kiểm tra trong danh sách form đang mở (OpenForms) có LoginForm nào chưa
                var existingLogin = Application.OpenForms.OfType<LoginForm>().FirstOrDefault();
                if (existingLogin == null)
                {
                    existingLogin = new LoginForm();
                    existingLogin.Show();
                }
                else
                {
                    existingLogin.Show();
                    existingLogin.BringToFront(); 
                }

                axWindowsMediaPlayer1.Ctlcontrols.pause(); // Dừng nhạc nền khi đăng xuất
                this.Close(); // Đóng LobbyForm
            }
        }

        private void btnOpenScore_Click(object sender, EventArgs e)
        {
            ScoreboardForm scoreBoard = new ScoreboardForm(Players);
            scoreBoard.Show();
        }
    }
}