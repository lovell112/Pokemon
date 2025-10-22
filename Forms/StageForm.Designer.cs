namespace PokemonProject.Forms
{
    partial class StageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHpPokemon = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelSkill = new System.Windows.Forms.Panel();
            this.skill1 = new System.Windows.Forms.Button();
            this.skill2 = new System.Windows.Forms.Button();
            this.pictureBoxPokemon = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnemy = new System.Windows.Forms.PictureBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.PanelEnemyNameBar = new System.Windows.Forms.Panel();
            this.lblHpenemy = new System.Windows.Forms.Label();
            this.lblenemy = new System.Windows.Forms.Label();
            this.PanelEnemy = new System.Windows.Forms.Panel();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.btnNhac = new System.Windows.Forms.Button();
            this.PanelPokemon = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelSkill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.PanelEnemyNameBar.SuspendLayout();
            this.PanelEnemy.SuspendLayout();
            this.PanelTop.SuspendLayout();
            this.PanelPokemon.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.PanelSkill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 757);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1924, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHpPokemon);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 221);
            this.panel1.TabIndex = 8;
            // 
            // lblHpPokemon
            // 
            this.lblHpPokemon.BackColor = System.Drawing.Color.Transparent;
            this.lblHpPokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHpPokemon.Location = new System.Drawing.Point(440, 64);
            this.lblHpPokemon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHpPokemon.Name = "lblHpPokemon";
            this.lblHpPokemon.Size = new System.Drawing.Size(204, 55);
            this.lblHpPokemon.TabIndex = 8;
            this.lblHpPokemon.Text = "HP: 10/10";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 143);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(637, 55);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(201, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 53);
            this.label1.TabIndex = 7;
            this.label1.Text = "Balbasaur";
            // 
            // PanelSkill
            // 
            this.PanelSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelSkill.Controls.Add(this.skill1);
            this.PanelSkill.Controls.Add(this.skill2);
            this.PanelSkill.Location = new System.Drawing.Point(1228, 20);
            this.PanelSkill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelSkill.Name = "PanelSkill";
            this.PanelSkill.Size = new System.Drawing.Size(692, 220);
            this.PanelSkill.TabIndex = 6;
            // 
            // skill1
            // 
            this.skill1.BackColor = System.Drawing.Color.White;
            this.skill1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skill1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skill1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skill1.Location = new System.Drawing.Point(0, 0);
            this.skill1.Margin = new System.Windows.Forms.Padding(4);
            this.skill1.Name = "skill1";
            this.skill1.Size = new System.Drawing.Size(692, 119);
            this.skill1.TabIndex = 0;
            this.skill1.Text = "Bão Lá";
            this.skill1.UseVisualStyleBackColor = false;
            this.skill1.Click += new System.EventHandler(this.chieu1_Click);
            // 
            // skill2
            // 
            this.skill2.BackColor = System.Drawing.Color.White;
            this.skill2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skill2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skill2.Location = new System.Drawing.Point(0, 119);
            this.skill2.Margin = new System.Windows.Forms.Padding(4);
            this.skill2.Name = "skill2";
            this.skill2.Size = new System.Drawing.Size(692, 101);
            this.skill2.TabIndex = 1;
            this.skill2.Text = "Tấn công nhanh";
            this.skill2.UseVisualStyleBackColor = false;
            this.skill2.Click += new System.EventHandler(this.chieu2_Click);
            // 
            // pictureBoxPokemon
            // 
            this.pictureBoxPokemon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxPokemon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPokemon.Image = global::PokemonProject.Properties.Resources.Bulbasaur;
            this.pictureBoxPokemon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPokemon.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPokemon.Name = "pictureBoxPokemon";
            this.pictureBoxPokemon.Size = new System.Drawing.Size(543, 395);
            this.pictureBoxPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPokemon.TabIndex = 2;
            this.pictureBoxPokemon.TabStop = false;
            // 
            // pictureBoxEnemy
            // 
            this.pictureBoxEnemy.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEnemy.Image = global::PokemonProject.Properties.Resources.charmander;
            this.pictureBoxEnemy.Location = new System.Drawing.Point(0, 119);
            this.pictureBoxEnemy.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxEnemy.Name = "pictureBoxEnemy";
            this.pictureBoxEnemy.Size = new System.Drawing.Size(455, 252);
            this.pictureBoxEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEnemy.TabIndex = 1;
            this.pictureBoxEnemy.TabStop = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar2.Location = new System.Drawing.Point(3, 84);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(448, 36);
            this.progressBar2.TabIndex = 3;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(210, 19);
            this.axWindowsMediaPlayer1.TabIndex = 4;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // PanelEnemyNameBar
            // 
            this.PanelEnemyNameBar.BackColor = System.Drawing.Color.Transparent;
            this.PanelEnemyNameBar.Controls.Add(this.lblHpenemy);
            this.PanelEnemyNameBar.Controls.Add(this.lblenemy);
            this.PanelEnemyNameBar.Controls.Add(this.progressBar2);
            this.PanelEnemyNameBar.Location = new System.Drawing.Point(0, 5);
            this.PanelEnemyNameBar.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEnemyNameBar.Name = "PanelEnemyNameBar";
            this.PanelEnemyNameBar.Size = new System.Drawing.Size(455, 119);
            this.PanelEnemyNameBar.TabIndex = 5;
            // 
            // lblHpenemy
            // 
            this.lblHpenemy.BackColor = System.Drawing.Color.Transparent;
            this.lblHpenemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHpenemy.Location = new System.Drawing.Point(299, 39);
            this.lblHpenemy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHpenemy.Name = "lblHpenemy";
            this.lblHpenemy.Size = new System.Drawing.Size(140, 41);
            this.lblHpenemy.TabIndex = 5;
            this.lblHpenemy.Text = "HP: 10/10";
            // 
            // lblenemy
            // 
            this.lblenemy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblenemy.AutoSize = true;
            this.lblenemy.BackColor = System.Drawing.Color.Transparent;
            this.lblenemy.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblenemy.Location = new System.Drawing.Point(7, 28);
            this.lblenemy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblenemy.Name = "lblenemy";
            this.lblenemy.Size = new System.Drawing.Size(285, 53);
            this.lblenemy.TabIndex = 4;
            this.lblenemy.Text = "Charmander";
            // 
            // PanelEnemy
            // 
            this.PanelEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelEnemy.BackColor = System.Drawing.Color.Transparent;
            this.PanelEnemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelEnemy.Controls.Add(this.pictureBoxEnemy);
            this.PanelEnemy.Controls.Add(this.PanelEnemyNameBar);
            this.PanelEnemy.Location = new System.Drawing.Point(1470, 0);
            this.PanelEnemy.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEnemy.Name = "PanelEnemy";
            this.PanelEnemy.Size = new System.Drawing.Size(455, 372);
            this.PanelEnemy.TabIndex = 6;
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.Transparent;
            this.PanelTop.Controls.Add(this.txtComment);
            this.PanelTop.Controls.Add(this.btnNhac);
            this.PanelTop.Controls.Add(this.PanelEnemy);
            this.PanelTop.Controls.Add(this.axWindowsMediaPlayer1);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(1924, 362);
            this.PanelTop.TabIndex = 7;
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(0, 0);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(524, 354);
            this.txtComment.TabIndex = 8;
            this.txtComment.Text = "Battle Message Box\n";
            // 
            // btnNhac
            // 
            this.btnNhac.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhac.Location = new System.Drawing.Point(533, 0);
            this.btnNhac.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhac.Name = "btnNhac";
            this.btnNhac.Size = new System.Drawing.Size(80, 43);
            this.btnNhac.TabIndex = 6;
            this.btnNhac.Text = "🔊";
            this.btnNhac.UseVisualStyleBackColor = true;
            this.btnNhac.Click += new System.EventHandler(this.btnNhac_Click);
            // 
            // PanelPokemon
            // 
            this.PanelPokemon.BackColor = System.Drawing.Color.Transparent;
            this.PanelPokemon.Controls.Add(this.pictureBoxPokemon);
            this.PanelPokemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPokemon.Location = new System.Drawing.Point(0, 362);
            this.PanelPokemon.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPokemon.Name = "PanelPokemon";
            this.PanelPokemon.Size = new System.Drawing.Size(1924, 395);
            this.PanelPokemon.TabIndex = 8;
            // 
            // StageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.BackgroundImage = global::PokemonProject.Properties.Resources.Fight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.skill1;
            this.ClientSize = new System.Drawing.Size(1924, 1001);
            this.Controls.Add(this.PanelPokemon);
            this.Controls.Add(this.PanelTop);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fight";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fight_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelSkill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.PanelEnemyNameBar.ResumeLayout(false);
            this.PanelEnemyNameBar.PerformLayout();
            this.PanelEnemy.ResumeLayout(false);
            this.PanelTop.ResumeLayout(false);
            this.PanelPokemon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxEnemy;
        private System.Windows.Forms.PictureBox pictureBoxPokemon;
        private System.Windows.Forms.Button skill2;
        private System.Windows.Forms.Button skill1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel PanelSkill;
        private System.Windows.Forms.Panel PanelEnemyNameBar;
        private System.Windows.Forms.Label lblenemy;
        private System.Windows.Forms.Panel PanelEnemy;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelPokemon;
        private System.Windows.Forms.Button btnNhac;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.Label lblHpenemy;
        private System.Windows.Forms.Label lblHpPokemon;
    }
}