using UnityEngine;
using TMPro;
public class StatsScripts : MonoBehaviour
{

    public TMP_Text strText;
    public TMP_Text intText;
    public TMP_Text agiText;
    public TMP_Text healthText;

    private Character playerCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerCharacter = GetComponent<Character>();

    
    }

    // Update is called once per frame
    void Update()
    {
        
        strText.text = $"STR: {playerCharacter.GetStrength()}";
        intText.text = $"INT: {playerCharacter.GetIntelligence()}";
        agiText.text = $"AGI: {playerCharacter.GetAgility()}";   
        healthText.text = $"Health: {playerCharacter.GetHealth()}";  
    }
}
