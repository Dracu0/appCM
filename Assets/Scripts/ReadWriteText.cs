using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class ReadWriteText : MonoBehaviour
{
    public TMP_InputField userInputField;
    public TMP_Text displayText;
    public string CustomFileLocation = @"CustomFileLocation";
    private string customFilePath;


    void Start()
    {
        // Combine directory and file name
        customFilePath = Path.Combine(CustomFileLocation, "UserInput.txt");

        // Ensure the directory exists
        if (!Directory.Exists(CustomFileLocation))
        {
            Directory.CreateDirectory(CustomFileLocation);
            Debug.Log($"Directory created at: {CustomFileLocation}");
        }
    }

    public void SaveText()
    {
        try
        {
            string userInput = userInputField.text;
            if (!string.IsNullOrEmpty(userInput))
            {
                File.WriteAllText(customFilePath, userInput);
                Debug.Log($"Text saved to {customFilePath}");
            }
            else
            {
                Debug.LogWarning("Input field is empty. Nothing to save.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogError($"Access denied: {e.Message}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"An error occurred: {e.Message}");
        }
    }

    public void LoadText()
    {
        try
        {
            if (File.Exists(customFilePath))
            {
                string loadedText = File.ReadAllText(customFilePath);
                displayText.text = loadedText;
                Debug.Log($"Text loaded and displayed: {loadedText}");
            }
            else
            {
                displayText.text = "No saved file found.";
                Debug.LogWarning($"No file found at {customFilePath}");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogError($"Access denied: {e.Message}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"An error occurred: {e.Message}");
        }
    }
}