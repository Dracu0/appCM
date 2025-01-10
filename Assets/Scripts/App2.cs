using TMPro;
using UnityEngine;

public class App2 : MonoBehaviour
{
    public TMP_InputField userInputField, userInputField2, userInputField3;
    public TMP_Text displayText;

    public void MergeText()
    {
        if (userInputField || userInputField2 || userInputField3 != null)
        {
            displayText.text = userInputField.text + " " + userInputField2.text + " " + userInputField3.text;
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
