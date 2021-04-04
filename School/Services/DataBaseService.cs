using School.Contracts;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Services
{/// <summary>
/// Aqui implemento a interface
/// </summary>
    public class DataBaseService : IDataBase
    {
        #region Ctor
        public DataBaseService()
        {
            this.UserList = new List<User>();
        }
        #endregion

        #region Propriedades instanciadas

        public List<User> UserList { get; set; }

        #endregion

        #region Propriedade privada

        private int auxId = 0;

        #endregion

        #region Public Metods
        public List<User> GetAll()
        {
            return this.UserList;
        }

        public User GetById(int UserId)
        {
            return this.UserList.Where(User => User.IdUser == UserId).FirstOrDefault();
            ///Linq permite filtrar a lista, uso a cláusula de filtro where e trago por padrão o primeiro.
        }

        public void InsertUser(User User)
        {
            User.IdUser = auxId++;
            this.UserList.Add(User);
        }

        public bool RemoveUser(int UserId)
        {
            var user = this.UserList.Where(User => User.IdUser == UserId);

            if (user.Count() > 0 )
            {
                this.UserList.Remove(user.FirstOrDefault());
                return true;
            }
            return false;
        }

        public User UpdateUser(User User)
        {
            var user = this.UserList.Where(user => user.IdUser == User.IdUser);

            if (user.Count() > 0)
            {
                this.UserList.FirstOrDefault().IdUser = User.IdUser;
                this.UserList.FirstOrDefault().Name = User.Name;
                this.UserList.FirstOrDefault().BirthdayDate = User.BirthdayDate;
                this.UserList.FirstOrDefault().RoleList = User.RoleList;

                return User;
            }
            return null;
        }
        #endregion


        
    }
}