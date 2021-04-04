using School.Models;
using System.Collections.Generic;

namespace School.Contracts
{
    /// <summary>
    /// interfaces não possuem implementação (não tem corpo)
    /// </summary>
    public interface IDataBase
    {
        public void InsertUser(User User);
        public bool RemoveUser(int UserId);
        public User UpdateUser(User User);
        public List<User> GetAll();
        public User GetById(int UserId);
    }
}
