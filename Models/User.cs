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
        public User(string name, List<StageForm> initialStages, List<Pokemon> initialPokemons)
        {
            Name = name;
            Stageses = initialStages;
            Pokemons = initialPokemons;
            HighestLevelUnlock = 1;
        }
        #endregion

        #region get - set
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

        private List<StageForm> _stageses;
        public List<StageForm> Stageses
        {
            get => _stageses;
            set => _stageses = value;
        }

        private Pokemon _selectedPokemon;
        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => _selectedPokemon = value;
        }

        private List<Pokemon> _pokemons;

        public List<Pokemon> Pokemons
        {
            get => _pokemons;
            set => _pokemons = value;
        }

        private StageForm _selectedStage;
        public StageForm SelectedStage
        {
            get => _selectedStage;
            set => _selectedStage = value;
        }
        #endregion

        #region Methods
        public void PickPokemon(Pokemon pokemon)
        {
            _selectedPokemon = pokemon;
        }

        public void PickStage(StageForm stage)
        {
            _selectedStage = stage;
            stage.Show();
        }
        #endregion


        private static readonly string UserDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "User_Data.txt"); //đường dẫn thư mục đang chạy chương trình

        #region Lưu tên người dùng hiện tại
        public void SaveUserData()
        {
            try
            {
                // Sử dụng File.WriteAllText để GHI ĐÈ, đảm bảo chỉ lưu trạng thái mới nhất
                string line = $"{Name}|{SelectedPokemon?.Name}|{HighestLevelUnlock}";
                File.WriteAllText(UserDataPath, line);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu người dùng: {ex.Message}");
            }
        }
        #endregion

    }
}