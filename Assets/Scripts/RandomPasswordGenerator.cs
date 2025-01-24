using TMPro;
using UnityEngine;

public class RandomPasswordGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text generatedPassText;
    private string[] specialChars = {"!","#","$"};
    private char[] characters = {'a','b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
    private string generatedPass;
    private int passwordLength;

    public void generateRandomPassword()
    {
        passwordLength = Random.Range(8,24);

        generatedPass = (specialChars[Random.Range(0, 2)] 
            + characters[Random.Range(0, 25)] 
            + specialChars[Random.Range(0, 2)] 
            + characters[Random.Range(0, 25)] 
            + characters[Random.Range(0, 25)].ToString().ToUpper());
    
        generatedPassText.text = generatedPass.ToString();

        Debug.Log("Password length: " + generatedPass);
    }

}