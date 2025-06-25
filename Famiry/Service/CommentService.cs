using FamiryEntityLibrary.Service;
using FamiryEntityLibrary;
using Famiry.Data;

namespace Famiry.Service
{

    public class CommentService(DataContext dataContext) : DataEntityService<Comment>(dataContext)
    {
    }
}
