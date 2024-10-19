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
        string randomEvent = eventCheck();
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

    private string eventCheck(){
        if (age < 6){
            string[] events = {
            "Tidak ada peristiwa besar tahun ini.",
            "Kamu belajar jalan."
            };
            return PickRandomEvent(events);
        }else if(age >= 6 && age < 18){
            string[] events = {
            "Kamu masuk sekolah sihir.",
            "Kamu mbertemu naga di tahun ini."
            };
            return PickRandomEvent(events);
        }else if (age >= 18 && age < 30)
        {
            string[] events = { 
                "Kamu lulus sekolah menengah.", 
                "Kamu mendapat pekerjaan pertama.", 
                "Kamu mulai kuliah."
            };
            return PickRandomEvent(events);
        }else
        {
            string[] events = { 
                "Tidak ada peristiwa penting tahun ini.", 
                "Kamu mendapatkan promosi kerja.",
                "Kamu berlibur ke luar negeri."
            };
            return PickRandomEvent(events);
        }
    }

    private string PickRandomEvent(string[] events)
    {
        int randomIndex = Random.Range(0, events.Length); 
        return events[randomIndex];  

    
    }
}
