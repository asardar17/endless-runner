using UnityEngine;
using TMPro;

public class AuthenticationManager : MonoBehaviour
{
    // Login fields
    public TMP_InputField loginEmailInput;
    public TMP_InputField loginPasswordInput;

    // Register fields
    public TMP_InputField registerEmailInput;
    public TMP_InputField registerPasswordInput;

    // Messages
    public TMP_Text loginMessage;
    public TMP_Text registerMessage;

    // Panels
    public GameObject loginCanvas;
    public GameObject registerCanvas;


    // =========================
    // REGISTER
    // =========================
    public void Register()
    {
        string email = registerEmailInput.text.Trim();
        string password = registerPasswordInput.text;

        // Check empty fields
        if (email == "" || password == "")
        {
            registerMessage.text = "Please enter email and password.";
            return;
        }

        // Check if email already exists
        if (PlayerPrefs.HasKey("RegisteredEmail"))
        {
            registerMessage.text = "An account already exists.";
            return;
        }

        // Save email and password
        PlayerPrefs.SetString("RegisteredEmail", email);
        PlayerPrefs.SetString("RegisteredPassword", password);
        PlayerPrefs.Save();

        registerMessage.text = "Registration successful!";

        Debug.Log("Registered: " + email);
    }


    // =========================
    // LOGIN
    // =========================
    public void Login()
    {
        string email = loginEmailInput.text.Trim();
        string password = loginPasswordInput.text;

        // Check if account exists
        if (!PlayerPrefs.HasKey("RegisteredEmail"))
        {
            loginMessage.text = "No account registered.";
            return;
        }

        // Get saved credentials
        string savedEmail = PlayerPrefs.GetString("RegisteredEmail");
        string savedPassword = PlayerPrefs.GetString("RegisteredPassword");

        // Check credentials
        if (email == savedEmail && password == savedPassword)
        {
            string name = email.Split('@')[0];

            loginMessage.text = "Welcome, " + name + "!";

            Debug.Log("Login successful!");

            // Hide login screen
            // loginCanvas.SetActive(false);
        }
        else
        {
            loginMessage.text = "Invalid email or password.";
        }
    }


    // =========================
    // OPEN REGISTER SCREEN
    // =========================
    public void OpenRegister()
    {
        loginCanvas.SetActive(false);
        registerCanvas.SetActive(true);
    }


    // =========================
    // OPEN LOGIN SCREEN
    // =========================
    public void OpenLogin()
    {
        registerCanvas.SetActive(false);
        loginCanvas.SetActive(true);
    }
}