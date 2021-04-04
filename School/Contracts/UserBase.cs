using School.Models;
using System;
using System.Collections.Generic;

namespace School.Contracts
{
    /// <summary>
    /// Classe abstrata modelo para o cadastrado (classe base)
    /// </summary>
    public abstract class UserBase
    {
        #region Propriedades

        ///region serve para organizar partes do código
        /// <summary>
        ///usar o prop tab tab para autocomplementar
        ///serve para criar o modelo de dados
        /// </summary>

        public int IdUser { get; set; }
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public List<Role> RoleList { get; set; }

        #endregion
    }
}
