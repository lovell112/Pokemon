using System.Windows.Forms;

namespace PokemonProject.Models
{
    public class Skill
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _damage;
        public int Damage
        {
            get => _damage;
            set
            {
                if (value <= 0)
                    _damage = 1;
                else 
                    _damage = value;
            }
        }

        private PictureBox _image;
        public PictureBox Image
        {
            get => _image;
            set => _image = value;
        }

        public Skill(string name, int damage, PictureBox image)
        {
            Name = name;
            Damage = damage;
            Image = image;
        }
    }
}