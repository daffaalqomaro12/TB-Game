using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown genderDropdown;
    public Slider ageSlider;
    public Button createButton;

    private Character playerCharacter;

    void Start(){
        createButton.onClick.AddListener(CreateCharacter);
    }

    void CreateCharacter(){
        PlayerPrefs.SetString("playerName", nameInput.text);
        PlayerPrefs.SetString("playerGender", genderDropdown.options[genderDropdown.value].text);
        PlayerPrefs.SetInt("playerAge", (int)ageSlider.value);
    }
}
