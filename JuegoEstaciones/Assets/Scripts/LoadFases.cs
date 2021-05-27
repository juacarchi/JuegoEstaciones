using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFases : MonoBehaviour
{
    public void LoadFase()
    {
        SceneManager.LoadScene(1);
        Debug.Log("carga");
    }
}
