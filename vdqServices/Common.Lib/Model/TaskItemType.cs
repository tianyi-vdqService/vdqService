using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public enum TaskItemType
    {
        /// <summary>
        /// 拉流状态
        /// </summary>
        Stream = 1,

        /// <summary>
        /// 信号状态
        /// </summary>
        Sign = 2,

        /// <summary>
        /// 冻结状态
        /// </summary>
        Frozen = 3,

        /// <summary>
        /// 色彩状态
        /// </summary>
        Color = 4,

        /// <summary>
        /// 雪花噪声状态
        /// </summary>
        Noise = 5,

        /// <summary>
        /// 遮挡状态
        /// </summary>
        Shade = 6,

        /// <summary>
        /// 画面模糊状态
        /// </summary>
        Fuzzy = 7,

        /// <summary>
        /// 画面移位状态
        /// </summary>
        Displaced = 8,

        /// <summary>
        /// 画面彩条状态
        /// </summary>
        Strip = 9,

        /// <summary>
        /// 画面偏色状态
        /// </summary>
        ColorCase = 10,

        /// <summary>
        /// 异常状态
        /// </summary>
        Exception = 11
    }
}
