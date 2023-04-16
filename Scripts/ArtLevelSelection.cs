using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtLevelSelection : MonoBehaviour
{
    public string symbolName;
    public string info;
    public bool isUnlocked = false;
    public Image lockImage;//LOCK IMAGE
    public Image unlockImage;
    public GameObject infoPanel;
    public TextMeshProUGUI infoPanelTitulo;
    public Image infoPanelImage;
    public TextMeshProUGUI infoPanelText;
    public GameObject closeButton;
    

    // Start is called before the first frame update
    void Start()
    {
        UnlockLevel();
        UpdateLevelButton();
    }

    private void UnlockLevel()
    {   
        if (PlayerPrefs.GetInt("ArtLv" + int.Parse(gameObject.name)) > 0)//At least get one stars in previous level
        {
            isUnlocked = true;//can unlock the next level
        }

    }

    private void UpdateLevelButton()
    {
        if (isUnlocked)//MARKER We can play this level
        {
            lockImage.gameObject.SetActive(false);
            unlockImage.color = new Color(0, 0, 0, 100);

            GetComponent<Button>().interactable = true;
        }
        else
        {
            lockImage.gameObject.SetActive(true);
            unlockImage.color = new Color(0, 0, 0, 0);

            GetComponent<Button>().interactable = false;
        }
    }

    public void OpenInfoPanel()
    {
        closeButton.SetActive(false);
        infoPanel.SetActive(true);
        infoPanelTitulo.text = symbolName;
        infoPanelImage.sprite = unlockImage.sprite;
        infoPanelText.text = info;

        infoPanel.GetComponentInChildren<ScrollRect>().verticalScrollbar.value = 1;
    }

    public void CloseInfoPanel()
    {
        closeButton.SetActive(true);
        infoPanel.SetActive(false);
    }
}
