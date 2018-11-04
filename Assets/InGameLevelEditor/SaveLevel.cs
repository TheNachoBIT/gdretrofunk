using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveLevel : MonoBehaviour {

	[SerializeField] private GameObject[] allObjects;
	[SerializeField] private GameObject[] allCameras;
	[SerializeField] private GameObject[] allTriggers;

	public class Save {
		public string song;
		public string levelComplete;

		public string objects;
		public string customObject1;

		public string spike1;

		public string cameras;
		//triggers
		public string colorTrigger;
		public string moveTrigger;
		public string rotateTrigger;
		public string scaleTrigger;
		public string bloomTrigger;
		public string tvTrigger;
		public string disableEnableTrigger;
		public string followTrigger;
		public string startColorTrigger;
		public string killZone;

		public string getAllObjects() {
			return
			"\"song\":" + song + "," +
			"\"levelComplete\":" + levelComplete + "," +
			"\"objects\":[" + objects + "],"+
			"\"spike1\":[" + spike1 + "]," +
			"\"customObject1\":[" + customObject1 + "]," +
			"\"cameras\":[" + cameras + "],"+
			"\"colorTrigger\":[" + colorTrigger + "]," +
			"\"moveTrigger\":[" + moveTrigger + "]," +
			"\"rotateTrigger\":[" + rotateTrigger + "]," +
			"\"scaleTrigger\":[" + scaleTrigger + "]," +
			"\"bloomTrigger\":[" + bloomTrigger + "]," +
			"\"tvTrigger\":[" + tvTrigger + "]," +
			"\"disableEnableTrigger\":[" + disableEnableTrigger + "]," +
			"\"followTrigger\":[" + followTrigger + "]," +
			"\"startColorTrigger\":[" + startColorTrigger + "],"+
			"\"killZone\":[" + killZone + "]";
		}
	}

	public bool a;

	private Save saveObjects;

	void Update()
	{
		if (a)
		{
			saveFunction();
			a = false;
		}
	}
	
	public void saveFunction () {
		saveObjects = new Save();

		GetSong songScript = GameObject.Find("GetSong").GetComponent<GetSong>();
		LevelObjects.Song song = new LevelObjects.Song();
		song.nameMp3 = songScript.nameMp3;
		song.nameWav = songScript.nameWav;
		saveObjects.song = song.getJSON();


		GameObject levelComplete = GameObject.Find("LevelCompletedTrigger");
		LevelObjects.LevelComplete complete = new LevelObjects.LevelComplete();
		complete.position = levelComplete.transform.position;
		saveObjects.levelComplete = complete.getJSON();

		allObjects = GameObject.FindGameObjectsWithTag("Objects");
		allCameras = GameObject.FindGameObjectsWithTag("GameCamera");
		allTriggers = GameObject.FindGameObjectsWithTag("Trigger");

		foreach (GameObject m in allObjects)
		{
			if (m.name.Split(LevelObjects.numberChars, StringSplitOptions.None)[0] == "Object")
			{
				Debug.Log(m.name);
				ReturnPositionAfterPlay properties = m.GetComponent<ReturnPositionAfterPlay>();
				ObjectPriorities priorities = m.GetComponent<ObjectPriorities>();
				Color color = m.GetComponent<SpriteRenderer>().color;
				int layer = m.transform.GetComponent<SpriteRenderer>().sortingOrder;
				LevelObjects.Object obj = new LevelObjects.Object();
				obj.position = properties.position;
				obj.scale = properties.scale;
				obj.rotation = properties.rotation;
				obj.group = priorities.group;
				obj.layer = layer;
				obj.IsOnCenter = priorities.isOnCenter;
				obj.color = color;
				obj.numberOfObject = int.Parse(m.name.Split(new string[] {"Object"}, StringSplitOptions.None)[1]);
				if (saveObjects.objects == null)
				{
					saveObjects.objects += obj.getJSON();
				}
				else
				{
					saveObjects.objects += "," + obj.getJSON();
				}
			}
			else if (m.name == "CustomObject1")
			{
				ReturnPositionAfterPlay properties = m.GetComponent<ReturnPositionAfterPlay>();
				ObjectPriorities priorities = m.GetComponent<ObjectPriorities>();
				Color color = m.GetComponent<SpriteRenderer>().color;
				int layer = m.transform.GetComponent<SpriteRenderer>().sortingOrder;
				string image = m.GetComponentInChildren<CustomObject>().nameImage;
				LevelObjects.CustomObject1 obj = new LevelObjects.CustomObject1();
				obj.position = properties.position;
				obj.scale = properties.scale;
				obj.rotation = properties.rotation;
				obj.group = priorities.group;
				obj.layer = layer;
				obj.IsOnCenter = priorities.isOnCenter;
				obj.color = color;
				obj.image = image;
				if (saveObjects.customObject1 == null)
				{
					saveObjects.customObject1 += obj.getJSON();
				}
				else
				{
					saveObjects.customObject1 += "," + obj.getJSON();
				}
			}
			else if (m.name == "Spike1")
			{
				ReturnPositionAfterPlay properties = m.GetComponent<ReturnPositionAfterPlay>();
				ObjectPriorities priorities = m.GetComponent<ObjectPriorities>();
				Color color = m.GetComponent<SpriteRenderer>().color;
				int layer = m.transform.GetComponent<SpriteRenderer>().sortingOrder;
				LevelObjects.Spike1 obj = new LevelObjects.Spike1();
				obj.position = properties.position;
				obj.scale = properties.scale;
				obj.rotation = properties.rotation;
				obj.group = priorities.group;
				obj.layer = layer;
				obj.IsOnCenter = priorities.isOnCenter;
				obj.color = color;
				if (saveObjects.spike1 == null)
				{
					saveObjects.spike1 += obj.getJSON();
				}
				else
				{
					saveObjects.spike1 += "," + obj.getJSON();
				}
			}
		}
		foreach (GameObject m in allCameras)
		{
			ReturnPositionAfterPlay properties = m.GetComponent<ReturnPositionAfterPlay>();
			ObjectPriorities priorities = m.GetComponent<ObjectPriorities>();
			LevelObjects.Cameras obj = new LevelObjects.Cameras();
			obj.position = properties.position;
			obj.rotation = properties.rotation;
			obj.group = priorities.group;
			obj.IsOnCenter = priorities.isOnCenter;
			if (saveObjects.cameras == null)
			{
				saveObjects.cameras += obj.getJSON();
			}
			else
			{
				saveObjects.cameras += "," + obj.getJSON();
			}
		}
		foreach (GameObject m in allTriggers)
		{
			Vector3 position = m.GetComponent<ReturnPositionAfterPlay>().position;
			if (m.name == "ColorTrigger")
			{
				ColorTrigger script = m.GetComponent<ColorTrigger>();
				LevelObjects.ColorTriggerJSON obj = new LevelObjects.ColorTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.seconds = script.seconds;
				obj.color = script.colorFinish * 255;
				if (saveObjects.colorTrigger == null)
				{
					saveObjects.colorTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.colorTrigger += ","+obj.getJSON();
				}
			}
			else if (m.name == "MoveTrigger")
			{
				MoveTrigger script = m.GetComponent<MoveTrigger>();
				LevelObjects.MoveTriggerJSON obj = new LevelObjects.MoveTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.seconds = script.seconds;
				obj.x = script.x;
				obj.y = script.y;
				obj.z = script.z;
				if (saveObjects.moveTrigger == null)
				{
					saveObjects.moveTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.moveTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "RotateTrigger")
			{
				RotateTrigger script = m.GetComponent<RotateTrigger>();
				LevelObjects.RotateTriggerJSON obj = new LevelObjects.RotateTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.groupObject = script.groupObject;
				obj.seconds = script.seconds;
				obj.x = script.x;
				obj.y = script.y;
				obj.z = script.z;
				obj.rotateInObject = script.rotateInObject;
				if (saveObjects.rotateTrigger == null)
				{
					saveObjects.rotateTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.rotateTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "ScaleTrigger")
			{
				ScaleTrigger script = m.GetComponent<ScaleTrigger>();
				LevelObjects.ScaleTriggerJSON obj = new LevelObjects.ScaleTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.seconds = script.seconds;
				obj.x = script.x;
				obj.y = script.y;
				obj.z = script.z;
				if (saveObjects.scaleTrigger == null)
				{
					saveObjects.scaleTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.scaleTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "BloomTrigger")
			{
				BloomTrigger script = m.GetComponent<BloomTrigger>();
				LevelObjects.BloomTriggerJSON obj = new LevelObjects.BloomTriggerJSON();
				obj.position = position;
				obj.intensity = script.intensityGoal;
				obj.threshold = script.thresholdGoal;
				obj.seconds = script.seconds;
				if (saveObjects.bloomTrigger == null)
				{
					saveObjects.bloomTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.bloomTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "TVTrigger")
			{
				TVTrigger script = m.GetComponent<TVTrigger>();
				LevelObjects.TVTriggerJSON obj = new LevelObjects.TVTriggerJSON();
				obj.position = position;
				obj.scanLines = script.scanLinesGoal;
				obj.colorDrift = script.colorDriftGoal;
				obj.seconds = script.seconds;
				if (saveObjects.tvTrigger == null)
				{
					saveObjects.tvTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.tvTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "DisableEnableTrigger")
			{
				DisableEnableTrigger script = m.GetComponent<DisableEnableTrigger>();
				LevelObjects.DisableEnableTriggerJSON obj = new LevelObjects.DisableEnableTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.disableOrEnable = script.disableOrEnable;
				if (saveObjects.disableEnableTrigger == null)
				{
					saveObjects.disableEnableTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.disableEnableTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "FollowTrigger")
			{
				FollowTrigger script = m.GetComponent<FollowTrigger>();
				LevelObjects.FollowTriggerJSON obj = new LevelObjects.FollowTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.groupToFollow = script.groupToFollow;
				obj.follow = script.follow;
				if (saveObjects.followTrigger == null)
				{
					saveObjects.followTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.followTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "StartColorTrigger")
			{
				StartColor script = m.GetComponent<StartColor>();
				LevelObjects.StartColorTriggerJSON obj = new LevelObjects.StartColorTriggerJSON();
				obj.position = position;
				obj.group = script.group;
				obj.groupColor = script.groupColor;
				if (saveObjects.startColorTrigger == null)
				{
					saveObjects.startColorTrigger += obj.getJSON();
				}
				else
				{
					saveObjects.startColorTrigger += "," + obj.getJSON();
				}
			}
			else if (m.name == "KillZone")
			{
				ReturnPositionAfterPlay properties = m.GetComponent<ReturnPositionAfterPlay>();
				ObjectPriorities priorities = m.GetComponent<ObjectPriorities>();
				LevelObjects.KillZone obj = new LevelObjects.KillZone();
				obj.position = properties.position;
				obj.scale = properties.scale;
				obj.rotation = properties.rotation;
				obj.group = priorities.group;
				obj.IsOnCenter = priorities.isOnCenter;
				if (saveObjects.killZone == null)
				{
					saveObjects.killZone += obj.getJSON();
				}
				else
				{
					saveObjects.killZone += "," + obj.getJSON();
				}
			}
		}
		ResourcesManager path = gameObject.GetComponent<ResourcesManager>();
		string json = "{" +
			saveObjects.getAllObjects()
		+ "}";
		string jsonPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + path.levelName + "/" + path.levelName + ".json";
		File.WriteAllText(jsonPath, json);
	}
}
