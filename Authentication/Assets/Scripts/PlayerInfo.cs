using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerInfo : MonoBehaviour
{
    [HideInInspector]
    public PlayerProfileModel profile;

    public static PlayerInfo instance;
    void Awake () { instance = this; }

    GetPlayerProfileRequest getProfileRequest = new GetPlayerProfileRequest
    {
        PlayFabId = LoginRegister.instance.playFabId,
        ProfileConstraints = new PlayerProfileViewConstraints
        {
            ShowDisplayName = true
        }
    };

    public void OnLoggedIn ()
    {
        // once again not sure where to put this
        PlayFabClientAPI.GetPlayerProfile(getProfileRequest,
            result =>
            {
                profile = result.PlayerProfile;
                Debug.Log("Loaded in player: " + profile.DisplayName);
            },
            error => Debug.Log(error.ErrorMessage)
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
