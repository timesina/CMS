using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IBlogsReposity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nTask"></param>
        /// <returns></returns>
        Task<IEnumerable<MoBlog>> GetBlogs(int nTask);

    }
}
