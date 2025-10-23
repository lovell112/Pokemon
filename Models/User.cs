using PokemonProject.Forms;

namespace PokemonProject.Models
{
    public class User
    {
        //Constructor
        public User(string name, PickStageForm initialStage)
        {
            _name = name;
            _selectedStage = initialStage;
            _highestLevelUnlock = 1;
        }

        //get - set
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

        private Pokemon _pokemon;
        public Pokemon Pokemon
        {
            get => _pokemon;
            set => _pokemon = value;
        }

        private PickStageForm _selectedStage;
        public PickStageForm SelectedStage
        {
            get => _selectedStage;
            set => _selectedStage = value;
        }

        // Methods
        public void PickPokemon(Pokemon pokemon)
        {
            _pokemon = pokemon;
        }

        public void PickStage(PickStageForm stage)
        {
            _selectedStage = stage;
            stage.Show();
        }
    }
}