using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    public bool isUnlock = false;
    public GameObject lockGo;
    public GameObject unlockGo;

    public int mapIndex;//the index of this map
    public int questNum;//How many stars can unlock this map
    public int startLevel;
    public int endLevel;

    private void Update()
    {
        UpdateMapStatus();//TODO REMOVE later because we don't want to call this method each frame
        UnlockMap();
    }

    private void UpdateMapStatus()
    {
        if(isUnlock)//We Can Play This MAP!
        {
            unlockGo.SetActive(true);
            lockGo.SetActive(false);
        }
        else//This Map still lock now. We have to complete his quest 
        {
            unlockGo.SetActive(false);
            lockGo.SetActive(true);
        }
    }

    private void UnlockMap()//If our current stars number is great than the request number which means we can unlock the next map 
    {        
        if (UIManager.instance.stars >= questNum)
        {
            isUnlock = true;
        }
        else
        {
            isUnlock = false;
        }
    }

}
