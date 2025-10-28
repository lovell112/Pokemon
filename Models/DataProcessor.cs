using PokemonProject.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PokemonProject.Models
{
    namespace DataProcessor
    {
        public static class DataReader
        {
           

            public static List<User> ReadUsersFrom(string path)
            {
                List<User> users = new List<User>();
                try
                {
                    if (File.Exists(path))
                    {
                        string[] lines = File.ReadAllLines(path);
                        foreach (var line in lines)
                        {
                            

                            //SỬA: Đọc toàn bộ nội dung file (chỉ 1 dòng duy nhất sau khi SaveUserData được sửa)
                            if (!string.IsNullOrEmpty(line))
                            {
                                string[] parts = line.Split('|');
                                

                                User user = new User(parts[0]);
                                user.Level[0] = parts[1];
                                user.Level[1] = parts[2];
                                user.Level[2] = parts[3];
                                user.Level[3] = parts[4];
                                Console.WriteLine($"{user.Name} {user.Level[0]} {user.Level[1]} {user.Level[2]} {user.Level[3]}");
                                users.Add(user);
                            }
                        }
                    }
                    return users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc dữ liệu người dùng: {ex.Message}");
                    return null;
                }
            }
        }

        public static class DataWriter
        {
            public static void WriteUsersTo(string path, List<User> users)
            {
                List<string> Lines = new List<string>();
                foreach (var user in users)
                {
                    string line = $"{user.Name}|{user.Level[0]}|{user.Level[1]}|{user.Level[2]}|{user.Level[3]}";
                    Lines.Add(line);
                }

                File.WriteAllLines(path, Lines);
            }
        }
    }
}
