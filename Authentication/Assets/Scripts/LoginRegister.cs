using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.Events;

public class LoginRegister : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI displayText;
    public UnityEvent onLoggedIn;

    [HideInInspector]
    public string playFabId;
    public static LoginRegister instance;
    void Awake () { instance = this; }

    RegisterPlayFabUserRequest registerRequest = new RegisterPlayFabUserRequest
    {
        Username = usernameInput.text,
        DisplayName = usernameInput.text,
        Password = passwordInput.text,
        RequireBothUsernameAndEmail = false

        // not sure where to put these???
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest,
            result =>
            {
                Debug.Log(result.PlayFabId);
            },
            error =>
            {
                Debug.Log(error.ErrorMessage);
            }
        );
    };

    void SetDisplayText (string text, Color color)
    {
        displayText.text = text;
        displayText.color = color;
    }

    LoginWithPlayFabRequest loginRequest = new LoginWithPlayFabRequest
    {
        Username = usernameInput.text,
        Password = passwordInput.text
        
        //not sure where they want me to put these???
        PlayFabClientAPI.LoginWithPlayFab(loginRequest,
            result => Debug.Log("Logged in as: " + result.PlayFabId),
            error => Debug.Log(error.ErrorMessage)
        );
    };

    public void OnLoginButton ()
    {
        result =>
        {
            SetDisplayText("Logged in as: " + result.PlayFabId, Color.green);
            if(onLoggedIn != null)
            onLoggedIn.Invoke();
            playFabId = result.PlayFabId;
        },
    }

    // Start is called before the first frame update
    public void OnRegister()
    {
        string username = "TestUser";
        string password = "password1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}