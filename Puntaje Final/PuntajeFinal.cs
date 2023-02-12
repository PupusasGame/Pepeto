using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeFinal : MonoBehaviour {

    public Text huesos;
    public Text estrellas;
    public Text tiempo;
    public Text puntajeFinal;
    public float minutos;
    public float segundos;
    public float tiempoPuntaje;
    public float puntajetTotal;

    // Use this for initialization
    void Start () {
        
        CrearTiempo();
        ProcesarPuntajeFinal();
    }

    // Update is called once per frame
    void Update() {
        estrellas.text = Puntaje.instance.totalEstrellas.ToString();
        huesos.text = Puntaje.instance.totalHuesos.ToString();
        tiempo.text = "Tiempo: " + minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2, '0');
        puntajeFinal.text =  puntajetTotal.ToString().PadLeft(3,'0');
    }

    public void CrearTiempo()
    {
       tiempoPuntaje = Puntaje.instance.tiempoFinal;

       minutos = (int)tiempoPuntaje / 60;
       segundos = (int) tiempoPuntaje % 60;
        
        //Google Game Services
            if(minutos >= 11)
            {
            Puntaje.instance.DesbloquearLogro(GPGSIds.achievement_justo_a_tiempo);
            }
    }

    void ProcesarPuntajeFinal()
    {
        puntajetTotal = ((int)tiempoPuntaje * 3) + (Puntaje.instance.totalHuesos * 10) + (Puntaje.instance.totalEstrellas * 5);

        //Google Game Services
            Puntaje.instance.ReportarPuntaje((long)puntajetTotal);
            Puntaje.instance.IncrementarLogro(GPGSIds.achievement_estrellas_recolectadas, Puntaje.instance.totalEstrellas);
            Puntaje.instance.IncrementarLogro(GPGSIds.achievement_huesos_recolectados, Puntaje.instance.totalHuesos);  
    }

}
