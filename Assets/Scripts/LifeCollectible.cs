using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlatformerPlayerCharacter2D.State.LifeCounter();
        Destroy(this.gameObject);
    }
}
