using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStateType{
    HOLDING,
    PLACING,
    WAITING,
    GAME_OVER
}
public enum GameOverType{
    CHECKMATE,
    STEALMATE,
    SURRENDER,
    OUT_OF_TIME
}
public class GameState
{
   public GameOverType gameOverType;
   public GameStateType gameStateType;
   public bool IsWaiting{
       get{
           return gameStateType == GameStateType.WAITING;
       }
   }
   public bool IsHolding{
       get{
           return gameStateType == GameStateType.HOLDING;
       }
   }
}
