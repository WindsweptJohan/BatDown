using System;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    public GameMode gameMode;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out BallMovement ball))
            return;
        
        gameMode.SetBallOutOfBounds();
    }
}
