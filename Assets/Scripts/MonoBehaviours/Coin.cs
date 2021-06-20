using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable currentCoinAmount; 

    private readonly string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(currentCoinAmount != null && collision.tag == PLAYER_TAG)
        {
            currentCoinAmount.Value++;
            gameObject.SetActive(false);
        }
    }
}
