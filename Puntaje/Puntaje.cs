using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour {

    public BannerView bannerView;
    public InterstitialAd interstitial;
    public static Puntaje instance;

    public float minutosFinal;
    public float segundosFinal;
    public float tiempoFinal;
    public int totalHuesos;
    public int totalEstrellas;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    // Use this for initialization
    void Start () {
        GooglePlayServicesInit();
        RequestBanner();
        RequestInterstitial();
    }
	
	// Update is called once per frame
	void Update () {


    }

    //anuncios Admobs
    public void RequestBanner()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-6737259196260392/3664673880"; // Banner Pepeto admob
        #elif UNITY_IPHONE
                                    string adUnitId = "unexpected_platform";
        #else
                                    string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.TopLeft);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

       // bannerView.OnAdLoaded += HandleOnAdLoaded;
        
    }

   /* public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        bannerView.Show();

    }*/

    public void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-6737259196260392/9397837555"; // Insterstitial Pepeto Admob
                   
        #elif UNITY_IPHONE
                        string adUnitId = "unexpected_platform";
        #else
                        string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    
    public void ShowInterstitial()
    {
        
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void GooglePlayServicesInit()//Iniciar googlePlay Services
    {
        //Game Services
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);
            }
        });
    }

    public void DesbloquearLogro(string logro)
    {
        Social.ReportProgress(logro, 100.0f, (bool success) => {
            Debug.Log("Desbloqueando: " + logro);
        });
    }

    public void IncrementarLogro(string logro, int cantidadLogro)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(
        logro, cantidadLogro, (bool success) => {
            // handle success or failure
        });
    }

    public void ReportarPuntaje(long score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_puntaje_de_pepeto_al_rescate, (bool success) =>
        {
            Debug.Log("Enviando Puntaje: " + score);
        });
    }
}
