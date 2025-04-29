using EasyTransformer;

// 假设用户输入
string userInput = "我 喜欢 编程";
string[] userWords = userInput.Split(' ');

// 假设有以下候选内容
string[] candidates = { "我 喜欢 足球", "我 喜欢 看 电影", "我 不喜欢 跑步", "我 爱 编程" };

// 获取用户输入句子的向量表示
double[] userSentenceEmbedding = Embedding.GetSentenceEmbedding(userInput);

// 对候选句子进行向量化并计算与输入句子的相似度
double[] similarities = candidates.Select(candidate =>
{
    double[] candidateSentenceEmbedding = Embedding.GetSentenceEmbedding(candidate);
    return Similar.CosineSimilarity(userSentenceEmbedding, candidateSentenceEmbedding);
}).ToArray();

// 找出最相似的候选句子
int mostSimilarIndex = Array.IndexOf(similarities, similarities.Max());

Console.WriteLine("用户输入：" + userInput);
Console.WriteLine("最相似的句子是：" + candidates[mostSimilarIndex]);
Console.WriteLine("匹配到的句子的向量：" + similarities.Max());