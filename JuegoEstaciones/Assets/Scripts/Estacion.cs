using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estacion : MonoBehaviour
{
    public string nameEstacion;
    public GameObject[] correctsObjects;
    public GameObject[] incorrectObjects;
    public AudioClip audioEstacion;
    public Text textEstacion;
    public Sprite spriteFondo;

    public Estacion(GameObject[] correctsObjects, GameObject[] incorrectObjects, string nameEstacion, AudioClip audioEstacion, Text textEstacion, Sprite spriteFondo)
    {
        this.correctsObjects = correctsObjects;
        this.incorrectObjects = incorrectObjects;
        this.nameEstacion = nameEstacion;
        this.audioEstacion = audioEstacion;
        this.textEstacion = textEstacion;
        this.spriteFondo = spriteFondo;
    }

    //SETTERS
    public void SetCorrectObjects(GameObject[] correctsObjects)
    {
        this.correctsObjects = correctsObjects;
    }
    public void SetIncorrectObjects(GameObject[] incorrectObjects)
    {
        this.incorrectObjects = incorrectObjects;
    }
    public void SetNameEstacion(string nameEstacion)
    {
        this.nameEstacion = nameEstacion;
    }
    public AudioClip GetEstacionSound()
    {
        return audioEstacion;
    }
    public void SetTextEstacion(Text textEstacion)
    {
        this.textEstacion = textEstacion;
    }

    //GETTERS
    public GameObject[] GetCorrectsObjects()
    {
        return this.correctsObjects;
    }
    public GameObject[] GetIncorrectObjects()
    {
        return this.incorrectObjects;
    }
    public string GetNameEstacion()
    {
        return this.nameEstacion;
    }
    public Text GetTextEstacion()
    {
        return this.textEstacion;
    }
    public Sprite GetSpriteFondo()
    {
        return this.spriteFondo;
    }
}
