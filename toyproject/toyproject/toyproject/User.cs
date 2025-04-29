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
                        Console.WriteLine("완료");
                    }
                    else
                    {
                        Console.WriteLine("실패");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("오류 : " + ex.Message);
                }
            }
        }

        public bool ID_Dupl(string id)
        {
            string connectionString = "Server=localhost;Database=minigame;Uid=root;Pwd=12345;Charset=utf8";
            string query = $"SELECT login_id FROM User where login_id = '{id}'";

            strDate = new List<KeyValuePair<string, string>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var login_id = reader.GetString("login_id");

                        if (login_id is null) return true;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("오류 : " + ex.Message);
                }
                return false;
            }
        }
        public bool ID_Check(string id)
        {
            string connectionString = "Server=localhost;Database=minigame;Uid=root;Pwd=12345;Charset=utf8";
            string query = $"SELECT login_id FROM User where login_id = '{id}'";

            strDate = new List<KeyValuePair<string, string>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var login_id = reader.GetString("login_id");

                        if (login_id is not null) return true;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("오류 : " + ex.Message);
                }
                return false;
            }
        }

        public bool PW_Check(string id, string PW)
        {
            string connectionString = "Server=localhost;Database=minigame;Uid=root;Pwd=12345;Charset=utf8";
            string query = $"SELECT login_pw FROM User where login_id = '{id}' and login_pw = '{PW}'";

            strDate = new List<KeyValuePair<string, string>>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var login_pw = reader.GetString("login_pw");

                        if (login_pw is not null) return true;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("오류 : " + ex.Message);
                }
                return false;
            }
        }
    }
}
