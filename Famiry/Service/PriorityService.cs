using FamiryEntityLibrary.Service;
using FamiryEntityLibrary;
using Famiry.Data;

namespace Famiry.Service
{

    public class PriorityService(DataContext dataContext) : DataEntityService<Priority> (dataContext)
    {
    }
}
