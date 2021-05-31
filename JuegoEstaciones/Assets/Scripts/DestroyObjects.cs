using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjects : MonoBehaviour
{
   
    
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
        
        Destroy(this.gameObject);
    }

}
