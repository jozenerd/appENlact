using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{

public string[] datos_;
public string[] datosconaforo_;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        datos_ = new string[6];
        DontDestroyOnLoad(this.gameObject);
        datosconaforo_ = new string[3];
    }
    

}
