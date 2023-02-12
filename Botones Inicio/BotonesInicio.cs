using UnityEngine.SceneManagement;
using UnityEngine;


public class BotonesInicio : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Jugar()
    {
        Puntaje.instance.totalEstrellas = 0;
        Puntaje.instance.totalHuesos = 0;
        Puntaje.instance.tiempoFinal = 0;
        SceneManager.LoadScene("Level_01", LoadSceneMode.Single);
        Puntaje.instance.ShowInterstitial();
        Puntaje.instance.RequestBanner();
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Inicio()
    {
        Puntaje.instance.totalEstrellas = 0;
        Puntaje.instance.totalHuesos = 0;
        Puntaje.instance.tiempoFinal = 0;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
        Puntaje.instance.ShowInterstitial();
        Puntaje.instance.RequestBanner();
    }
}
