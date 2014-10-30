using UnityEngine; 
using System.Collections; 
using System; 

public class Node : IComparable {


	public int x;
	public int y;
	public bool walkable;

	public int h;
	public int g;
	public int  f;


	public bool opened,closed;

	public Node parent=null;


	public Node(int _x,int _y){
		x = _x;
		y = _y;
		walkable = true;
	}

	public Node(int _x,int _y,bool _walkable){
		x = _x;
		y = _y;
		walkable = _walkable;
	}

	public int CompareTo(object obj) 
	{ 
		Node node = (Node) obj; 
		//Negative value means object comes before this in the sort order. 
		if (this.f < node.f) {
			return -1; 
		}else  if (this.f > node.f) {
			return 1; 
		}else{
			return 0;
		}
		 
	} 

	public override string ToString() {
		return "x=" + x + " y=" + y + " walkable=" + walkable + " h=" + h + " g=" + g + " f=" + f + " opened=" + opened + " closed=" + closed;
	}

}
