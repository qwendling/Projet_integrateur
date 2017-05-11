using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GameMessages
{
	public class DataMessage : MessageBase
	{
		public string deviceId;
		public int mouvement;
	}

	public class SystemMessage : MessageBase
	{
		public string deviceId;
		public int clientConnection;
		public string clientIpAddress;
		public int content;

	}

	public class MessageTypes
	{
		public const short ASK_FOR_CONNECTION = 101;
		public const short LINK_ESTABLISHED = 102;
		public const short ACK_LINK_ESTABLISHED = 103;
	}
}
