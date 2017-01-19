using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    //[DependencyRegister]
    public class BlogsReposity : IBlogsReposity
    {
        public async Task<IEnumerable<MoBlog>> GetBlogs(int nTask)
        {
            var blogs = new List<MoBlog>();

            try
            {
                Task<IEnumerable<MoBlog>>[] tasks = new Task<IEnumerable<MoBlog>>[nTask];
                for (int i=1;i<=tasks.Length;i++)
                {
                    tasks[i - 1] = await Task.Factory.StartNew<Task<IEnumerable<MoBlog>>>((page) =>
                    {
                        return GetBlogsByPage(Convert.ToInt32(page));
                    },i);
                }

                Task.WaitAll(tasks, TimeSpan.FromSeconds(30));
                foreach (var item in tasks.Where(b => b.IsCompleted))
                {
                    blogs.AddRange(item.Result);
                }
            }
            catch(Exception ex)
            {

            }
            return blogs.OrderByDescending(b => b.CreateTime);

        }

        async Task<IEnumerable<MoBlog>> GetBlogsByPage(int nPage)
        {
            var blogs = new List<MoBlog>();
            try
            {
                var strBlogs = string.Empty;
                using(HttpClient cilent=new HttpClient())
                {
                   // strBlogs = await cilent.GetStringAsync("http://www.cnblogs.com/sitehome/p/" + nPage);
                    strBlogs = await cilent.GetStringAsync("http://www.cnblogs.com/cate/108698/" + nPage);
                }
                //
                if (string.IsNullOrWhiteSpace(strBlogs)) { return blogs; }
                var matches = Regex.Matches(strBlogs, "diggnum\"[^>]+>(?<hzan>\\d+)[^:]+(?<burl>http[^\"]+)[^>]+>(?<title>[^<]+)<\\/a>[^=]+=\"+[^>]+>(?<bdes>[^<]+)[^\"]+[^=]+=\"(?<hurl>http[^\"]+)[^>]+>(?<hname>[^<]+)[^2]+(?<bcreatetime>[^<]+)[^\\(]+\\((?<bcomment>\\d+)[^\\(]+\\((?<bread>\\d+)");
               //var matches = Regex.Matches(strBlogs, "diggnum\"[^>]+>(?<hzan>\\d+)[^:]+(?<burl>http[^\"]+)[^>]+>(?<title>[^<]+)<\\/a>[^=]+=[^=]+=\"(?<hurl>http://(\\w|\\.|\\/)+)[^>]+>[^\\/]+\\/\\/(?<hphoto>[^\"]+)[^<]+<\\/a>(?<bdes>[^<]+)[^\"]+[^=]+=[^>]+>(?<hname>[^<]+)[^2]+(?<bcreatetime>[^<]+)[^\\(]+\\((?<bcomment>\\d+)[^\\(]+\\((?<bread>\\d+)");

                if (matches.Count <= 0) { return blogs; }
                foreach (Match item in matches)
                {

                    blogs.Add(new MoBlog
                    {
                        Title = item.Groups["title"].Value.Trim(),
                        NickName = item.Groups["hname"].Value.Trim(),
                        Des = item.Groups["bdes"].Value.Trim(),
                        ZanNum = Convert.ToInt32(item.Groups["hzan"].Value.Trim()),
                        ReadNum = Convert.ToInt32(item.Groups["bread"].Value.Trim()),

                        CommiteNum = Convert.ToInt32(item.Groups["bcomment"].Value.Trim()),
                        CreateTime = Convert.ToDateTime(item.Groups["bcreatetime"].Value.Trim()),
                      ///HeadUrl = "http://" + item.Groups["hphoto"].Value.Trim(),
                        BlogUrl = item.Groups["hurl"].Value.Trim(),
                        Url = item.Groups["burl"].Value.Trim(),
                    });
                }
            }
            catch (Exception ex)
            {

            }
            return blogs;
        }
    
    }
}
