using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using pb = global::Google.Protobuf;

public class PacketDistributed
{
	protected int opCode = 0;

	public virtual int CalculateSize() { return 0; }

	public virtual void WriteTo(pb::CodedOutputStream output)  {}

    public byte[] ToByteArray() {
        byte[] byteArray = new byte[CalculateSize()];
        var stream = new pb::CodedOutputStream(byteArray);
        WriteTo(stream);

        return byteArray;
    }
        
    /// <summary>
    /// 默认发送会打开网络等待界面 IsWait 为false，不打开网络等待界面
    /// </summary>
    /// <param name="IsWait">If set to <c>true</c> is wait.</param>
    public void Send(bool IsWait = true)
	{

	}
}
