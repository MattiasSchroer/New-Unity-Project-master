using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public bool walkable = true;
	public bool current = false;
	public bool target = false;
	public bool selectable = false;

	public List<Tile> adjacencyList = new List<Tile>();

	//BFS STUFF
	public bool visited = false;
	public Tile parent = null;
	public int distance = 0;

	//A* SHIT
	public float f = 0;
	public float g = 0;
	public float h = 0;

	public int northCover = 0;
	public int eastCover = 0;
	public int southCover = 0;
	public int weastCover = 0;

	public GameObject halfCover;
	public GameObject fullCover;


	GameObject fullNorthCover;
	GameObject fullEastCover;
	GameObject fullSouthCover;
	GameObject fullWeastCover;
	GameObject halfNorthCover;
	GameObject halfEastCover;
	GameObject halfSouthCover;
	GameObject halfWeastCover;



	// Use this for initialization
	void Start () {
		if(northCover == 2){
			GameObject fullNorthCover = Instantiate(fullCover, transform.position + new Vector3(0, 1.5f, 0.5f), Quaternion.Euler(-90f, 90, 0));
			//fullNorthCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(eastCover == 2){
			GameObject fullEastCover = Instantiate(fullCover, transform.position + new Vector3(0.5f, 1.5f, 0), Quaternion.Euler(-90f, 180, 0));
			//fullEastCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(southCover == 2){
			GameObject fullSouthCover = Instantiate(fullCover, transform.position + new Vector3(0, 1.5f, -0.5f), Quaternion.Euler(-90f, 90, 0));
			//fullSouthCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(weastCover == 2){
			GameObject fullWeastCover = Instantiate(fullCover, transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.Euler(-90f, 180, 0));
			//fullWeastCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(northCover == 1){
			GameObject halfNorthCover = Instantiate(halfCover, transform.position + new Vector3(0, 1.5f, 0.5f), Quaternion.Euler(-90f, 90, 0));
			//halfNorthCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(eastCover == 1){
			GameObject halfEastCover = Instantiate(halfCover, transform.position + new Vector3(0.5f, 1.5f, 0), Quaternion.Euler(-90f, 180, 0));
			//halfEastCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(southCover == 1){
			GameObject halfSouthCover = Instantiate(halfCover, transform.position + new Vector3(0, 1.5f, -0.5f), Quaternion.Euler(-90f, 90, 0));
			//halfSouthCover.GetComponent<MeshRenderer>().enabled = false;
		}
		if(weastCover == 1){
			GameObject halfWeastCover = Instantiate(halfCover, transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.Euler(-90f, 180, 0));
			//halfWeastCover.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		

		if(current){
			GetComponent<Renderer>().material.color = Color.magenta;
		}
		else if(target){
			GetComponent<Renderer>().material.color = Color.green;
		}
		else if(selectable){
            Debug.Log("TURN RED!!!!");
			GetComponent<Renderer>().material.color = Color.red;

			// if(northCover == 2){
			// 	Debug.Log("Enabling northcover");
			// 	fullNorthCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(eastCover == 2){
			// 	fullEastCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(southCover == 2){
			// 	fullSouthCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(weastCover == 2){
			// 	fullWeastCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(northCover == 1){
			// 	halfNorthCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(eastCover == 1){
			// 	halfEastCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(southCover == 1){
			// 	halfSouthCover.GetComponent<MeshRenderer>().enabled = true;
			// }
			// if(weastCover == 1){
			// 	halfWeastCover.GetComponent<MeshRenderer>().enabled = true;
			// }
		}
		else{
			GetComponent<Renderer>().material.color = Color.white;
		}
	}

	public void Reset(){
		adjacencyList.Clear();

		walkable = true;
		current = false;
		target = false;
		selectable = false;

		//BFS STUFF
		visited = false;
		parent = null;
		distance = 0;

		f = g = h = 0;
	}

	public void FindNeighbors(float jumpHeight, Tile target){
		Reset();

		CheckTile(Vector3.forward, jumpHeight, target);
		CheckTile(-Vector3.forward, jumpHeight, target);
		CheckTile(Vector3.right, jumpHeight, target);
		CheckTile(-Vector3.right, jumpHeight, target);
	}

	public void CheckTile(Vector3 direction, float jumpHeight, Tile target){
		Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
		Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

		foreach(Collider item in colliders){
			Tile tile = item.GetComponent<Tile>();
			if(tile != null && tile.walkable){
				RaycastHit hit;

				if(!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target)){
					adjacencyList.Add(tile);
				}
			}
		}
	}
}
