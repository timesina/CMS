using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MoBlog
    {
        /// <summary>
        /// 作者昵称
        /// </summary>
        public string NickName { get; set; } = string.Empty;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        ///该篇文字地址
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; } = string.Empty;

        /// <summary>
        /// 头像图片地址
        /// </summary>
        public string HeadUrl { get; set; } = string.Empty;

        /// <summary>
        /// 博客地址
        /// </summary>
        public string BlogUrl { get; set; } = string.Empty;

        /// <summary>
        /// 点赞次数
        /// </summary>
        public int ZanNum { get; set; } = 0;

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadNum { get; set; } = 0;

        /// <summary>
        /// 评论次数
        /// </summary>
        public int CommiteNum { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Parse("1990-1-1");


    }
}
