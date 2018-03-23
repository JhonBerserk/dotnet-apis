using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserModel
    {
        /// <summary>
        /// Id Usuário
        /// </summary>
        [Required]
        public int userId { get; set; }
        /// <summary>
        /// Nome Usuário
        /// </summary>
        [Required]
        public string nome { get; set; }
        /// <summary>
        /// E-mail Usuário
        /// </summary>
        [Required]
        public string email { get; set; }
        /// <summary>
        /// Senha Usuário
        /// </summary>
        [Required]
        public string senha { get; set; }

        public UserModel(int userId, string nome, string email, string senha)
        {
            this.userId = userId;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }
    }
}