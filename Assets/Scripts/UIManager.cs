using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Player player; //компонент, отвечающий за информацию об игроке
    public Text diamonds, hearts;
    public GameObject game, pause, win, lose;

    bool isPause;

    void Start()
    {
        OpenGame();
        win.SetActive(false);
        lose.SetActive(false);
    }

    void Update()
    {
        diamonds.text = player.diamonds.ToString() + "/" + player.totalDiamonds.ToString();
        hearts.text = player.hp.ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && player.isAlive && !player.isWinner)
        {
            if (isPause) OpenGame();
            else OpenPause();
        }

        if (player.isWinner) Invoke("Win", 1.5f);
        else if (!player.isAlive) Invoke("Lose", 1.5f);
    }

    void OpenGame()
    {
        isPause = false;
        game.SetActive(true);
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    void OpenPause()
    {
        isPause = true;
        game.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    void Win()
    {
        game.SetActive(false);
        pause.SetActive(false);
        lose.SetActive(false);
        win.SetActive(true);
        Time.timeScale = 0;
    }

    void Lose()
    {
        game.SetActive(false);
        pause.SetActive(false);
        lose.SetActive(true);
        win.SetActive(false);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
