using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ScoringZone : MonoBehaviour
{

    public enum Zones
    {
        player,
        computer,
    }

    public Zones currentZone;

    public class BallEnteredEventArgs : EventArgs
    {
        public Zones zone;
    }

    public event EventHandler<BallEnteredEventArgs> OnBallEntered;

   
    private void OnCollisionEnter2D(Collision2D collision){  //когда объект соприкасается с чем-либо 
         Ball ball = collision.gameObject.GetComponent<Ball>(); //а конкретно с мячом
         if (ball != null) {
            OnBallEntered?.Invoke(this, new BallEnteredEventArgs { zone = currentZone});    
         }
    }
}
