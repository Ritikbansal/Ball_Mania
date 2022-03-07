using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType{
        P1,P2
    }
public class PlayerChess : IClicker,IInputReceiver
{
    private List<Piece> pieces;
    private List<Piece> eatenPieces;
    private PlayerType type;
    public PlayerChess(PlayerType pT)
    {   type=pT;
        pieces=new List<Piece>();
        eatenPieces=new List<Piece>();
    }
    public void AddPieces(params Piece[] piece)
    {
        for(int i=0;i<piece.Length;i++)
        {
            this.pieces.Add(piece[i]);
        }
    } 
    public bool Has(Piece p)
    {
        return pieces.Contains(p);
    }
    public void OnInputEvent(InputActionType action)
    {
        switch(action)
        {
            case InputActionType.GRAB_PIECE:
            Node n=Finder.RayHitFromScreen<Node>(Input.mousePosition);
            if(n==null) break;
            Piece p=n.Piece;
            if(p==null) break;
            if(!p.IsReady) break;
            if(Click(n)&& p && Has(p) && Click(p))
            {
                p.Pickup();
            }
            break;
        }
    }
    public void EnableInput()
    {
        InputManager.InputEvent+=OnInputEvent;
    }
    public void DisableInput()
    {
        InputManager.InputEvent-=OnInputEvent;
    }
    void OnDisable()
    {
        DisableInput();
    }
    public bool Click(IClickable clickable)
    {
        if(clickable==null)
        return false;
        return clickable.Inform<PlayerChess>(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
