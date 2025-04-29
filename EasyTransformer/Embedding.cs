using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTransformer
{
    class Embedding
    {
        /// <summary>
        /// 获取默认向量
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static double[] GetWordEmbedding(string word)
        {
            // 简单的映射：这里只是为了示例，实际情况下应使用预训练词向量

            switch (word)
            {
                case "我": return new double[] { 0.1, 0.2, 0.3 };
                case "喜欢": return new double[] { 0.6, 0.7, 0.8 };
                case "足球": return new double[] { 0.9, 0.4, 0.3 };
                case "看电影": return new double[] { 0.3, 0.6, 0.2 };
                case "跑步": return new double[] { 0.2, 0.5, 0.7 };
                case "不喜欢": return new double[] { 0.4, 0.2, 0.5 };
                case "编程": return new double[] { 0.8, 0.9, 0.7 };
                case "什么": return new double[] { 0.2, 0.1, 0.3 };
                case "爱": return new double[] { 0.6, 0.7, 0.75 }; // "爱" 的向量与 "喜欢" 非常接近
                default: return new double[] { 0.0, 0.0, 0.0 };
            }
        }

        /// <summary>
        /// 获取句子向量
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static double[] GetSentenceEmbedding(string sentence)
        {
            string[] words = sentence.Split(' ');

            double[][] wordEmbeddings = words.Select(word => GetWordEmbedding(word)).ToArray();

            // 通过自注意力机制来更新每个词的表示
            double[][] updatedEmbeddings = SelfAttention.ApplySelfAttention(wordEmbeddings);

            // 计算句子的加权或平均向量
            double[] sentenceEmbedding = new double[updatedEmbeddings[0].Length];

            // 累加所有词的向量
            foreach (var embedding in updatedEmbeddings)
            {
                for (int i = 0; i < sentenceEmbedding.Length; i++)
                {
                    sentenceEmbedding[i] += embedding[i];
                }
            }

            // 平均化所有词的向量，得到句子级别的向量表示
            for (int i = 0; i < sentenceEmbedding.Length; i++)
            {
                sentenceEmbedding[i] /= updatedEmbeddings.Length;
            }

            return sentenceEmbedding;
        }
    }
}
