using System;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    private GameObject currentTarget;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("im here");
        GameObject enemy = col.gameObject;
        if (enemy.tag.Equals("Enemy"))
        {
            Debug.Log("I found enemy");
            currentTarget = enemy;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("I lost enemy");
            currentTarget = null;
        }
    }

    public GameObject getTarget()
    {
        return currentTarget;
    }
}