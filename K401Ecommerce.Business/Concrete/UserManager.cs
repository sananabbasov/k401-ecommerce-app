using System;
using K401Ecommerce.Business.Abstract;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetUserById(string id)
        {
            var user = _userDal.Get(x => x.Id == id);
            return new SuccessDataResult<User>(user);
        }
    }
}

