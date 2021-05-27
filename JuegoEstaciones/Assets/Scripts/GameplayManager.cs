using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    //public GameObject[] prefabInstanciado;
    public GameObject canvasPadre;
    public List<GameObject> posObjectsInPanel;
    public GameObject panelVictory;
    public int n_estacion;
    Estacion newEstacion;
    GameObject[] correctObjects;
    GameObject[] incorrectObjects;
    public Text textPrincipal;
    Text textEstacion;
    public GameObject posTextoPrincipal;
    public List<GameObject> backgroundsController;
    public int n_aciertos;
    public Image BG;
    public Sprite SpriteBg;
    SFXManager2 sonidoVictoria;
    public GameObject panelReiniciar;
    GameManager nivelCompletado;

    List <GameObject> estacionesList;

    // Start is called before the first frame update
    void Start()
    {
        sonidoVictoria = GameObject.Find("SFXManager2").GetComponent<SFXManager2>();
        nivelCompletado = GameObject.Find("GameManager").GetComponent<GameManager>();
        n_aciertos = 0;
       panelVictory.SetActive(false);
        panelReiniciar.SetActive(false);
        estacionesList = GameManager.instance.GetEstacionList();
        RandomEstacion();
        Debug.Log("activo");
    }
    public void RandomEstacion()
    {
        n_estacion = Random.Range(0, estacionesList.Count);
        newEstacion = estacionesList[n_estacion].GetComponent<Estacion>();
        correctObjects = newEstacion.GetCorrectsObjects();
        incorrectObjects = newEstacion.GetIncorrectObjects();
        textEstacion = newEstacion.GetTextEstacion();
        textPrincipal.text = textEstacion.text;
        SpriteBg = newEstacion.GetSpriteFondo();
        BG.sprite = SpriteBg;
        nivelCompletado.levelsCompleted += 1;

        for (int i = 0; i < correctObjects.Length; i++)
        {
            int aleatorio = Random.Range(0, posObjectsInPanel.Count);
            GameObject instanciarCorrecto = Instantiate(correctObjects[i], posObjectsInPanel[aleatorio].transform.position, Quaternion.identity);
            instanciarCorrecto.transform.SetParent(canvasPadre.transform);
            posObjectsInPanel.RemoveAt(aleatorio);
            Button botonProv = instanciarCorrecto.gameObject.GetComponent<Button>();
            botonProv.interactable = true;
        }
        for (int i = 0; i < incorrectObjects.Length; i++)
        {
            Button botonProv = incorrectObjects[i].gameObject.GetComponent<Button>();
            botonProv.interactable = true;
            int aleatorio2 = Random.Range(0, posObjectsInPanel.Count);
            GameObject instanciarIncorrecto = Instantiate(incorrectObjects[i], posObjectsInPanel[aleatorio2].transform.position, Quaternion.identity);
            instanciarIncorrecto.transform.SetParent(canvasPadre.transform);
            posObjectsInPanel.RemoveAt(aleatorio2);
            Button botonProv2 = instanciarIncorrecto.gameObject.GetComponent<Button>();
            botonProv2.interactable = false;
        }
        estacionesList.RemoveAt(n_estacion);
        
    }
    

    // Update is called once per frame
    void Update()
    {
       if(n_aciertos == 5)
        {
            panelVictory.SetActive(true);
            SFXManager2.instance.PlaySFX(sonidoVictoria.victory);
            //SFXManager2.instance.PlaySFX(sonidoVictoria.victory);
            n_aciertos = 0;
            if (nivelCompletado.levelsCompleted == 4)
            {
                SFXManager2.instance.PlaySFX(sonidoVictoria.victory);
                panelVictory.SetActive(false);
                panelReiniciar.SetActive(true);
                for (int i = 0; i < GameManager.instance.principalEstacionList.Count; i++)
                {
                    estacionesList.Add(GameManager.instance.principalEstacionList[i]);
                }
            }
        }
    }
}
