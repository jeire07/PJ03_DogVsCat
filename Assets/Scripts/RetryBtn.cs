using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void ReGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
