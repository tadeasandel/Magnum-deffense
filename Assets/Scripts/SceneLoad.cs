using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstLevel", 3f);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

}
