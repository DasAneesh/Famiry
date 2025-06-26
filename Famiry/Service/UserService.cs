using Famiry.Data;
using FamiryEntityLibrary;
using FamiryEntityLibrary.Service;

namespace Famiry.Service
{
    public class UserService(DataContext dataContext) : DataEntityService<User>(dataContext)
    {
    }
}
