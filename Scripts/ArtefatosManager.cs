using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ArtefatosManager : MonoBehaviour
{
    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanels;

    [Header("Our STAR UI")]
    public int stars;
    public TextMeshProUGUI startText;
    public Text[] unlockStarsTexts;

    public GameObject infoPanel;
    public bool mostrandoInfo;

    public GameObject closeButton;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStarUI();
        UpdateUnLockedStarUI();
    }

    private void UpdateStarUI()
    {
        stars = PlayerPrefs.GetInt("ArtLv" + 1) + PlayerPrefs.GetInt("ArtLv" + 2) + PlayerPrefs.GetInt("ArtLv" + 3) + PlayerPrefs.GetInt("ArtLv" + 4)
         + PlayerPrefs.GetInt("ArtLv" + 5) + PlayerPrefs.GetInt("ArtLv" + 6) + PlayerPrefs.GetInt("ArtLv" + 7) + PlayerPrefs.GetInt("ArtLv" + 8)
             + PlayerPrefs.GetInt("ArtLv" + 9) + PlayerPrefs.GetInt("ArtLv" + 10) + PlayerPrefs.GetInt("ArtLv" + 11) + PlayerPrefs.GetInt("ArtLv" + 12)
          + PlayerPrefs.GetInt("ArtLv" + 13) + PlayerPrefs.GetInt("ArtLv" + 14) + PlayerPrefs.GetInt("ArtLv" + 15) + PlayerPrefs.GetInt("ArtLv" + 16)
          + PlayerPrefs.GetInt("ArtLv" + 17) + PlayerPrefs.GetInt("ArtLv" + 18) + PlayerPrefs.GetInt("ArtLv" + 19) + PlayerPrefs.GetInt("ArtLv" + 20)
          + PlayerPrefs.GetInt("ArtLv" + 21) + PlayerPrefs.GetInt("ArtLv" + 22) + PlayerPrefs.GetInt("ArtLv" + 23) + PlayerPrefs.GetInt("ArtLv" + 24)
          + PlayerPrefs.GetInt("ArtLv" + 25) + PlayerPrefs.GetInt("ArtLv" + 26) + PlayerPrefs.GetInt("ArtLv" + 27) + PlayerPrefs.GetInt("ArtLv" + 28)
          + PlayerPrefs.GetInt("ArtLv" + 29) + PlayerPrefs.GetInt("ArtLv" + 30) + PlayerPrefs.GetInt("ArtLv" + 31) + PlayerPrefs.GetInt("ArtLv" + 32)
          + PlayerPrefs.GetInt("ArtLv" + 33) + PlayerPrefs.GetInt("ArtLv" + 34) + PlayerPrefs.GetInt("ArtLv" + 35) + PlayerPrefs.GetInt("ArtLv" + 36)
          + PlayerPrefs.GetInt("ArtLv" + 37) + PlayerPrefs.GetInt("ArtLv" + 38) + PlayerPrefs.GetInt("ArtLv" + 39) + PlayerPrefs.GetInt("ArtLv" + 40);

        startText.text = stars.ToString();
    }

    private void UpdateUnLockedStarUI()//TODO FIXED LATER this method
    {
        for (int i = 0; i < levelSelectionPanels.Length; i++)
        {
            switch (i)
            {
                case 0://MARKER MAP 01
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("ArtLv" + 1) + PlayerPrefs.GetInt("ArtLv" + 2) + PlayerPrefs.GetInt("ArtLv" + 3) + PlayerPrefs.GetInt("ArtLv" + 4) + PlayerPrefs.GetInt("ArtLv" + 5)
                        + PlayerPrefs.GetInt("ArtLv" + 6) + PlayerPrefs.GetInt("ArtLv" + 7) + PlayerPrefs.GetInt("ArtLv" + 8) + PlayerPrefs.GetInt("ArtLv" + 9) + PlayerPrefs.GetInt("ArtLv" + 10)) + "/" + 10;
                    break;
                case 1://MARKER MAP 02
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("ArtLv" + 11) + PlayerPrefs.GetInt("ArtLv" + 12) + PlayerPrefs.GetInt("ArtLv" + 13) + PlayerPrefs.GetInt("ArtLv" + 14) + PlayerPrefs.GetInt("ArtLv" + 15)
                        + PlayerPrefs.GetInt("ArtLv" + 16) + PlayerPrefs.GetInt("ArtLv" + 17) + PlayerPrefs.GetInt("ArtLv" + 18) + PlayerPrefs.GetInt("ArtLv" + 19) + PlayerPrefs.GetInt("ArtLv" + 20)) + "/" + 10;
                    break;
                case 2://MARKER MAP 03
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("ArtLv" + 21) + PlayerPrefs.GetInt("ArtLv" + 22) + PlayerPrefs.GetInt("ArtLv" + 23) + PlayerPrefs.GetInt("ArtLv" + 24) + PlayerPrefs.GetInt("ArtLv" + 25)
                        + PlayerPrefs.GetInt("ArtLv" + 26) + PlayerPrefs.GetInt("ArtLv" + 27) + PlayerPrefs.GetInt("ArtLv" + 28) + PlayerPrefs.GetInt("ArtLv" + 29) + PlayerPrefs.GetInt("ArtLv" + 30)) + "/" + 10;
                    break;
                case 3://MARKER MAP 04
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("ArtLv" + 31) + PlayerPrefs.GetInt("ArtLv" + 32) + PlayerPrefs.GetInt("ArtLv" + 33) + PlayerPrefs.GetInt("ArtLv" + 34) + PlayerPrefs.GetInt("ArtLv" + 35)
                        + PlayerPrefs.GetInt("ArtLv" + 36) + PlayerPrefs.GetInt("ArtLv" + 37) + PlayerPrefs.GetInt("ArtLv" + 38) + PlayerPrefs.GetInt("ArtLv" + 39) + PlayerPrefs.GetInt("ArtLv" + 40)) + "/" + 10;
                    break;
            }
        }
    }

    public void PressMapButton(int _mapIndex)//MARKER This method will be triggered when we press the (FOUR) map button
    {
        if (!mostrandoInfo)
        {
            levelSelectionPanels[_mapIndex].SetActive(true);
            mapSelectionPanel.SetActive(false);
        }
    }

    public void BackMenu()
    {
        if (!mostrandoInfo)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void BackMapArtSelection()//MARKER this method will be call on the SingleLevel button event
    {
        mapSelectionPanel.SetActive(true);
        for (int i = 0; i < levelSelectionPanels.Length; i++)
        {
            levelSelectionPanels[i].SetActive(false);
        }
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        mostrandoInfo = false;
        closeButton.SetActive(true);
    }

    public void OpenInfoPanel()
    {
        if (!mostrandoInfo) 
        {
            infoPanel.SetActive(true);
            mostrandoInfo = true;
            closeButton.SetActive(false);
        }        
    }
}
