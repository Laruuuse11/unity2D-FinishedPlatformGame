using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointForCoin = 1;
    [SerializeField] AudioClip coinPickUP;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToCoin(pointForCoin);
        AudioSource.PlayClipAtPoint(coinPickUP, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
