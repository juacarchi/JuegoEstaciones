using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button buttonStart;
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

    }
    public void RightAnimation()
    {
        UITransition.instance.StartLeftAnimation();
    }
}
