using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateOver : MonoBehaviour
{

    public Button restart;
    public Button continuegame;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenMenu(bool gameisover)
    {
        
        if (gameisover)
        {
            continuegame.enabled = false;
        }
        else
        {
            continuegame.enabled = true;
        }
        text.text = (gameisover) ? "You went bankrupt!" : "You win! You made a city in " + GameManager.gm.day + " days. ";

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Continue()
    {
        gameObject.SetActive(false);
    }
}
