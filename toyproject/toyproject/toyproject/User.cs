using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toyproject
{
    internal class User
    {
        public User() { }

        public User(string iD, string password, string email, string name, string phone, string birth, int gender, int age)
        {
            ID = iD;
            Password = password;
            Email = email;
            Name = name;
            Phone = phone;
            Birth = birth;
            Gender = gender;
            Age = age;
        }

        public string ID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Birth {  get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }

        public List<KeyValuePair<string, string>> strDate {  get; set; }
        public List<KeyValuePair<string, int>> intDate {  get; set; }

        public void DB_Add()
        {
            //strDate = new List<KeyValuePair<string, string>>();
            //intDate = new List<KeyValuePair<string, int>>();

            string connectionString = "Server=localhost;Database=minigame;Uid=root;Pwd=12345;Charset=utf8";
            string query = $"INSERT INTO User(login_id, login_pw, user_name, user_phone, user_email, user_gender, user_birth, user_age) VALUES ('{ID}', '{Password}', '{Name}', '{Phone}', '{Email}', {Gender}, '{Birth}', 21)";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("완료", "DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("실패", "DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"DB연결 실패 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
