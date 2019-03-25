using System.IO;
using ProtoBuf;

/// <summary>
/// 网络协议数据打包和解包类
/// </summary>
public class PackCodec
{
    /// <summary>
    /// 序列化
    /// </summary>
    public static byte[] Serialize<T>(T msg)
    {
        byte[] result = null;
        if (!msg.Equals(default(T)))
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, msg);
                result = stream.ToArray();
            }
        }
        return result;
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    public static T Deserialize<T>(byte[] message)
    {
        T result = default(T);
        if (null != message)
        {
            using (var stream = new MemoryStream(message))
            {
                result = Serializer.Deserialize<T>(stream);
            }
        }
        return result;
    }
}
