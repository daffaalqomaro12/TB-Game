using UnityEngine;
using TMPro;

public class DisplayCharacter : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text genderText;
    public TMP_Text ageText;

    void Start()
    {
        // Ambil data dari PlayerPrefs dan tampilkan di UI
        nameText.text = $"Nama: {PlayerPrefs.GetString("name")}";
        genderText.text = $"Gender: {PlayerPrefs.GetString("gender")}";
        ageText.text = $"Umur: {PlayerPrefs.GetInt("age")}";
    }
}
