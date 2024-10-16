using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearManager : MonoBehaviour
{
    public GameObject eventPrefab;
    public TMP_Text yearCount;
    public TMP_Text ageCount;
    public Button nextYear;
    public ScrollRect scrollRect;
    public Transform content;

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
        string newEventText = $"Tahun {currentYear}: {randomEvent} ";

        AddEventToLog(newEventText);
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;

        UpdateUI();
    }


    void AddEventToLog(string eventText){
        GameObject newEvent = Instantiate(eventPrefab, content);
        TMP_Text eventTMP = newEvent.GetComponent<TMP_Text>();

        eventTMP.text = eventText;

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
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
