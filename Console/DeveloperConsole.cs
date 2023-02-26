using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperConsole : MonoBehaviour
{
    #region Cursor
    bool cursorVisible;
    CursorLockMode cursorlockMode;
    #endregion

    #region GUI
    int screenWidth = Screen.width;
    int screenHeight = Screen.height;
    GUIStyle style = new GUIStyle();
    #endregion

    #region Canvas
    public GameObject consoleCanvas;
    public InputField inputField;
    public Text consoleText;
    #endregion

    #region ShowFps
    bool showFpsActive = false;
    float deltaTime = 0.0f;
    #endregion
    
    void Start()
    {
        consoleCanvas.SetActive(false);
        GUIStyle();
    }

    void Update()
    {

        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.BackQuote) || (consoleCanvas.activeSelf && Input.GetKey(KeyCode.Escape)))
        {
            CursorHandler();
            consoleCanvas.SetActive(!consoleCanvas.activeSelf);
            inputField.Select();
            inputField.ActivateInputField();
        }

        if (Input.GetKey(KeyCode.Return) && !string.IsNullOrEmpty(inputField.text)) {
            HandleInput(inputField.text);
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    void CursorHandler()
    {
        if (!consoleCanvas.activeSelf)
        {
            cursorVisible = Cursor.visible;
            cursorlockMode = Cursor.lockState;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.visible = cursorVisible;
            Cursor.lockState = cursorlockMode;
        }
    }

    private void OnGUI()
    {
        if (showFpsActive) { ShowFPS(); }
        
    }

    void GUIStyle()
    {
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = screenHeight * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
    }

    public void HandleInput(string input)
    {
        input = input.ToLower().Trim();

        string command = "";
        List<string> parameters = new List<string>();

        if (input != null && input.Contains(" "))
        {
            command = input.Substring(0, input.IndexOf(" "));

            foreach (string param in input.Replace(command, "").Split(' '))
            {
                if(!param.Equals(" ") && !string.IsNullOrEmpty(param))
                {
                    parameters.Add(param);
                }
            }
        }
       
        consoleText.text += input + "\n";
        
        switch(command)
        {
            case "showfps" :
                if (parameters.Contains("true") || parameters.Contains("1"))
                {
                    showFpsActive = true;
                    consoleText.text += "<color=blue>showfps ENABLED</color>\n";
                } 
                else if (parameters.Contains("false") || parameters.Contains("0"))
                {
                    showFpsActive = false;
                    consoleText.text += "<color=blue>showfps DISABLED</color>\n";
                }
                break;
            default:
                consoleText.text += "<color=red>Invalid Command / Cheat, Try <Command parameter1 parameter2 ...></color>\n";
                break;
        }
    }

    void ShowFPS()
    {
        Rect rect = new Rect(0, 0, screenWidth, screenHeight * 2 / 100);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

}
