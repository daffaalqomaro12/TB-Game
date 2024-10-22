using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown genderDropdown;
    public Slider ageSlider;
    public Button createButton;
    public TMP_Text valueText;

    private Character playerCharacter;

    void Start(){
        createButton.onClick.AddListener(CreateCharacter);

        ageSlider.onValueChanged.AddListener(UpdateSliderValue);
        UpdateSliderValue(ageSlider.value);
    }

    void CreateCharacter(){
        PlayerPrefs.SetString("name", nameInput.text);
        PlayerPrefs.SetString("gender", genderDropdown.options[genderDropdown.value].text);
        PlayerPrefs.SetInt("age", (int)ageSlider.value);
    }

    void UpdateSliderValue(float value){
        valueText.text = $"Umur: {value.ToString("0")}";
    }
}
