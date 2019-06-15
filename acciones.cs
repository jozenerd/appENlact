using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class acciones : MonoBehaviour
{
  GameObject datos;  
  
  void Start()
  {
    datos = GameObject.FindWithTag("Datos");
    //datosconaforo = GameObject.FindWithTag("datosconaforo");


    }

	public void ConAforo()
   {

      GameObject text0_01 = GameObject.FindWithTag("Finca");
      string text_1 = text0_01.GetComponent<Text>().text;
      datos.GetComponent<data>().datos_[0] = text_1;
 
      GameObject text0_02 = GameObject.FindWithTag("Pasto");
      string text_2 = text0_02.GetComponent<Text>().text;
      datos.GetComponent<data>().datos_[1] = text_2;

      GameObject text0_03 = GameObject.FindWithTag("Suplemento");
      string text_3 = text0_03.GetComponent<Text>().text;
      datos.GetComponent<data>().datos_[2] = text_3;  
              
      GameObject text0_04 = GameObject.FindWithTag("Distancia");
      string text_4 = text0_04.GetComponent<Text>().text;
      datos.GetComponent<data>().datos_[3] = text_4;       
    
      GameObject text0_05 = GameObject.FindWithTag("Varios");
      string text_5 = text0_05.GetComponent<Text>().text;
      datos.GetComponent<data>().datos_[4] = text_5;

/*
      GameObject text0_38 = GameObject.FindWithTag("ENlTotalPasto");
      string text_28 = text0_38.GetComponent<Text>().text;
      datosconaforo.GetComponent<data>().datosconaforo_[0] = text_28;

 */
    
      SceneManager.LoadScene("ConAforo");

	}

       
    void Update()
    {
    

      GameObject text0_06 = GameObject.FindWithTag("Rotacion");
      float text_6 = text0_06.GetComponent<Slider>().value;
      datos.GetComponent<data>().datos_[5] = text_6.ToString();



      GameObject text0_07 = GameObject.FindWithTag("Dias");
      text0_07.GetComponent<Text>().text = Mathf.Round(text_6).ToString();
    
        
    }

	public void SinAforo(){
		SceneManager.LoadScene("SinAforo");

	}

}
