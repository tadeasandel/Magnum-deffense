using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leveload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel",3f);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
