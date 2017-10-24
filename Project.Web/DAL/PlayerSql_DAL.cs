using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Web.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Project.Web.DAL
{
    public class PlayerSql_DAL : IPlayerDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DoomSlayer"].ConnectionString;
        private const string SQL_CreateNewPlayer = "INSERT INTO player VALUES (@name, @life, @gender, @xp, @xpLevel, @gold, @playertype, @imagename);";
        private const string SQL_GetPlayer = "SELECT * FROM player WHERE name = @name;";
        public string CreateNewPlayer(PlayerModel player)
        {
            if(player.Gender == "M")
            {
                if(player.PlayerType == "Human")
                {
                    player.ImageName = "HumanMale.jpg";
                }
                else if(player.PlayerType == "Dwarf")
                {
                    player.ImageName = "DwarfMale.jpg";
                }
                else if(player.PlayerType == "Elf")
                {
                    player.ImageName = "ElfMale.jpg";
                }
                else
                {
                    player.ImageName = "DarkElfMale.jpg";
                }
            }
            else
            {
                if (player.PlayerType == "Human")
                {
                    player.ImageName = "HumanFemale.jpg";
                }
                else if (player.PlayerType == "Dwarf")
                {
                    player.ImageName = "DwarfFemale.png";
                }
                else if (player.PlayerType == "Elf")
                {
                    player.ImageName = "ElfFemale.jpg";
                }
                else
                {
                    player.ImageName = "DarkElfFemale.jpg";
                }
            }
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CreateNewPlayer, conn);
                    cmd.Parameters.AddWithValue("@name", player.Name);
                    cmd.Parameters.AddWithValue("@life", 100);
                    cmd.Parameters.AddWithValue("@gender", player.Gender);
                    cmd.Parameters.AddWithValue("@xp", 0);
                    cmd.Parameters.AddWithValue("@xpLevel", 1);
                    cmd.Parameters.AddWithValue("@gold", 1000);
                    cmd.Parameters.AddWithValue("@playertype", player.PlayerType);
                    cmd.Parameters.AddWithValue("@imagename", player.ImageName);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    string name = player.Name;
                    return name;
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public PlayerModel GetPlayer(string player)
        {
            PlayerModel output = new PlayerModel();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetPlayer, conn);
                    cmd.Parameters.AddWithValue("@name", player);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.PlayerId = Convert.ToInt32(reader["player_id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.Life = Convert.ToInt32(reader["life"]);
                        output.Gender = Convert.ToString(reader["gender"]);
                        output.XP = Convert.ToInt32(reader["xp"]);
                        output.XpLevel = Convert.ToInt32(reader["xpLevel"]);
                        output.Gold = Convert.ToInt32(reader["gold"]);
                        output.PlayerType = Convert.ToString(reader["playertype"]);
                        output.ImageName = Convert.ToString(reader["imageName"]);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;
        }
    }
}