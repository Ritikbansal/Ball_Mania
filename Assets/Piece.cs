using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : Moveable,IClickable
{
    // Start is called before the first frame update
    private IPieceMovement pieceMovement;
    private MovementType movementType;
    //private bool isready=false;
    private Node node;
    public IPieceMovement PieceMovement{
        get{
            return pieceMovement;
        }
        set{
            pieceMovement=value;
        }
    }
    public MovementType MovementType{
        get{
            return movementType;
        }
    }
    public bool Inform<T>(T arg) {
		//TODO
		return true;
	}
    public void UpdateNode(Node n)
    {
        if(node!=null)
        {
            node.Clear();
        } node=n;
        if(node!=null)
        {
            node.Piece=this;
        }
    }
    public void Highlight()
    {
        SetEmission(GameManager.Instance.PieceHighlightColor);
    }
    public void ZeroGravity()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    public void Pickup()
    {
        Highlight();
        ZeroGravity();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
