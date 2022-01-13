using spotify_clone_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace spotify_clone_backend.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SpotifyContext repositoryContext) : base(repositoryContext)
        {

        }
        public User GetUserWithEmail(string email, string password)
        {
            return FindByCondition(user => user.Email == email && user.Password == password).FirstOrDefault();
        }
    
        public void Save(User user){
            Create(user);
            SaveChanges();
        }

        public IEnumerable<User> GetAllUsers(){
            return FindAll().ToList();
        }
    }
}
