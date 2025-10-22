using PokemonProject.Forms;

namespace PokemonProject.Models
{
    public class User
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private int _highestLevelUnlock;
        public int HighestLevelUnlock
        {
            get => _highestLevelUnlock;
            set => _highestLevelUnlock = value;
        }

        private PickStageForm[] _stages;
        public PickStageForm[] Stages
        {
            get => _stages;
            set => _stages = value;
        }
    }
}