using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int lastLvPlayed;

    public void MapSelection()
    {
        if (UIManager.instance == null)
        {
            SceneManager.LoadScene("MapSelection");
        }
        else
        {
            UIManager.instance.mapSelectionPanel.SetActive(true);
            SceneManager.LoadScene("MapSelection");
        }        
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ArtMapSelection()
    {
        SceneManager.LoadScene("Artefatos");
    }

    public void Jogar()
    {
        lastLvPlayed = PlayerPrefs.GetInt("LastLv");

        if (lastLvPlayed != 40)
        {
            SceneManager.LoadScene("Fase" + (lastLvPlayed + 1));
        }
        else
        {
            SceneManager.LoadScene("Fase40");
        }
    }

    public void Sair()
    {
        Application.Quit();
    }

}
