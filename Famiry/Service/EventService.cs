using Famiry.Data;
using FamiryEntityLibrary;
using FamiryEntityLibrary.Service;

namespace Famiry.Service
{
    public class EventService(DataContext dataContext): DataEntityService<Event>(dataContext)
    {
    }
}
