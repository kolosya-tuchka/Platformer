using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp, maxHp, diamonds, totalDiamonds;
    public bool isAlive, isInvincible, isWinner;

    [HideInInspector]
    public float invTime;

    void Start()
    {
        diamonds = 0;
        hp = maxHp;
        isWinner = false;
        isAlive = true;
        isInvincible = true;
        invTime = 0;
        totalDiamonds = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }

}
