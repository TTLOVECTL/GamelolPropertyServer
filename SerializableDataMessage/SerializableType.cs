using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableDataMessage
{
    public enum SerializableType
    {
        /// <summary>
        /// 身份验证
        /// </summary>
        AUTHENTICATION_TYPE,
        
        /// <summary>
        /// 转发道具商城仓库服务器
        /// </summary>
        PROPETRY_TYPE,

        /// <summary>
        /// 转发社交服务器
        /// </summary>
        SOCIAL_TYPE
    }
}
