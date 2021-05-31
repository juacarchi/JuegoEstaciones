using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    //public GameObject[] prefabInstanciado;
    public GameObject canvasPadre;
    public List<RectTransform> posObjectsInPanel;
    public GameObject panelVictory;
    public int n_estacion;
    Estacion newEstacion;

    GameObject[] correctObjects;
    GameObject[] incorrectObjects;

    public Text textPrincipal;
    Text textEstacion;

    public int n_aciertos;
    public Image BG;

    public GameObject panelReiniciar;
    GameManager nivelCompletado;

    List<GameObject> estacionesList;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

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
        textPrincipal.text = newEstacion.GetNameEstacion();
        BG.sprite = newEstacion.GetSpriteFondo();
        nivelCompletado.levelsCompleted += 1;

        for (int i = 0; i < correctObjects.Length; i++)
        {
            int aleatorio = Random.Range(0, posObjectsInPanel.Count);
            GameObject instanciarCorrecto = Instantiate(correctObjects[i], posObjectsInPanel[aleatorio].anchoredPosition, Quaternion.identity);
            instanciarCorrecto.transform.SetParent(posObjectsInPanel[aleatorio]);
            RectTransform rect = instanciarCorrecto.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
            rect.localPosition = new Vector3(rect.anchoredPosition.x, rect.anchoredPosition.y, 0);
            rect.localScale = new Vector2(1, 1);
            posObjectsInPanel.RemoveAt(aleatorio);
            Button botonProv = instanciarCorrecto.gameObject.GetComponent<Button>();
            botonProv.interactable = true;
        }
        for (int i = 0; i < incorrectObjects.Length; i++)
        {
            int aleatorio = Random.Range(0, posObjectsInPanel.Count);
            GameObject instanciarIncorrecto = Instantiate(incorrectObjects[i], posObjectsInPanel[aleatorio].anchoredPosition, Quaternion.identity);
            instanciarIncorrecto.transform.SetParent(posObjectsInPanel[aleatorio]);
            RectTransform rect = instanciarIncorrecto.GetComponent<RectTransform>();
            rect.anchoredPosition = Vector3.zero;
            rect.localPosition = new Vector3(rect.anchoredPosition.x, rect.anchoredPosition.y, 0);
            rect.localScale = new Vector2(1, 1);
            posObjectsInPanel.RemoveAt(aleatorio);
            Button botonProv2 = instanciarIncorrecto.gameObject.GetComponent<Button>();
            botonProv2.interactable = false;
        }
        estacionesList.RemoveAt(n_estacion);

    }


    // Update is called once per frame
    void Update()
    {
        if (n_aciertos == 5)
        {
            panelVictory.SetActive(true);
            SFXManager2.instance.PlaySFX(SFXManager2.instance.victory);
            //SFXManager2.instance.PlaySFX(sonidoVictoria.victory);
            n_aciertos = 0;
            if (nivelCompletado.levelsCompleted == 4)
            {
                SFXManager2.instance.PlaySFX(SFXManager2.instance.victory);
                panelVictory.SetActive(false);
                panelReiniciar.SetActive(true);
                for (int i = 0; i < GameManager.instance.principalEstacionList.Count; i++)
                {
                    estacionesList.Add(GameManager.instance.principalEstacionList[i]);
                }
            }
        }
    }
    public void SumaAcierto()
    {
        n_aciertos++;
        Debug.Log(n_aciertos);
    }
}
