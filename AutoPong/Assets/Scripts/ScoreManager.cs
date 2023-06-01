using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    // Referencias a los objetos de texto
    public Text scorePlayer1Text;
    public Text scorePlayer2Text;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddPointPlayer1()
    {
        scorePlayer1++;
        scorePlayer1Text.text = scorePlayer1.ToString();  // Actualiza el texto
    }

    public void AddPointPlayer2()
    {
        scorePlayer2++;
        scorePlayer2Text.text = scorePlayer2.ToString();  // Actualiza el texto
    }
}
