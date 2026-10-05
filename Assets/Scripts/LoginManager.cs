using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text welcomeText;

    public void Login()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (email != "" && password != "")
        {
            string name = email.Split('@')[0];

            welcomeText.text = "Welcome, " + name + "!";
            welcomeText.gameObject.SetActive(true);
        }
        else
        {
            welcomeText.text = "Please enter email and password.";
            welcomeText.gameObject.SetActive(true);
        }
    }
}