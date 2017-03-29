using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GameMessages
{
	public class GameMessage : MessageBase
	{
		public string deviceId;
		public int mouvement;
	}

	public class SystemMessage : MessageBase
	{
		public string deviceId;
		public int clientConnection;
		public int content;
	}

	public class MessageTypes
	{
		public const short ASK_FOR_CONNECTION = 101;
		public const short LINK_ESTABLISHED = 102;
	}
}

