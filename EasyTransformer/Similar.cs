using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTransformer
{
    /// <summary>
    /// 相似度计算
    /// </summary>
    class Similar
    {
        /// <summary>
        /// 计算两个向量之间的余弦相似度
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static double CosineSimilarity(double[] vec1, double[] vec2)
        {
            double dotProduct = vec1.Zip(vec2, (v1, v2) => v1 * v2).Sum();
            double magnitude1 = Math.Sqrt(vec1.Select(v => v * v).Sum());
            double magnitude2 = Math.Sqrt(vec2.Select(v => v * v).Sum());
            return dotProduct / (magnitude1 * magnitude2);
        }
    }
}
