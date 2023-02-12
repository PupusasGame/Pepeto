using UnityEngine;

public class LinkFanPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToFanPage()
    {
        Application.OpenURL("https://www.facebook.com/urbandogsanctuary/");
    }

    public void ClickOnLeaderBoard()
    {
        if(Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ClickOnAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
}
