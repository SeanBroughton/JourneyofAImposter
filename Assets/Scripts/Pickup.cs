using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pointsForCoinPickup = 10;
    [SerializeField] AudioClip coinPickupSFX;
    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!wasCollected && other.tag == "Player")
        {
            wasCollected = true;
            
            //Adds Score when player picks up coin
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            //Audio
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 0.5f);
            //Makes Coin not interactable, then destroys coin
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
