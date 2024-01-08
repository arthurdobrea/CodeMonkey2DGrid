using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour, ITurnBasedCharachter
{
    [SerializeField] private CharacterData data;
    [SerializeField] private AttackService attackService;
    private GameObject mainCharacter;
    [SerializeField] private string name;
    public CharacterData Data
    {
        get => data;
        set => data = value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("I found Main Character");
        mainCharacter = col.gameObject;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("I found Main Character");
        mainCharacter = null;
    }

    public void AttackCharacter()
    {
        attackService.attackPlayer(mainCharacter);
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public void MakeMove()
    {
        transform.position += Vector3.right;
        // if (PlayerNearAndCanBeAttack)
        // {
        //     AttackCharacter();
        // }
        // else if (PlayerInVisibleRange)
        // {
        //     MoveTowardsPlayer();
        // }
        // else
        // {
        //     Patrol();
        // }
    }
}
