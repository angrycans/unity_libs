using UnityEngine;
using System.Collections;

public class testfindpath : MonoBehaviour {
	/*
	int[,] map={
		{0,0,0,0,0,0,0,2,2,2,2,2,2,0,0},
		{0,0,0,0,0,0,0,2,1,1,1,1,2,0,0},
		{0,0,0,0,0,0,0,2,1,1,1,1,2,0,0},
		{0,2,2,2,2,2,2,2,1,1,1,1,2,0,0},
		{0,2,1,1,1,1,2,2,1,1,1,1,2,0,0},
		{0,2,1,1,1,1,1,1,1,1,1,1,2,0,0},
		{0,2,2,2,2,2,2,2,2,2,2,2,2,0,0}
		
		
	};
	*/

	int[,] map={
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,1,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1},
		{1,1,2,1,1,1,1}

		
		
	};

	Hashtable tiles=new Hashtable();

	// Use this for initialization


	// Use this for initialization
	void Start () {
		/*
		int w = 124;
		
		//Debug.Log ("i= " + map.GetLength (0) + " j=" + map.GetLength (1));
		
		for (int i=0; i<map.GetLength(0); i++){
			for (int j=0;j<map.GetLength(1);j++) {
				GameObject g;
				if (map[i,j]==1){
					g= Instantiate(Resources.Load("Prefab/Tile00")) as GameObject;  

					g.transform.position=new Vector3(124*j,124*(map.GetLength(0)-i),0);
				}else if  (map[i,j]==0){
					g= Instantiate(Resources.Load("Prefab/Tile03")) as GameObject;  
					
					g.transform.position=new Vector3(124*j,124*(map.GetLength(0)-i),0);
				}else {
					g= Instantiate(Resources.Load("Prefab/Tile02")) as GameObject;  
					
					g.transform.position=new Vector3(124*j,124*(map.GetLength(0)-i),0);
				}

				if (g!=null){
					tiles.Add(j+","+i,g);
				}

			}
			//return;
		}

	
*/
		Grid grid=new Grid(map.GetLength(0),map.GetLength(1),map);

		Astarfinder astarfinder = new Astarfinder ();

		ArrayList path= astarfinder.findPath (0, 0, 5, 5, grid);

		foreach( Node node in path ){
			
			Debug.Log("path=["+node.x+","+node.y+"]");

			//((GameObject)tiles[node.x+","+node.y]).GetComponent<tile> ().showPath();

			//((tile)tiles[node.x+","+node.y]).showPath();
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
