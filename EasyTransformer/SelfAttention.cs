namespace EasyTransformer
{
    /// <summary>
    /// 自注意力机制
    /// </summary>
    class SelfAttention
    {
        public static double[][] ApplySelfAttention(double[][] wordEmbeddings)
        {
            int length = wordEmbeddings.Length;
            double[][] updatedEmbeddings = new double[length][];

            for (int i = 0; i < length; i++)
            {
                double[] query = wordEmbeddings[i];
                double[][] keys = wordEmbeddings;
                double[][] values = wordEmbeddings;

                // 计算注意力输出
                double[] attentionOutput = Attention(query, keys, values);
                updatedEmbeddings[i] = attentionOutput;
            }
            return updatedEmbeddings;
        }

        /// <summary>
        /// 注意力机制
        /// </summary>
        /// <param name="query">用于表示当前需要关注的内容</param>
        /// <param name="keys">用于与查询进行匹配的表示</param>
        /// <param name="values">在匹配时提供与查询相关的实际信息</param>
        /// <returns></returns>
        public static double[] Attention(double[] query, double[][] keys, double[][] values)
        {
            // 计算向量内积
            double[] scores = keys.Select(key => query.Zip(key, (q, k) => q * k).Sum()).ToArray();
            // 内积的相似度归一化
            double[] attentionWeights = Softmax(scores);
            // 加权求和运算
            double[] result = values.Select((value, i) => value.Zip(attentionWeights, (v, w) => v * w).Sum()).ToArray();

            return result;
        }

        /// <summary>
        /// 归一化指数函数
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double[] Softmax(double[] x)
        {
            double max = x.Max(); // 计算时减去最大值，防止溢出
            double sum = x.Select(v => Math.Exp(v - max)).Sum(); // 分母
            return x.Select(v => Math.Exp(v - max) / sum).ToArray(); // 归一化计算每个值的分布概率
        }
    }
}
