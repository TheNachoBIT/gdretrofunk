using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjects : MonoBehaviour {

	public static string[] numberChars = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

	[System.Serializable]
	public class Song
	{
		public string nameWav;
		public string nameMp3;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class LevelComplete
	{
		public Vector3 position;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}

	[System.Serializable]
	public class Object
	{
		public Vector3 position;
		public Vector3 scale;
		public Quaternion rotation;
		public float group;
		public int layer;
		public bool IsOnCenter;
		public Vector4 color;
		public int numberOfObject;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class CustomObject1
	{
		public Vector3 position;
		public Vector3 scale;
		public Quaternion rotation;
		public float group;
		public int layer;
		public bool IsOnCenter;
		public Vector4 color;
		public string image;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}

	[System.Serializable]
	public class Spike1
	{
		public Vector3 position;
		public Vector3 scale;
		public Quaternion rotation;
		public float group;
		public int layer;
		public bool IsOnCenter;
		public Vector4 color;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}

	[System.Serializable]
	public class Cameras
	{
		public Vector3 position;
		public Quaternion rotation;
		public float group;
		public bool IsOnCenter;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}

	// triggers
	[System.Serializable]
	public class ColorTriggerJSON
	{
		public Vector3 position;
		public float group;
		public Vector4 color;
		public float seconds;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class MoveTriggerJSON
	{
		public Vector3 position;
		public float group;
		public float seconds;
		public float x;
		public float y;
		public float z;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class RotateTriggerJSON
	{
		public Vector3 position;
		public float group;
		public float groupObject;
		public float seconds;
		public float x;
		public float y;
		public float z;
		public bool rotateInObject;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class ScaleTriggerJSON
	{
		public Vector3 position;
		public float group;
		public float seconds;
		public float x;
		public float y;
		public float z;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class BloomTriggerJSON
	{
		public Vector3 position;
		public float intensity;
		public float threshold;
		public float seconds;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class TVTriggerJSON
	{
		public Vector3 position;
		public float scanLines;
		public float colorDrift;
		public float seconds;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class DisableEnableTriggerJSON
	{
		public Vector3 position;
		public float group;
		public bool disableOrEnable;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class FollowTriggerJSON
	{
		public Vector3 position;
		public float group;
		public float groupToFollow;
		public bool follow;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class StartColorTriggerJSON
	{
		public Vector3 position;
		public float group;
		public Vector4 groupColor;

		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
	[System.Serializable]
	public class KillZone
	{
		public Vector3 position;
		public Vector3 scale;
		public Quaternion rotation;
		public float group;
		public bool IsOnCenter;
		public string getJSON()
		{
			return JsonUtility.ToJson(this);
		}
	}
}
