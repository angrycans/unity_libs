using UnityEngine;
using System.Collections;

public class Grid  {

	public int width;
	public int height;
	public Node[,] nodes;

	public Grid(int _w,int _h,int[,] matrix=null){

		//Debug.Log (" grid start");
		width = _w;
		height = _h;
		buildNodes (matrix);
		//Debug.Log (" grid ok");
	}

	public Node getNodeAt (int _x, int _y) {
		return this.nodes[_y,_x];
	}

	public void buildNodes (int[,] matrix=null){
		nodes=new Node[width,height];

		for (int i = 0; i < width; ++i) {

			for (int j = 0; j < height; ++j) {
				nodes[i,j] = new Node(j,i);


			}
		}




		for (int i = 0; i < width; ++i) {
			for (int j = 0; j < height; ++j) {
				if (matrix[i,j]!=1) {
					// 0, false, null will be walkable
					// while others will be un-walkable
					nodes[i,j].walkable = false;
					//setWalkableAt(j,i,false);
				}
			}
		}


	}

	public bool isWalkableAt (int x,int  y) {
		return this.isInside(x, y) && this.nodes[y,x].walkable;
	}


	public bool isInside(int x,int y) {
		return (x >= 0 && x < this.width) && (y >= 0 && y < this.height);
	}


	public void setWalkableAt (int x, int y, bool walkable) {
		this.nodes[y,x].walkable = walkable;
	}


	public ArrayList getNeighbors (Node node, bool allowDiagonal, bool dontCrossCorners) {
		int x = node.x;
		int y = node.y;
		ArrayList neighbors = new ArrayList();
		bool s0 = false;
		bool d0 = false;
		bool s1 = false;
		bool d1 = false;
		bool s2 = false;
		bool d2 = false;
		bool s3 = false; 
		bool d3 = false;

		
		// ↑
		if (this.isWalkableAt(x, y - 1)) {
			neighbors.Add(nodes[y - 1,x]);
			s0 = true;
		}

		// →
		if (this.isWalkableAt(x + 1, y)) {
			neighbors.Add(nodes[y,x + 1]);
			s1 = true;
		}
		// ↓
		if (this.isWalkableAt(x, y + 1)) {
			neighbors.Add(nodes[y + 1,x]);

			s2 = true;
		}
		// ←
		if (this.isWalkableAt(x - 1, y)) {
			neighbors.Add(nodes[y,x - 1]);

			s3 = true;
		}
		
		if (!allowDiagonal) {
			/*
			for (int i=0;i<neighbors.Count;i++){

				
				Debug.Log("neighbors["+i+"]="+((Node)neighbors[i]).x+","+((Node)neighbors[i]).y);
			}

*/

			return neighbors;
		}


		if (dontCrossCorners) {
			d0 = s3 && s0;
			d1 = s0 && s1;
			d2 = s1 && s2;
			d3 = s2 && s3;
		} else {
			d0 = s3 || s0;
			d1 = s0 || s1;
			d2 = s1 || s2;
			d3 = s2 || s3;
		}
		
		// ↖
		if (d0 && this.isWalkableAt(x - 1, y - 1)) {
			neighbors.Add(nodes[y - 1,x - 1]);
		}
		// ↗
		if (d1 && this.isWalkableAt(x + 1, y - 1)) {
			neighbors.Add(nodes[y - 1,x + 1]);
		}
		// ↘
		if (d2 && this.isWalkableAt(x + 1, y + 1)) {
			neighbors.Add(nodes[y + 1,x + 1]);
		}
		// ↙
		if (d3 && this.isWalkableAt(x - 1, y + 1)) {
			neighbors.Add(nodes[y + 1,x - 1]);
		}

		/*
		foreach( Node item in neighbors ){
			
			Debug.Log("neighbors="+item.x+","+item.y);
		}
		*/
		return neighbors;

	}

	public  Grid clone () {

		int width = this.width;
		int height = this.height;
		//Node thisNodes = this.nodes;
		
		Grid newGrid = new Grid(width, height);
		Node[,] newNodes=new Node[width,height];

		
		for (int i = 0; i < height; ++i) {
			for (int  j = 0; j < width; ++j) {
				newNodes[i,j] = new Node(j, i, this.nodes[i,j].walkable);
			}
		}


		newGrid.nodes = newNodes;
		
		return newGrid;
	}


}
