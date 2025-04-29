using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTransformer
{
    class Position
    {
        /// <summary>
        /// 位置编码
        /// </summary>
        /// <param name="position">位置</param>
        /// <param name="dimension">维度</param>
        /// <returns></returns>
        public static double[] PositionEncoding(int position, int dimension = 3)
        {
            double[] encoding = new double[dimension];
            for (int i = 0; i < dimension; i += 2)
            {
                // 偶数维度的正弦函数
                encoding[i] = Math.Sin(position / Math.Pow(10000, (2 * i) / (double)dimension));
                if (i + 1 < dimension)
                {
                    // 奇数维度的余弦函数
                    encoding[i + 1] = Math.Cos(position / Math.Pow(10000, (2 * (i + 1)) / (double)dimension));
                }
            }
            return encoding;

        }
    }
}
