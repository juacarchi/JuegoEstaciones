using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonMenu;
    string url = "https://iquick.es";
    private void Start()
    {
        buttonStart.interactable = true;
    }
    public void PlayGame()
    {
        TransitionManager.instance.AnimateTransition();
        buttonStart.interactable = false;

    }
    public void ReturnMenu()
    {
        TransitionManager.instance.AnimateTransition();
        buttonMenu.interactable = false;
    }
    public void SetNumber(int numberToScene)
    {
        ManagerScene.instance.SetNumberSceneToChange(numberToScene);
    }
    public void QuitGame()
    {
        //WEB GL
        //Application.OpenURL(url);
        //ANDROID
        Application.Quit();


    }
}
