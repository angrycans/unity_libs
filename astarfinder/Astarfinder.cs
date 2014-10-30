using UnityEngine;
using System.Collections;

public class Astarfinder  {

	bool allowDiagonal=false ;
	bool dontCrossCorners =false;
	//this.heuristic = opt.heuristic || Heuristic.manhattan;
	int weight =  1;

	public Astarfinder(bool _allowDiagonal=false,bool _dontCrossCorners=false){
		allowDiagonal = _allowDiagonal;
		dontCrossCorners = _dontCrossCorners;
	}




	public ArrayList findPath (int startX, int startY, int endX, int endY,Grid grid) {

		Heap openList = new Heap ();

		Node startNode = grid.getNodeAt (startX, startY);
		Node endNode = grid.getNodeAt (endX, endY);
	//	heuristic = this.heuristic;
		//allowDiagonal = this.allowDiagonal;
		//dontCrossCorners = this.dontCrossCorners;
		//weight = this.weight;
		//abs = Math.abs; 
		float SQRT2 = 1.4142135623730951f;
		//Mathf.Sqrt2;
	


		//node, neighbors, neighbor, i, l, x, y, ng;
		Node node;

		startNode.g = 0;
		startNode.f = 0;
		openList.push(startNode);
		startNode.opened = true;



		while (!openList.empty()) {

		
			// pop the position of node which has the minimum `f` value.
			node = openList.pop();
			node.closed = true;
			//Debug.Log (" node =["+ node.x+","+node.y+"]");
			// if reached the end position, construct the path and return it
			if (node.x == endNode.x&&node.y==endNode.y) {
				return backtrace(endNode);
			}


			ArrayList neighbors = grid.getNeighbors(node, allowDiagonal, dontCrossCorners);


			//return null;
			//int  l = neighbors.Count;

			for (int i = 0; i < neighbors.Count; ++i) {
				Node neighbor = (Node)neighbors[i];

				if (neighbor.closed) {
					continue;
				}
				
				int x = neighbor.x;
				int y = neighbor.y;
				
				// get the distance between current node and the neighbor
				// and calculate the next g score
				int ng = node.g + 1;

		
				
				// check if the neighbor has not been inspected yet, or
				// can be reached with smaller cost from the current node
				if (!neighbor.opened || ng < neighbor.g) {
					neighbor.g = ng;
					neighbor.h = weight * manhattan(Mathf.Abs (x - endX), Mathf.Abs(y - endY));
					neighbor.f = neighbor.g + neighbor.h;
					neighbor.parent = node;

				
					
					if (!neighbor.opened) {
						openList.push(neighbor);
						neighbor.opened = true;

						          
					} else {
						// the neighbor can be reached with smaller cost.
						// Since its f value has been updated, we have to
						// update its position in the open list
						openList.updateItem(neighbor);

					}
				}
			} // end for each neighbor

		}




	
	// fail to find the path
		return new ArrayList();

	}


	int manhattan(int dx,int  dy) {
		return dx + dy;
	}


	ArrayList backtrace(Node _node) {
		ArrayList path = new ArrayList ();
		//[[node.x, node.y]];
		path.Add (_node);
		while (_node.parent!=null) {
			_node = _node.parent;
			path.Add(_node);

		}

		path.Reverse ();


		return path;
	}

}
