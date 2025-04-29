using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTransformer
{
    /// <summary>
    /// 前馈网络
    /// </summary>
    class FeedForwardNetwork
    {
        public static double[] FeedForward(double[] input)
        {
            // ReLU激活函数
            return input.Select(a => Math.Max(0, a)).ToArray();
        }

    }
}
