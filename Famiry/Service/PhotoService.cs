using FamiryEntityLibrary.Service;
using FamiryEntityLibrary;
using Famiry.Data;

namespace Famiry.Service
{

    public class PhotoService(DataContext dataContext) : DataEntityService<Photo>(dataContext)
    {
    }
}
