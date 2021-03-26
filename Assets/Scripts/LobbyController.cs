using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button exitButton;
    // Start is called before the first frame update
    void Awake()
    {
        startButton.onClick.AddListener(StartButtonOnclick);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
    }

    private void StartButtonOnclick()
    {
        SceneManager.LoadScene(1);
    }
}
