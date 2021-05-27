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
        UITransition.instance.StartLeftAnimation();
        buttonStart.interactable = false;

        //SceneManager.LoadScene(1); //CUANDO HAYA MÁS ANIMALES CAMBIAR POR RANDOMRANGE
    }
    public void RightAnimation()
    {
        UITransition.instance.StartLeftAnimation();
    }
}
