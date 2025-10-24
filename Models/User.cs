using PokemonProject.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace PokemonProject.Models
{
    public class User
    {
        #region Constructor
        public User(string name, StageForm[] initialStages, Pokemon[] initialPokemons)
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
        #endregion

        #region Methods
        public void PickPokemon(Pokemon pokemon)
        {
            _pokemon = pokemon;
        }

        public void PickStage(PickStageForm stage)
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
                File.WriteAllText(UserDataPath, Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu người dùng: {ex.Message}");
            }
        }
        #endregion

        #region Đọc tên người dùng gần nhất từ file txt
        public static string LoadLastUser()
        {
            try
            {
                if (File.Exists(UserDataPath))
                {
                    string name = File.ReadAllText(UserDataPath).Trim();
                    if (!string.IsNullOrEmpty(name))
                        return name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu người dùng: {ex.Message}");
            }
            return null;
        }
        #endregion

    }
}