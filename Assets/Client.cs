using System.Collections;
using System.Collections.Generic;
using System.IO;
using Google.Protobuf;
using ProtoBuf;
using UnityEngine;

[ProtoContract]
public class CSLoginInfo
{
    [ProtoMember(1)]
    public string userName;
    [ProtoMember(2)]
    public string password;
}


[ProtoContract]
public class CSLoginReq
{
    [ProtoMember(1)]
    public CSLoginInfo loginINfo;
}

public class Client : MonoBehaviour {

    private void Start()
    {
        //// 反序列化
        //CSLoginReq pReq = PackCodec.Deserialize<CSLoginReq>(File.ReadAllBytes(Application.dataPath + "/test.bytes"));

        //Debug.Log("UserName = " + pReq.loginINfo.userName + ", Password = " + pReq.loginINfo.password);


        RequestLogin reqLogin = new RequestLogin();
        reqLogin.Id = 10000;
        byte[] pbdata = reqLogin.ToByteArray();

        //将字节数据的数据还原到对象中
        RequestLogin p1 = new RequestLogin();
        p1.MergeFrom(pbdata);

        //输出测试
        Debug.Log(p1.Id);
    }

    [ContextMenu("WirteFile")]
    private void WirteFile()
    {
        CSLoginInfo loginInfo = new CSLoginInfo();
        loginInfo.userName = "linshuhe";
        loginInfo.password = "123456";
        CSLoginReq req = new CSLoginReq();
        req.loginINfo = loginInfo;

        //// 序列化
        byte[] pbdata = PackCodec.Serialize(req); 
        WriteFile(pbdata);
    }

    private void WriteFile(byte[] bytes)
    {
        string path = Application.dataPath + "/test.bytes";
        using (var file = File.Create(path))
        {
            file.Write(bytes,0, bytes.Length);
        }
        UnityEditor.AssetDatabase.Refresh();
    }
}
