using System;
using UnityEngine;

public class MainCharacter : MonoBehaviour, ITurnBasedCharachter
{
    [SerializeField] private CharacterData data;
    [SerializeField] private TargetFinder TargetFinder;
    [SerializeField] private AttackService AttackService;
    [SerializeField] private float speed;
    [SerializeField] private VoidEvent turnOver;
    [SerializeField] private string name;
    private bool canIMove = true;

    public CharacterData Data
    {
        get => data;
        set => data = value;
    }

    public bool CanIMove
    {
        get => canIMove;
        set => canIMove = value;
    }

    private void Update()
    {
        if (!canIMove) return;

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject targetToAttack = TargetFinder.getTarget();
            AttackService.attackEnemy(targetToAttack);
            turnOver.Raise();
            canIMove = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * (Time.deltaTime * speed);
            turnOver.Raise();
            canIMove = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * (Time.deltaTime * speed);
            turnOver.Raise();
            canIMove = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * (Time.deltaTime * speed);
            turnOver.Raise();
            canIMove = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.down * (Time.deltaTime * speed);
            turnOver.Raise();
            canIMove = false;
        }
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public void MakeMove()
    {
        throw new NotImplementedException();
    }
}