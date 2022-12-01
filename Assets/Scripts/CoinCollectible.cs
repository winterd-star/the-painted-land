using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        PlatformerPlayerCharacter2D.State.CoinCounter();
        Destroy(this.gameObject);
    }
}
