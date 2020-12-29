using System.Collections.Generic;
using CarServiceApp_backend.Models;

namespace CarServiceApp_backend.Interfaces
{
    public interface IRepositoryUsers
    {
        bool DoesItemExist(int id);
        public IEnumerable<User> FindPageReponse(int start=0, int quantity=int.MaxValue, string status="");
        IEnumerable<User> All { get; }
        User Find(string id);
        void Insert(User item);
        public string Insert(User.Request item);
        void Update(User item);
        int Quantity {get;}
    }
}