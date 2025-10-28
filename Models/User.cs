using PokemonProject.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PokemonProject.Models
{
    public class User
    {
        #region Constructor
        public User(string name)
        {
            Name = name;
            Level = new List<string>();
            Level.Add("null");
            Level.Add("null");
            Level.Add("null");
            Level.Add("null");
            Man1 = true;
            Man2 = false;
            Man3 = false;
            Manserect = false;
        }
        #endregion

        #region get - set

        private bool _man1;

        public bool Man1
        {   
            get => _man1;
            set => _man1 = value;
        }

        private bool _man2;

        public bool Man2
        {
            get => _man2;
            set => _man2 = value;
        }

        private bool _man3;

        public bool Man3
        {
            get => _man3;
            set => _man3 = value;
        }

        private bool _manserect;

        public bool Manserect
        {
            get => _manserect;
            set => _manserect = value;
        }



        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private List<string> _level;
        public List<string> Level
        {
            get => _level;
            set => _level = value;
        }
        #endregion

    }
}