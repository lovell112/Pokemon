using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonProject.Models;

namespace PokemonProject.Forms
{
    public partial class ScoreboardForm : Form
    {
        private List<User> _players;

        public List<User> Players
        {
            get => _players;
            set => _players = value;
        }
        public ScoreboardForm(List<User> players)
        {
            InitializeComponent();
            Players = players;
            LoadScoreBoard();
        }

        private void LoadScoreBoard()
        {
            lstScoreboard.View = View.Details;
            lstScoreboard.FullRowSelect = true;

            ColumnHeader name = new ColumnHeader();
            name.Text = "User name";
            name.Width = 150;

            ColumnHeader stage1 = new ColumnHeader();
            stage1.Text = "Man 1";
            stage1.Width = 150;
            
            ColumnHeader stage2 = new ColumnHeader();
            stage2.Text = "Man 2";
            stage2.Width = 150;
            
            ColumnHeader stage3 = new ColumnHeader();
            stage3.Text = "Man 3";
            stage3.Width = 150;

            ColumnHeader stage4 = new ColumnHeader();
            stage4.Text = "Man Dac Biet";
            stage4.Width = 150;

            foreach (var player in Players)
            {
                ListViewItem item = new ListViewItem();
                item.Text = player.Name;
                foreach (var lv in player.Level) 
                {
                    if (lv == "null")
                    {
                        item.SubItems.Add("Chua qua man");
                        continue;
                    }

                    item.SubItems.Add(lv);
                }

                lstScoreboard.Items.Add(item);
            }

            lstScoreboard.Columns.Add(name);
            lstScoreboard.Columns.Add(stage1);
            lstScoreboard.Columns.Add(stage2);
            lstScoreboard.Columns.Add(stage3);
            lstScoreboard.Columns.Add(stage4);
        }

    }
}
