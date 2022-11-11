using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public int cost;

    JPMorgan bank;

    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
    }






}
