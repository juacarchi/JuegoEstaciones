using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjects : MonoBehaviour
{
    public string nameText;
    public GameObject textWord;
    GameObject fxAcierto;
    // Start is called before the first frame update
    void Start()
    {
        fxAcierto = GameManager.instance.fx_Stars;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyObject()
    {
        SFXManager2.instance.PlaySFX(SFXManager2.instance.succes);
        GameplayManager.instance.SumaAcierto();
        Instantiate(fxAcierto, this.transform.position, Quaternion.identity);
        //GameObject goText = Instantiate(textWord, this.transform.position, Quaternion.identity);
        //Text text = goText.GetComponentInChildren<Text>();
        //text.text = nameText;
        //Destroy(goText,2f);
        Destroy(this.gameObject);
    }

}
