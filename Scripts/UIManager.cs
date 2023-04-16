using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanels;

    [Header("Our STAR UI")]
    public int stars;
    public TextMeshProUGUI startText;
    public MapSelection[] mapSelections;
    public Text[] questStarsTexts;
    public Text[] lockedStarsTexts;
    public Text[] unlockStarsTexts;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()//TODO REmove this method because we don't want to call these methods each frame
    {
        UpdateStarUI();
        UpdateLockedStarUI();
        UpdateUnLockedStarUI();
    }

    private void UpdateLockedStarUI()
    {
        for(int i = 0; i < mapSelections.Length; i++)
        {
            questStarsTexts[i].text = mapSelections[i].questNum.ToString();

            if (mapSelections[i].isUnlock == false)//If one of the Map is locked
            {
                lockedStarsTexts[i].text = stars.ToString() + "/" + mapSelections[i].endLevel * 3;
            }
        }
    }

    private void UpdateUnLockedStarUI()//TODO FIXED LATER this method
    {
        for(int i = 0; i < mapSelections.Length; i++)
        {
            unlockStarsTexts[i].text = stars.ToString() + "/" + mapSelections[i].endLevel * 3;

            switch(i)
            {
                case 0://MARKER MAP 01
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 1) + PlayerPrefs.GetInt("Lv" + 2) + PlayerPrefs.GetInt("Lv" + 3) + PlayerPrefs.GetInt("Lv" + 4) + PlayerPrefs.GetInt("Lv" + 5)
                        + PlayerPrefs.GetInt("Lv" + 6) + PlayerPrefs.GetInt("Lv" + 7) + PlayerPrefs.GetInt("Lv" + 8) + PlayerPrefs.GetInt("Lv" + 9) + PlayerPrefs.GetInt("Lv" + 10)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 1://MARKER MAP 02
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 11) + PlayerPrefs.GetInt("Lv" + 12) + PlayerPrefs.GetInt("Lv" + 13) + PlayerPrefs.GetInt("Lv" + 14) + PlayerPrefs.GetInt("Lv" + 15)
                        + PlayerPrefs.GetInt("Lv" + 16) + PlayerPrefs.GetInt("Lv" + 17) + PlayerPrefs.GetInt("Lv" + 18) + PlayerPrefs.GetInt("Lv" + 19) + PlayerPrefs.GetInt("Lv" + 20)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 2://MARKER MAP 03
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 21) + PlayerPrefs.GetInt("Lv" + 22) + PlayerPrefs.GetInt("Lv" + 23) + PlayerPrefs.GetInt("Lv" + 24) + PlayerPrefs.GetInt("Lv" + 25)
                        + PlayerPrefs.GetInt("Lv" + 26) + PlayerPrefs.GetInt("Lv" + 27) + PlayerPrefs.GetInt("Lv" + 28) + PlayerPrefs.GetInt("Lv" + 29) + PlayerPrefs.GetInt("Lv" + 30)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
                case 3://MARKER MAP 04
                    unlockStarsTexts[i].text = (PlayerPrefs.GetInt("Lv" + 31) + PlayerPrefs.GetInt("Lv" + 32) + PlayerPrefs.GetInt("Lv" + 33) + PlayerPrefs.GetInt("Lv" + 34) + PlayerPrefs.GetInt("Lv" + 35)
                        + PlayerPrefs.GetInt("Lv" + 36) + PlayerPrefs.GetInt("Lv" + 37) + PlayerPrefs.GetInt("Lv" + 38) + PlayerPrefs.GetInt("Lv" + 39) + PlayerPrefs.GetInt("Lv" + 40)) + "/" + (mapSelections[i].endLevel - mapSelections[i].startLevel + 1) * 3;
                    break;
            }
        }
    }

    //MARKER Update OUR Stars UI on the top left connor
    private void UpdateStarUI()
    {
        stars = PlayerPrefs.GetInt("Lv" + 1) + PlayerPrefs.GetInt("Lv" + 2) + PlayerPrefs.GetInt("Lv" + 3) + PlayerPrefs.GetInt("Lv" + 4)
         + PlayerPrefs.GetInt("Lv" + 5) + PlayerPrefs.GetInt("Lv" + 6) + PlayerPrefs.GetInt("Lv" + 7) + PlayerPrefs.GetInt("Lv" + 8)
             + PlayerPrefs.GetInt("Lv" + 9) + PlayerPrefs.GetInt("Lv" + 10) + PlayerPrefs.GetInt("Lv" + 11) + PlayerPrefs.GetInt("Lv" + 12)
          + PlayerPrefs.GetInt("Lv" + 13) + PlayerPrefs.GetInt("Lv" + 14) + PlayerPrefs.GetInt("Lv" + 15) + PlayerPrefs.GetInt("Lv" + 16)
          + PlayerPrefs.GetInt("Lv" + 17) + PlayerPrefs.GetInt("Lv" + 18) + PlayerPrefs.GetInt("Lv" + 19) + PlayerPrefs.GetInt("Lv" + 20)
          + PlayerPrefs.GetInt("Lv" + 21) + PlayerPrefs.GetInt("Lv" + 22) + PlayerPrefs.GetInt("Lv" + 23) + PlayerPrefs.GetInt("Lv" + 24)
          + PlayerPrefs.GetInt("Lv" + 25) + PlayerPrefs.GetInt("Lv" + 26) + PlayerPrefs.GetInt("Lv" + 27) + PlayerPrefs.GetInt("Lv" + 28)
          + PlayerPrefs.GetInt("Lv" + 29) + PlayerPrefs.GetInt("Lv" + 30) + PlayerPrefs.GetInt("Lv" + 31) + PlayerPrefs.GetInt("Lv" + 32)
          + PlayerPrefs.GetInt("Lv" + 33) + PlayerPrefs.GetInt("Lv" + 34) + PlayerPrefs.GetInt("Lv" + 35) + PlayerPrefs.GetInt("Lv" + 36)
          + PlayerPrefs.GetInt("Lv" + 37) + PlayerPrefs.GetInt("Lv" + 38) + PlayerPrefs.GetInt("Lv" + 39) + PlayerPrefs.GetInt("Lv" + 40);

        startText.text = stars.ToString();
    }

    public void PressMapButton(int _mapIndex)//MARKER This method will be triggered when we press the (FOUR) map button
    {
        if(mapSelections[_mapIndex].isUnlock == true)//You can open this map
        {
            levelSelectionPanels[_mapIndex].SetActive(true);
            mapSelectionPanel.SetActive(false);
        }
    }

    public void BackButton()
    {
        mapSelectionPanel.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    //MARKER REMOVE TO THE LEVELSECTAION script because we have to get their isUnlock variable easy.
    //public void SceneTransition(string _sceneName)
    //{
    //    SceneManager.LoadScene(_sceneName);
    //}

    public void BackMapSelection()//MARKER this method will be call on the SingleLevel button event
    {
        mapSelectionPanel.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanels[i].SetActive(false);
        }
        SceneManager.LoadScene("MapSelection");
    }


}
