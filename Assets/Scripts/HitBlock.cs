using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class HitBlock : MonoBehaviour
{
    public int health = 1;
    private int currentHealth;

    public List<Material> blockHealthMaterials = new List<Material>();
    public Renderer renderer;

    public GameMode gameMode;
    
    private void SetHealthMaterial()
    {
        //Sets material depending on health, ugly but functional
        switch (currentHealth)
        {
            case 1: 
                renderer.material = blockHealthMaterials[0];
                Debug.Log("Set first material");
                break;
            case 2: 
                renderer.material = blockHealthMaterials[1];
                Debug.Log("Set second material");
                break;
            case 3: 
                renderer.material = blockHealthMaterials[2];
                Debug.Log("Set third material");
                break;
        }
    }
    
    //Very ugly but quick and dirty way to calculate which side ball is closest to
    public Vector3 GetClosestSideNormalized(Vector3 ballPos)
    {
        Bounds bounds = GetComponent<Collider>().bounds;

        float leftDist   = Mathf.Abs(ballPos.x - bounds.min.x);
        float rightDist  = Mathf.Abs(ballPos.x - bounds.max.x);
        float backDist   = Mathf.Abs(ballPos.z - bounds.min.z);
        float forwardDist  = Mathf.Abs(ballPos.z - bounds.max.z);

        float closestDist = Mathf.Min(leftDist, rightDist, backDist, forwardDist);

        if (closestDist == leftDist)   return Vector3.left.normalized;
        if (closestDist == rightDist)  return Vector3.right.normalized;
        if (closestDist == backDist)   return Vector3.back.normalized;
        return Vector3.forward.normalized;
    }

    private void Start()
    {
        currentHealth = health;
        gameMode.IncrementBlockAmount();
        SetHealthMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out BallMovement ball);
        {
            Debug.Log("Ball hit block");
            
            //Reflect ball depending on which side it hits
            Vector3 direction = Vector3.Reflect(ball.rb.linearVelocity.normalized, GetClosestSideNormalized(ball.transform.position));
            ball.ApplyForce(direction.normalized);

            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameMode.SetBlockDestroyed();
            Destroy(gameObject);
            return;
        }

        SetHealthMaterial();
    }
}
