using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputActionType {
	GRAB_PIECE = 0,
	PLACE_PIECE = 1,
	CANCEL_PIECE = 2,
	ZOOM_IN = 3,
	ZOOM_OUT = 4,
	ROTATE = 5,
	STOP_ROTATE = 6,
}
public class InputManager : Singleton<InputManager>
{
    public delegate void InputEventHandler(InputActionType actionType);
    public static event InputEventHandler InputEvent;
    public Vector2 mouseAxis;
    public Node currentNode;
    public Vector2 MouseAxis{
        get{
            return mouseAxis;
        }
    }
    void Start()
    {
        
    }
    void Awake(){
        mouseAxis=new Vector2(0,0);
    }
    // Update is called once per frame
    void Update()
    {
        mouseAxis.x=Input.GetAxis("Mouse X");
        mouseAxis.y=Input.GetAxis("Mouse Y");
        //if(InputEvent==null) return;
        //if(!GameManager.Instance.IsReady) return;
        //HighlightTile();
        if(Input.GetMouseButtonUp(0))
        { print("left click");
            if(GameManager.Instance.GameState.IsWaiting)
            {
                UnHighlightTile();
                InputEvent(InputActionType.GRAB_PIECE);
            }else if(GameManager.Instance.GameState.IsHolding){
                InputEvent(InputActionType.PLACE_PIECE);
            }
        }
    }
    void HighlightTile()
    {
        if(GameManager.Instance.GameState.IsWaiting)
        {
              UnHighlightTile();
              currentNode=Finder.RayHitFromScreen<Node>(Input.mousePosition);
              if(currentNode!=null)
              {
                 Piece piece= currentNode.Piece;
                 if(piece!=null){
                     if(GameManager.Instance.CurrentPlayer.Has(piece)){
                         currentNode.HighliteMove();
                     }else{
                         currentNode.HighliteEat();
                     }
                 }
              }
        }
    }
     void UnHighlightTile()
    {
       
    }
}
