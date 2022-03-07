using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createGrid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] pre;
    [SerializeField]
    private GameObject tileWhite;
    [SerializeField]
    private GameObject tileBlack;
    [SerializeField]
    private int rows=2;
    [SerializeField]
    private int cols=3;
    [SerializeField]
    private Vector3 tileSize;
    [SerializeField]
    private Vector3 size;
    public bool isReady{
        get{
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    if(!grid[i,j].IsReady)
                    return false;
                }
            } return true;
        }
    }
    public int Rows{
        get{
            return rows;
        }
    }
    public int Cols{
        get{
            return cols;
        }
    }
    public int Size{
        get{
            return rows*cols;
        }
    }
    public Node GetNodeAt(int r,int c)
    {
        if(r>=0&&c>=0&&r<=7&&c<=7)
        return grid[r,c];
        else return null;
    }
    GameObject tile;
    private Node[,] grid;
    // Update is called once per frame
    void Update()
    {
        
    }
    Renderer rend;

    void Start()
    {
        rend = tileWhite.GetComponent<Renderer>();
        tileSize=rend.bounds.size;
        size=new Vector3(8,tileSize.y,8);
        grid = new Node[rows,cols];
        createBase();
    }
    void createBase()
    {
    tile=tileBlack;
    Vector3 bottomLeft=new Vector3(-size.x/2+tileSize.x/2,0,-size.z/2+tileSize.z/2);
    Vector3 startPos=bottomLeft;
        for (int row = 0; row < rows; row++) {
            changeTilePrefab(tile);
			for (int col = 0; col < cols; col++) {
            startPos.x=bottomLeft.x+tileSize.x*col;
            startPos.z=bottomLeft.z+tileSize.z*row;
            GameObject go = Instantiate(tile, startPos, tileWhite.transform.rotation) as GameObject;
			changeTilePrefab(tile);
            Node dn = go.AddComponent<Node>();
				dn.row = row;
				dn.col = col;
               dn.rowChess = Convertor.ToChessRow(row);
			   dn.colChess = Convertor.ToChessCol(col);
              grid[row,col]=dn;
              go.transform.parent = transform;
			  go.transform.localScale = Vector3.zero;
              dn.ScaleIn(Random.Range(0f,1f),Random.Range(1f,2f),tile.transform.localScale);
          //  print(Random.Range(0f,1f)+" "+ Random.Range(1f,2f));
            }
        }
        StartCoroutine(SpawnPieces());
    }
    
    void changeTilePrefab(GameObject t)
    {
        if(t==tileBlack)
        tile=tileWhite;
        else tile=tileBlack;
    }
    IEnumerator SpawnPieces()
    {
        while(!isReady)
        yield return null;
        //print("spawn pieces called");
        PlayerType p1=PlayerType.P1;
        PlayerType p2=PlayerType.P2;

        for(int i=0;i<8;i++)
        {
            SpawnPiece(new GridCoords(1,i),pre[0],p1);
            SpawnPiece(new GridCoords(6,i),pre[0],p2);
        }
       // yield return null;
    }
    public void SpawnPiece(GridCoords g,GameObject pre,float rota,PlayerType p)
    {
         Node n=GetNodeAt(g.row,g.col);
         Vector3 pR=pre.transform.rotation.eulerAngles;
         Quaternion newR=Quaternion.Euler(pR.x,rota,pR.z);
         
         GameObject piec=Instantiate(pre,n.transform.position+Vector3.up*0.3f,Quaternion.identity) as GameObject;
         piec.transform.localScale=Vector3.zero;
         //print(piec.transform.position+" "+piec.transform.rotation);
         Piece pS=piec.GetComponent(typeof(Piece)) as Piece;
         Material m=null;
         PlayerChess player=null;
         switch (p)
         {
            case PlayerType.P1: m=GameManager.Instance.PieceP1;  player=GameManager.Instance.P1;
            break;
            case PlayerType.P2: m=GameManager.Instance.PieceP2;  player=GameManager.Instance.P2;
            break;
         }
         piec.GetComponent<Renderer>().material=m;
         player.AddPieces(pS);
         pS.PieceMovement=Creator.CreatePieceMovement(pS.MovementType,player,pS);
         if(pS) pS.ScaleIn(Random.Range(0f,1f),Random.Range(1f,2f),pre.transform.localScale);
        pS.UpdateNode(n);
        // piec.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
    }
    public void SpawnPiece(GridCoords g,GameObject pre,PlayerType p)
    {
        SpawnPiece(g,pre,0.0f,p);
    }
  /*  void OnDrawGizmosSelected()
    {
      
    } */
}
