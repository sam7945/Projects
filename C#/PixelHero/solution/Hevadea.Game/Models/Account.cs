using Hevadea.Database;
using Hevadea.Registry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Models
{
    /// <summary>
    /// Classe seravnt pour l'authentification d'un utilisateur
    /// </summary>
    public class Account
    {
        //Essentiel pour DBContext
        public Account()
        { }
        public Account(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Hash(Password);
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<WorldPlayer> WorldPlayers { get; set; } = new List<WorldPlayer>();

        private string Hash(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashdata = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));

            string builder = "";
            for (int i = 0; i < hashdata.Length; i++)
            {
                builder += hashdata[i].ToString("x2");
            }
            return builder;
        }
       
    }
}
