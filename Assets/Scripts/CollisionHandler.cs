using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadLevel",levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
    private void ReloadLevel() //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
