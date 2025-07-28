using FamiryEntityLibrary.Service;
using FamiryEntityLibrary;
using Famiry.Data;

namespace Famiry.Service
{

    public class TypeService(DataContext dataContext) : DataEntityService<FamiryEntityLibrary.Type>(dataContext)
    {
    }
}
