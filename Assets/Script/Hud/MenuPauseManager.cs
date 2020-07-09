using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPauseManager : MonoBehaviour
{
    [SerializeField]
    PlayerStatus playerStatus;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject warningMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Paused();
    }
    void Paused()
    {
        if(playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            pauseMenu.SetActive(true);
            
        }
        else if(!playerStatus.GetWantPause() && playerStatus.GetAlive())
        {
            pauseMenu.SetActive(false);
            warningMenu.SetActive(false);
        }
    }
    public void ExitRequest()
    {
        warningMenu.SetActive(true);
    }
    public void YesButtonPressed()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void NoButtonPressed()
    {
        warningMenu.SetActive(false);
    }
}
