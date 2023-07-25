using CourseAdoNet.DataAccess.Concrete;
using CourseAdoNet.Entities.Concrete;


var newUser = new User(0,"test2","test2@test.com");

UserDal userDal = new UserDal();
userDal.Add(newUser);


var users = userDal.GetAll();

foreach (var user in users)
    Console.WriteLine(user.UserName);