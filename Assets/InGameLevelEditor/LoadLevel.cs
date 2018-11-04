using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadLevel : MonoBehaviour {

	public GameObject[] objects;
	public GameObject CustomObject1;
	public GameObject Spike1;
	public GameObject ColorTrigger;
	public GameObject MoveTrigger;
	public GameObject RotateTrigger;
	public GameObject ScaleTrigger;
	public GameObject BloomTrigger;
	public GameObject TVTrigger;
	public GameObject DisableEnableTrigger;
	public GameObject FollowTrigger;
	public GameObject StartColorTrigger;
	public GameObject KillZone;

	private ResourcesManager rM;

	[Serializable]
	public class level {
		public LevelObjects.Song song;
		public LevelObjects.LevelComplete levelComplete;
		public List<LevelObjects.Object> objects;
		public List<LevelObjects.CustomObject1> customObject1;
		public List<LevelObjects.Spike1> spike1;
		public List<LevelObjects.Cameras> cameras;
		public List<LevelObjects.ColorTriggerJSON> colorTrigger;
		public List<LevelObjects.MoveTriggerJSON> moveTrigger;
		public List<LevelObjects.RotateTriggerJSON> rotateTrigger;
		public List<LevelObjects.ScaleTriggerJSON> scaleTrigger;
		public List<LevelObjects.BloomTriggerJSON> bloomTrigger;
		public List<LevelObjects.TVTriggerJSON> tvTrigger;
		public List<LevelObjects.DisableEnableTriggerJSON> disableEnableTrigger;
		public List<LevelObjects.FollowTriggerJSON> followTrigger;
		public List<LevelObjects.StartColorTriggerJSON> startColorTrigger;
		public List<LevelObjects.KillZone> killZone;
	}

	void Awake () {
		string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + gameObject.GetComponent<ResourcesManager>().levelName + "/" + gameObject.GetComponent<ResourcesManager>().levelName + ".json";
		level lvlObj  = JsonUtility.FromJson<level>(File.ReadAllText(path));
		rM = GameObject.Find("ResourcesManager").GetComponent<ResourcesManager>();

		if (lvlObj.song.nameMp3 != null && lvlObj.song.nameWav != null)
		{
			GetSong songScript = GameObject.Find("GetSong").GetComponent<GetSong>();
			songScript.nameMp3 = lvlObj.song.nameMp3;
			songScript.nameWav = lvlObj.song.nameWav;
			songScript.StartDownload();
		}

		GameObject complete = GameObject.Find("LevelCompletedTrigger");
		if (lvlObj.levelComplete.position == new Vector3(0, 0, 0))
		{
			complete.transform.position = new Vector3(40, 15, 0);
		}
		else
		{
			complete.transform.position = lvlObj.levelComplete.position;
		}

		foreach (LevelObjects.Object m in lvlObj.objects)
		{
			GameObject p = Instantiate(objects[m.numberOfObject-1]) as GameObject;
			p.name = "Object" + m.numberOfObject;
			p.transform.position = m.position;
			p.transform.localScale = m.scale;
			p.transform.rotation = m.rotation;
			p.GetComponent<ObjectPriorities>().group = m.group;
			p.GetComponent<SpriteRenderer>().sortingOrder = m.layer;
			p.GetComponent<ObjectPriorities>().isOnCenter = m.IsOnCenter;
			p.GetComponent<SpriteRenderer>().color = m.color;
		}
		foreach (LevelObjects.CustomObject1 m in lvlObj.customObject1)
		{
			GameObject p = Instantiate(CustomObject1) as GameObject;
			p.name = "CustomObject1";
			p.transform.position = m.position;
			p.transform.localScale = m.scale;
			p.transform.rotation = m.rotation;
			p.GetComponent<ObjectPriorities>().group = m.group;
			p.GetComponent<SpriteRenderer>().sortingOrder = m.layer;
			p.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = m.layer;
			p.GetComponent<ObjectPriorities>().isOnCenter = m.IsOnCenter;
			p.GetComponent<SpriteRenderer>().color = m.color;
			p.GetComponentInChildren<CustomObject>().nameImage = m.image;
			StartCoroutine(p.GetComponentInChildren<CustomObject>().DownloadImage(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Geometry Dash RetroFunk/Created Levels/" + rM.levelName + "/Sprites/" + m.image));
		}
		foreach (LevelObjects.Spike1 m in lvlObj.spike1)
		{
			GameObject p = Instantiate(Spike1) as GameObject;
			p.name = "Spike1";
			p.transform.position = m.position;
			p.transform.localScale = m.scale;
			p.transform.rotation = m.rotation;
			p.GetComponent<ObjectPriorities>().group = m.group;
			p.GetComponent<SpriteRenderer>().sortingOrder = m.layer;
			p.GetComponent<ObjectPriorities>().isOnCenter = m.IsOnCenter;
			p.GetComponent<SpriteRenderer>().color = m.color;
		}
		foreach (LevelObjects.Cameras m in lvlObj.cameras)
		{
			GameObject c = GameObject.FindGameObjectWithTag("GameCamera");
			c.transform.position = m.position;
			c.transform.rotation = m.rotation;
			c.GetComponent<ObjectPriorities>().group = m.group;
			c.GetComponent<ObjectPriorities>().isOnCenter = m.IsOnCenter;
		}
		foreach (LevelObjects.ColorTriggerJSON m in lvlObj.colorTrigger)
		{
			GameObject p = Instantiate(ColorTrigger) as GameObject;
			p.name = "ColorTrigger";
			ColorTrigger script = p.GetComponent<ColorTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.seconds = m.seconds;
			script.r = m.color.x;
			script.b = m.color.z;
			script.g = m.color.y;
			script.a = m.color.w;
		}
		foreach (LevelObjects.MoveTriggerJSON m in lvlObj.moveTrigger)
		{
			GameObject p = Instantiate(MoveTrigger) as GameObject;
			p.name = "MoveTrigger";
			MoveTrigger script = p.GetComponent<MoveTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.seconds = m.seconds;
			script.x = m.x;
			script.y = m.y;
			script.z = m.z;
		}
		foreach (LevelObjects.RotateTriggerJSON m in lvlObj.rotateTrigger)
		{
			GameObject p = Instantiate(RotateTrigger) as GameObject;
			p.name = "RotateTrigger";
			RotateTrigger script = p.GetComponent<RotateTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.groupObject = m.groupObject;
			script.seconds = m.seconds;
			script.x = m.x;
			script.y = m.y;
			script.z = m.z;
			script.rotateInObject = m.rotateInObject;
		}
		foreach (LevelObjects.ScaleTriggerJSON m in lvlObj.scaleTrigger)
		{
			GameObject p = Instantiate(ScaleTrigger) as GameObject;
			p.name = "ScaleTrigger";
			ScaleTrigger script = p.GetComponent<ScaleTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.seconds = m.seconds;
			script.x = m.x;
			script.y = m.y;
			script.z = m.z;
		}
		foreach (LevelObjects.BloomTriggerJSON m in lvlObj.bloomTrigger)
		{
			GameObject p = Instantiate(BloomTrigger) as GameObject;
			p.name = "BloomTrigger";
			BloomTrigger script = p.GetComponent<BloomTrigger>();
			p.transform.position = m.position;
			script.seconds = m.seconds;
			script.intensityGoal = m.intensity;
			script.thresholdGoal = m.threshold;
		}
		foreach (LevelObjects.TVTriggerJSON m in lvlObj.tvTrigger)
		{
			GameObject p = Instantiate(TVTrigger) as GameObject;
			p.name = "TVTrigger";
			TVTrigger script = p.GetComponent<TVTrigger>();
			p.transform.position = m.position;
			script.seconds = m.seconds;
			script.colorDriftGoal = m.colorDrift;
			script.scanLinesGoal = m.scanLines;
		}
		foreach (LevelObjects.DisableEnableTriggerJSON m in lvlObj.disableEnableTrigger)
		{
			GameObject p = Instantiate(DisableEnableTrigger) as GameObject;
			p.name = "DisableEnableTrigger";
			DisableEnableTrigger script = p.GetComponent<DisableEnableTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.disableOrEnable = m.disableOrEnable;
		}
		foreach (LevelObjects.FollowTriggerJSON m in lvlObj.followTrigger)
		{
			GameObject p = Instantiate(FollowTrigger) as GameObject;
			p.name = "FollowTrigger";
			FollowTrigger script = p.GetComponent<FollowTrigger>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.groupToFollow = m.groupToFollow;
			script.follow = m.follow;
		}
		foreach (LevelObjects.StartColorTriggerJSON m in lvlObj.startColorTrigger)
		{
			GameObject p = Instantiate(StartColorTrigger) as GameObject;
			p.name = "StartColorTrigger";
			StartColor script = p.GetComponent<StartColor>();
			p.transform.position = m.position;
			p.GetComponent<ObjectPriorities>().group = m.group;
			script.group = m.group;
			script.groupColor = m.groupColor;
		}
		foreach (LevelObjects.KillZone m in lvlObj.killZone)
		{
			GameObject p = Instantiate(KillZone) as GameObject;
			p.name = "KillZone";
			p.transform.position = m.position;
			p.transform.localScale = m.scale;
			p.transform.rotation = m.rotation;
			p.GetComponent<ObjectPriorities>().group = m.group;
			p.GetComponent<ObjectPriorities>().isOnCenter = m.IsOnCenter;
		}
	}
}
