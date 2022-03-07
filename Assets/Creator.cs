using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator 
{
   public static IPieceMovement CreatePieceMovement(MovementType m,PlayerChess player,Piece piece)
   {
     switch(m){
         case MovementType.PAWN: return new PawnMovement(player,piece);
         default: return new NoMovement(player,piece);
     }
   }
}
