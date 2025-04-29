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
                case "我": return new double[] { 0.1, 0.4, -0.2 };
                case "喜欢": return new double[] { 0.2, 0.5, 0.3 };
                case "吃": return new double[] { 0.4, 0.1, 0.6 };
                case "苹果": return new double[] { 0.7, 0.3, 0.2 };
                case "爱": return new double[] { 0.6, 0.4, 0.2 };
                case "中国": return new double[] { 0.8, 0.5, 0.3 };
                case "跳舞": return new double[] { 0.4, 0.6, 0.5 };
                case "你好": return new double[] { 0.3, 0.7, 0.1 };
                case "世界": return new double[] { 0.5, 0.2, 0.4 };
                case "学习": return new double[] { 0.6, 0.3, 0.7 };
                case "编程": return new double[] { 0.2, 0.8, 0.5 };
                case "快乐": return new double[] { 0.7, 0.6, 0.4 };
                case "工作": return new double[] { 0.5, 0.4, 0.3 };
                case "生活": return new double[] { 0.3, 0.5, 0.6 };
                case "朋友": return new double[] { 0.4, 0.7, 0.2 };
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

            double[][] embeddings = words.Select(word => GetWordEmbedding(word)).ToArray();
            double[] sentenceEmbedding = new double[embeddings[0].Length];

            foreach (double[] embedding in embeddings)
            {
                for (int i = 0; i < sentenceEmbedding.Length; i++)
                {
                    sentenceEmbedding[i] += embedding[i];
                }
            }

            for (int i = 0; i < sentenceEmbedding.Length; i++)
            {
                sentenceEmbedding[i] /= embeddings.Length;
            }

            return sentenceEmbedding;
        }
    }
}
