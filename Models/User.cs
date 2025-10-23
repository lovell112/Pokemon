using PokemonProject.Forms;

namespace PokemonProject.Models
{
    public class User
    {
        //Constructor
        public User(string name, StageForm[] initialStages, Pokemon[] initialPokemons)
        {
            Name = name;
            Stageses = initialStages;
            Pokemons = initialPokemons;
            HighestLevelUnlock = 1;
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

        private StageForm[] _stageses;
        public StageForm[] Stageses
        {
            get => _stageses;
            set => _stageses = value;
        }

        private Pokemon _pokemon;
        public Pokemon Pokemon
        {
            get => _pokemon;
            set => _pokemon = value;
        }

        private Pokemon[] _pokemons;

        public Pokemon[] Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
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