using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQQLib.Model
{
   public class RecvMsg
    {
        /// <summary>
        /// 消息类型，message好友消息 group_message群消息 discu_message讨论组消息
        /// </summary>
        public string poll_type { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }
    }
}
