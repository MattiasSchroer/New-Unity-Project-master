using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuScript {

	//Material material;

	[MenuItem("Tools/Assign Tile Materlial")]
	public static void AssignTileMaterial(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
		Material material = Resources.Load<Material>("Tile");

		foreach(GameObject t in tiles){
			t.GetComponent<Renderer>().material = material;
		}
	}

	[MenuItem("Tools/Assign Tile Script")]
	public static void AssignTileScript(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

		 GameObject fullCover = Resources.Load("fullCover (1)", typeof (GameObject)) as GameObject;
		 GameObject halfCover = Resources.Load("halfCover (1)", typeof (GameObject)) as GameObject;

		foreach(GameObject t in tiles){
			t.AddComponent<Tile>();
			t.GetComponent<Tile>().halfCover = halfCover;
			t.GetComponent<Tile>().fullCover = fullCover;
		}
	}
}
