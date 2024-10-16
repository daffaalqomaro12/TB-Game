using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearManager : MonoBehaviour
{
    public TMP_Text yearEvent;
    public TMP_Text yearCount;
    public TMP_Text ageCount;
    public Button nextYear;

    private int age;
    private int currentYear = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        age = PlayerPrefs.GetInt("playerAge");
        UpdateUI();

        nextYear.onClick.AddListener(AdvanceYear);
        
    }

    // Update is called once per frame
    void AdvanceYear()
    {
        age++;
        currentYear++;
        string randomEvent = GetRandomEvent();
        yearEvent.text = $"Tahun {currentYear}: {randomEvent}";

        UpdateUI();
    }

    void UpdateUI(){
        yearCount.text = $"Tahun: {currentYear}";
        ageCount.text = $"Umur: {age}";
    }

    string GetRandomEvent(){
        string[] events = {
            "Kamu lulus sekolah!",
            "Kamu mendapat pekerjaan baru!",
            "Kamu bertemu teman baru.",
            "Kamu sakit tapi sembuh.",
            "Tidak ada peristiwa besar tahun ini."
        };

        int randomIndex = Random.Range(0, events.Length);
        return events[randomIndex];

    }
}
