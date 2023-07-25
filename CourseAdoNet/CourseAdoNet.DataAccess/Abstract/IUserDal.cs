using CourseAdoNet.Entities.Concrete;
using System.Collections.Generic;

namespace CourseAdoNet.DataAccess.Abstract
{
    public interface IUserDal
    {
        List<User> GetAll();
        User Get(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
