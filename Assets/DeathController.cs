using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private CharacterData data;
    private void OnEnable()
    {
        data.onDeath.AddListener(DestroyObject);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
