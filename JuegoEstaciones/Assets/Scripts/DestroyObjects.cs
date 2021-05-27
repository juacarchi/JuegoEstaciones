using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjects : MonoBehaviour
{
    GameplayManager aciertos;
    SFXManager2 sonidoAcierto;
    GameManager fxAcierto;
    // Start is called before the first frame update
    void Start()
    {
        aciertos = GameObject.Find("GameplayManager").GetComponent<GameplayManager>();
        sonidoAcierto = GameObject.Find("SFXManager2").GetComponent<SFXManager2>();
        fxAcierto = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyObject()
    {
        SFXManager2.instance.PlaySFX(sonidoAcierto.succes);
        aciertos.n_aciertos += 1;
        Instantiate(fxAcierto.fx_Stars, this.transform.position, Quaternion.identity);
        
        Destroy(this.gameObject);
    }

}
