using UnityEngine;
using System.Collections;

public class Heap  {


	private ArrayList nodes=new ArrayList();

	public int size(){
		return nodes.Count;
	}



	public Node pop(){
		if (nodes.Count > 0) {
			Node tmp=(Node)nodes[0];
			nodes.RemoveAt(0);
			return tmp;
		}else{
			return null;
		}
	}

	public void push(Node _node){
		this.nodes.Add (_node);
		this.nodes.Sort ();
	}

	public void updateItem (Node _node){
		//((Node)(nodes[nodes.IndexOf (_node)])).f=0;
		if (nodes.Contains (_node)) {
			this.nodes.Sort ();
		}

	}

	public bool empty(){
		if (nodes.Count == 0) {
			return true;

		}else{
			return false;
		}
	}



	public override string ToString() {
		string str="openlist.count="+nodes.Count+"\n ";

		for (int i=0;i<nodes.Count;i++){
			
			str+=" ["+i+"] "+((Node)nodes[i]).ToString()+"\n";
			

		}
		return str;

	}

}
