using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private static List<UserModel> listUsers = new List<UserModel>();

        /// <summary>
        /// Cadastra Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna mensagem de sucesso</returns>
        [HttpPost]
        [Route("addUser")]
        public string CadastrarUsuario( UserModel user)
        {
            string retorno = string.Empty;
            if (user != null)
            {
                listUsers.Add(user);
                retorno = "Usuário cadastrado com sucesso!";
            }
            else
            {
                retorno = "ERRO: Usuário Nulo!";
            }

            return retorno;
        }

        /// <summary>
        /// Altera Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna mensagem de sucesso</returns>
        [AcceptVerbs("PUT")]
        [Route("updateUser")]
        public string AlterarUsuario(UserModel user)
        {

            listUsers.Where(n => n.userId == user.userId)
                         .Select(s =>
                         {
                             s.userId = user.userId;
                             s.email = user.email;
                             s.nome = user.nome;
                             s.senha = user.senha;

                             return s;

                         }).ToList();
            return "Usuário alterado com sucesso!";
        }

        /// <summary>
        /// Exclui Usuário
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna mensagem de sucesso</returns>
        [AcceptVerbs("DELETE")]
        [Route("excludeUser/{userId}")]
        public string ExcluirUsuario(int userId)
        {

            UserModel usuario = listUsers.Where(n => n.userId == userId)
                                                .Select(n => n)
                                                .First();

            listUsers.Remove(usuario);

            return "Registro excluido com sucesso!";
        }

        /// <summary>
        /// Consulta Usuário Por Código
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Retorna objeto Usuário</returns>
        [AcceptVerbs("GET")]
        [Route("selectUser/{userId}")]
        public UserModel ConsultarUsuarioPorCodigo(int userId)
        {

            UserModel usuario = listUsers.Where(n => n.userId == userId)
                                                .Select(n => n)
                                                .FirstOrDefault();

            return usuario;
        }

        /// <summary>
        /// Consulta Usuarios
        /// </summary>
        /// <returns> Retorna Lista com Usuários</returns>
        [AcceptVerbs("GET")]
        [Route("getUsers")]
        public List<UserModel> ConsultarUsuarios()
        {
            return listUsers;
        }
    }
}
