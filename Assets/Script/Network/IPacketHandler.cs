//--------------------------------------------------
// Ellan Game Framework v1.0
// Copyright 2013 Jiang Yin. All rights reserved.
// Feedback: mailto:jiangyin@cyou-inc.com
//--------------------------------------------------

using System;

public interface IPacketHandler
{
	Int32 GetOpcode();
	void Handle(byte[] data, int len);
}
