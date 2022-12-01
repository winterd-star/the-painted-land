using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string NextLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
    }
}
