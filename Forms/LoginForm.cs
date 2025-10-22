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

namespace PokemonProject
{
    public partial class LoginForm : Form
    {
        Panel panelDangKy = new Panel();

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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string playerName = HoTen.Text.Trim();
            LobbyForm s = new LobbyForm(playerName); // 🔹 Truyền tên qua constructor
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