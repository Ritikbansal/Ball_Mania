using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    [SerializeField]
	private Material highlightMoveMaterial;
	[SerializeField]
	private Material highlightEatMaterial;
	[SerializeField]
	private Material highlightCheckMaterial;
    [SerializeField]
    public Material pieceP1;
    [SerializeField]
    public Material pieceP2;
    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    public Color pieceHighlightColor;
    private bool ready;
    public LayerMask clickableMask;
    public PlayerChess currentPlayer;
    public GameState gameState;
    private PlayerChess p1=new PlayerChess(PlayerType.P1);
    private PlayerChess p2=new PlayerChess(PlayerType.P2);
    public Color PieceHighlightColor {
		get {return pieceHighlightColor;}
	}
    public Material HighliteCheckMaterial{
        get{
            return highlightCheckMaterial;
        }
    }
    public Material HighliteEatMaterial{
        get{
            return highlightEatMaterial;
        }
    }
    public Material HighliteMoveMaterial{
        get{
            return highlightMoveMaterial;
        }
    }
    public GameState GameState {
		get {return gameState;}
	}
    public PlayerChess CurrentPlayer {
		get {return currentPlayer;}
	}
    public bool IsReady {
		get {return ready;}
	}
    public LayerMask ClickableMask {
		get {return clickableMask;}
	}
    public Material PieceP1{
        get{
            return pieceP1;
        }
    }
    public Material PieceP2{
        get{
            return pieceP2;
        }
    }
    public PlayerChess P1{
        get{
            return p1;
        }
    }
    public PlayerChess P2{
        get{
            return p2;
        }
    }
    public Camera MainCamera {
		get {return mainCamera;}
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
