using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ExtensionsForInt32
{

    public static bool IsBetween (this int val, int low, int high)
    {
           return val > low && val < high;
    }
}
public class Calculos : MonoBehaviour
{
    string MSPasto="";
    string ENl="";  
    string ENlConc="1.8";
    string MSSuplemento="";
    string ENlSupl="";  
    
    
    //creo las float para las variables de aporte
    float AporteENlPasto;
    float AporteENlConcentrado;
    float AporteENlSuplemento;

        // Start is called before the first frame update
    void Start()
    {
    //les doy un valor inicial a los aportes    



        GameObject text0_01 = GameObject.FindWithTag("Datos");
        string text_1 = text0_01.GetComponent<data>().datos_[1];
        GameObject text0_02 = GameObject.FindWithTag("TipoPasto");
        
    
        //condicionales para la ENl segun el tipo de pasto
        if(text_1=="Kikuyo")
        {
            ENl="1.1";
            text0_02.GetComponent<Text>().text = ENl;
        }
        else if(text_1=="Rye Grass")
        {
            ENl="1.5";
            text0_02.GetComponent<Text>().text = ENl;
        }     
        else if(text_1=="Mezcla")
        {
            ENl="1.3";
            text0_02.GetComponent<Text>().text = ENl;
        }     
        else 
        {
            ENl="1.0";
            text0_02.GetComponent<Text>().text = ENl;
        }  

       
        //para el suplemento ENL y MS
        GameObject text0_12 = GameObject.FindWithTag("Datos");
        string text_6 = text0_12.GetComponent<data>().datos_[2];
        GameObject text0_13 = GameObject.FindWithTag("ENlSupl");
        GameObject text0_15 = GameObject.FindWithTag("MSSupl");
    
        //condicionales para la ENlSupl segun el tipo de suplemento
        if(text_6=="Ensilaje de maiz")
        {
            ENlSupl="1.3";
            text0_13.GetComponent<Text>().text = ENlSupl;
            MSSuplemento="35";
            text0_15.GetComponent<Text>().text = MSSuplemento;    
        }
        else if(text_6=="Ensilaje de naranja")
        {
            ENlSupl="1.5";
            text0_13.GetComponent<Text>().text = ENlSupl;
            MSSuplemento="50";
            text0_15.GetComponent<Text>().text = MSSuplemento;  
        }     
        else if(text_6=="Subprod. galleteria")
        {
            ENlSupl="1.8";
            text0_13.GetComponent<Text>().text = ENlSupl;
            MSSuplemento="88";
            text0_15.GetComponent<Text>().text = MSSuplemento;  
        }
       else if(text_6=="Papa deshidratada")
        {
            ENlSupl="2.6";
            text0_13.GetComponent<Text>().text = ENlSupl;
            MSSuplemento="92";
            text0_15.GetComponent<Text>().text = MSSuplemento;          
        }     
        else 
        {
            ENlSupl="0";
            text0_13.GetComponent<Text>().text = ENlSupl;
            MSSuplemento="0";
            text0_15.GetComponent<Text>().text = MSSuplemento;   
        } 



        GameObject text0_03 = GameObject.FindWithTag("Datos");
        string text_2 = text0_03.GetComponent<data>().datos_[5];
        GameObject text0_04 = GameObject.FindWithTag("MSPasto");
        
        //Condicionales para dias de la rotacion afectando la MS del pasto
        if (int.Parse(text_2) >= 35)
        {
            MSPasto="16";
            text0_04.GetComponent<Text>().text = MSPasto;
        }
        else if (int.Parse(text_2).IsBetween(29,35))
        {
            MSPasto="15";
            text0_04.GetComponent<Text>().text = MSPasto;
        }
        else if (int.Parse(text_2).IsBetween(24,30))
        {
            MSPasto="14";
            text0_04.GetComponent<Text>().text = MSPasto;
        }       
        else 
        {
            MSPasto="13";
            text0_04.GetComponent<Text>().text = MSPasto;
        } 


    }
    

    // Update is called once per frame
    void Update()
    {



        //Calcula los Kg consumidos en el pasto una vez que el usuario introduce los Kg en BF consumidos
        GameObject text0_05 = GameObject.FindWithTag("ConsumoPasto");
        string text_3 = "" + text0_05.GetComponent<Text>().text;

        GameObject text0_08;
        
        if(text_3 != null)
        {
            float ConsumoPas=float.Parse(text_3)/100*float.Parse(MSPasto);     
            GameObject text0_06 = GameObject.FindWithTag("KgMSPasto");
            text0_06.GetComponent<Text>().text = Math.Round (ConsumoPas, 1).ToString();

            //Calcula la ENl aportada por el pasto
             AporteENlPasto=ConsumoPas*float.Parse(ENl);
            text0_08 = GameObject.FindWithTag("ENlTotalPasto");
            text0_08.GetComponent<Text>().text = Math.Round (AporteENlPasto, 1).ToString();
        }

        //Calcula los Kg consumidos en el pasto una vez que el usuario introduce los Kg en BF consumidos
        GameObject text0_07 = GameObject.FindWithTag("ConsumoConcentrado");
        string text_5 = "" + text0_07.GetComponent<Text>().text;

        if(text_5 != null)
        {
            float ConsumoConc=float.Parse(text_5)/100*88;     
            GameObject text0_09 = GameObject.FindWithTag("KgMSConc");
            text0_09.GetComponent<Text>().text = Math.Round (ConsumoConc, 1).ToString();

            //Calcula la ENl aportada por el pasto

            AporteENlConcentrado=ConsumoConc*float.Parse(ENlConc);
            GameObject text0_10 = GameObject.FindWithTag("ENlTotalConc");
            text0_10.GetComponent<Text>().text = Math.Round (AporteENlConcentrado, 1).ToString();
        }


        //Calcula los Kg consumidos en el Suplemento una vez que el usuario introduce los Kg en BF consumidos
        GameObject text0_16 = GameObject.FindWithTag("ConsumoSuplemento");
        string text_7 = "" + text0_16.GetComponent<Text>().text;

        if(text_7 != null)
        {
            float Consumosupl=float.Parse(text_7)/100*float.Parse(MSSuplemento);     
            GameObject text0_17 = GameObject.FindWithTag("KgMSSupl");
            text0_17.GetComponent<Text>().text = Math.Round (Consumosupl,1).ToString();

            //Calcula la ENl aportada por el Suplemento
             AporteENlSuplemento=Consumosupl*float.Parse(ENlSupl);
            GameObject text0_18 = GameObject.FindWithTag("ENlTotalSupl");
            text0_18.GetComponent<Text>().text = Math.Round (AporteENlSuplemento,1).ToString();
        }   
        
        //Calcula la ENl aportada por los alimentos                 
            float ENLTotal=AporteENlPasto+AporteENlConcentrado+AporteENlSuplemento;
            GameObject text0_19 = GameObject.FindWithTag("TotalENl");
            text0_19.GetComponent<Text>().text = Math.Round (ENLTotal,1).ToString();

            

           


    }
}