using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinSceneLoader : MonoBehaviour
{
    //public AudioClip CoinFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //AudioSource.PlayClipAtPoint(CoinFX, Camera.main.transform.position);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
