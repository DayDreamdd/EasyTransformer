using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTransformer
{
    public class EncoderLayer
    {
        public static double[][] ApplyEncoderLayer(double[][] wordEmbeddings)
        {
            // 假设使用两个编码器层
            int numLayers = 2;
            double[][] embeddings = wordEmbeddings;

            for (int layer = 0; layer < numLayers; layer++)
            {
                embeddings = embeddings.Select(wordEmbedding => Encoder(wordEmbedding)).ToArray();
            }

            return embeddings;
        }

        public static double[] Encoder(double[] input)
        {
            // 自注意力机制
            double[] attentionOutput = SelfAttention.Attention(input, input.Select(a => new double[] { a }).ToArray(), input.Select(a => new double[] { a }).ToArray());

            // 残差连接
            double[] layer1Output = attentionOutput.Select((a, i) => a + input[i]).ToArray();

            // 前馈网络 残差连接后可能有负数，需要ReLU激活函数处理
            double[] feedForwardOutput = FeedForwardNetwork.FeedForward(layer1Output);

            // 残差连接
            return feedForwardOutput.Select((a, b) => a + layer1Output[b]).ToArray();
        }
    }
}
