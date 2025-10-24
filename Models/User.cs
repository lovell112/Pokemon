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
                // 🎯 SỬA: Sử dụng File.WriteAllText để GHI ĐÈ, đảm bảo chỉ lưu trạng thái mới nhất
                string line = $"{Name}|{Pokemon?.Name}|{HighestLevelUnlock}";
                File.WriteAllText(UserDataPath, line);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu người dùng: {ex.Message}");
            }
        }
        #endregion

        #region Đọc tên người dùng gần nhất từ file txt
        public static User LoadLastUser(Pokemon[] availablePokemons, StageForm[] availableStages)
        {
            try
            {
                if (File.Exists(UserDataPath))
                {
                    // 🎯 SỬA: Đọc toàn bộ nội dung file (chỉ 1 dòng duy nhất sau khi SaveUserData được sửa)
                    string line = File.ReadAllText(UserDataPath).Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            string pokemonName = parts[1];
                            int stage = int.Parse(parts[2]);

                            User user = new User(name, availableStages, availablePokemons);
                            user.HighestLevelUnlock = stage;

                            // ... (Giữ nguyên logic gán Pokemon)
                            if (!string.IsNullOrEmpty(pokemonName))
                            {
                                user.Pokemon = availablePokemons.FirstOrDefault(p => p.Name == pokemonName);
                            }

                            return user;
                        }
                    }
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