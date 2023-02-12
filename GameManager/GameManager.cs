using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    GameObject contenedorEstrellas;
    public GameObject[] huesosArray;
    public GameObject panelTimeOut;
    public Flecha flecha;

    public int huesos;
    public int estrellas;
    public float timeScene;
    public float minutos;
    public float segundos;

    public Text estrellasText;
    public Text timeSceneText;
    public Text huesosText;

    bool huesosSueltos;
    public bool tiempoFuera = false;
    public bool hasMedal = false;
    public bool hasKey = false;
    public bool hasChipy = false;
    public bool chipyDelivered = false;

    private void Awake()
    {
        contenedorEstrellas = GameObject.Find("Contenedor Estrellas");

        huesosArray = GameObject.FindGameObjectsWithTag("hueso");
        for(int i = 0; i < huesosArray.Length; i++)
        {
            huesosArray[i].SetActive(false);
        }

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        Puntaje.instance.RequestInterstitial();
        flecha = GameObject.Find("Flecha").GetComponent<Flecha>();
        timeSceneText = GameObject.Find("Tiempo").GetComponent<Text>();
        timeScene = 300;
        huesosSueltos = false;
    }

    // Update is called once per frame
    void Update() {

        if (contenedorEstrellas != null)
        {
            if (contenedorEstrellas.transform.childCount <= 0 && !huesosSueltos)
            {
                SoltarHuesos();
            }
        }

        //Tiempo
        minutos = (int) (timeScene / 60);
        segundos = (int) (timeScene % 60);
        timeScene -= Time.deltaTime;

        timeSceneText.text = minutos.ToString().PadLeft(2, '0') + ':' + segundos.ToString().PadLeft(2, '0');

        estrellasText.text = estrellas.ToString();
        huesosText.text = huesos.ToString();

        if (segundos <= 0 && minutos <= 0)
        {
            timeSceneText.text = "0:00";
            tiempoFuera = true;
        }

        if(tiempoFuera)
        {
            panelTimeOut.SetActive(true);
            StartCoroutine(CargarEscena("Start"));
        }
    }

    void SoltarHuesos()
    {
        for (int i = 0; i < huesosArray.Length; i++)
        {
            huesosArray[i].SetActive(true);
        }

        huesosSueltos = true;
    }

    public void YouWinGame()
    {
        string actualScene = SceneManager.GetActiveScene().name;

        if (actualScene == "Level_01")
        {
            if (hasKey)
            {
                flecha.touched = true;
                AgregarTiempo();
                AgregarHuesosEstrellas();
                Puntaje.instance.ShowInterstitial();
                Puntaje.instance.RequestBanner();
                SceneManager.LoadScene("Level_02", LoadSceneMode.Single);
            }
        }

        if (actualScene == "Level_02")
        {
         
            if (hasMedal)
            {
                flecha.touched = true;
                AgregarTiempo();
                AgregarHuesosEstrellas();
                Puntaje.instance.ShowInterstitial();
                Puntaje.instance.RequestBanner();
                SceneManager.LoadScene("Level_03", LoadSceneMode.Single);
            }
        }

        if (actualScene == "Level_03")
        {
            if(hasChipy)
            {
                flecha.touched = true;
                AgregarTiempo();
                AgregarHuesosEstrellas();
                Puntaje.instance.ShowInterstitial();
                Puntaje.instance.RequestBanner();
                SceneManager.LoadScene("Win", LoadSceneMode.Single);
            }
        }
    }

    void AgregarTiempo()
    {
        Puntaje.instance.tiempoFinal += GameManager.instance.timeScene;
    }

    void AgregarHuesosEstrellas()
    {
        Puntaje.instance.totalHuesos += huesos;
        Puntaje.instance.totalEstrellas += estrellas;
    }

    IEnumerator CargarEscena( string escena)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(escena, LoadSceneMode.Single);
    }


}
