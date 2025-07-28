using FamiryEntityLibrary.Service;
using FamiryEntityLibrary;
using Famiry.Data;

namespace Famiry.Service
{

    public class StatusService(DataContext dataContext) : DataEntityService<Status>(dataContext)
    {
    }
}
