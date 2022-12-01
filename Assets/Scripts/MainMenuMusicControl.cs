using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicControl : MonoBehaviour
{
    public static MainMenuMusicControl instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

}
