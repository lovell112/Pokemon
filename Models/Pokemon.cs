using PokemonProject.Models;
using PokemonProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PokemonProject.Models
{
    public class Pokemon
    {
        private string _Name;
        private PictureBox _Image;
        private double _HP;
        private Systems _System;

        public Skill Skill1 { get; set; }
        public Skill Skill2 { get; set; }
        public Skill Skill3 { get; set; }
        public Skill Skill4 { get; set; }


        public Pokemon(string name, PictureBox image, double hp, Systems system, Skill skill1, Skill skill2, Skill skill3, Skill skill4)
        {
            _Name = name;
            _Image = image;
            _HP = hp;
            _System = system;
            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public PictureBox Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        public double HP
        {
            get { return _HP; }
            set { _HP = value; }
        }
        public Systems System
        {
            get { return _System; }
            set { _System = value; }
        }

        public void Attack(Pokemon target)
        {
            double damage = Skill1.Damage;
            if (IsCounter(target))
            {
                damage *= 2;
            }
            else if (target.IsCounter(this))
            {
                damage *= 0.5;
            }

            target.HP -= damage;
            if (target.HP < 0) target.HP = 0;
        }

        public bool IsCounter(Pokemon target)
        {
            if (System == Systems.Water && target.System == Systems.Fire) return true;
            if (System == Systems.Fire && target.System == Systems.Grass) return true;
            if (System == Systems.Grass && target.System == Systems.Water) return true;
            if (System == Systems.Thunder && target.System == Systems.Water) return true;
            return false;
        }
    }
}