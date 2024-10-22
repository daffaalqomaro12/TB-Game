using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class YearManager : MonoBehaviour
{
    public GameObject eventPrefab;
    public TMP_Text yearCount;
    public TMP_Text ageCount;
    public Button nextYear;
    public ScrollRect scrollRect;
    public Transform content;
    private HashSet<string> triggeredEvents = new HashSet<string>();
    

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
            "Tidak ada peristiwa penting tahun ini.",
            "Kamu belajar jalan.",
            "Kamu diajak berkeliling kota,",
            "Kamu mulai membaca buku dunia."
            };return GetUniqueEvent(events);
        }else if(age >= 6 && age < 18){
            string[] events = {
            "kamu menemukan sebuah benda aneh.",
            "Kamu bertemu naga di tahun ini.",
            "kamu mengikuti event yang dihadirkan.",
            "Tidak ada peristiwa penting tahun ini.",
            "Kamu mulai membaca buku dunia."
            };return GetUniqueEvent(events);
        }else if (age >= 18 && age < 30)
        {
            string[] events = { 
                "Kamu lulus sekolah menengah.", 
                "Kamu mendapat pekerjaan pertama.", 
                "Kamu mulai kuliah.",
                "kamu mengikuti event yang dihadirkan.",
                "Tidak ada peristiwa penting tahun ini.",
                "Kamu mulai membaca buku dunia."
            };return GetUniqueEvent(events);
        }else
        {
            string[] events = { 
                "Tidak ada peristiwa penting tahun ini.", 
                "Kamu mendapatkan promosi kerja.",
                "Kamu berlibur ke luar negeri."
            };
            return GetUniqueEvent(events);
        }
    }

    private List<string> uniqueEvents = new List<string> {
    "Kamu melihat peri pertama kalinya.",
    "Kamu bertemu naga di tahun ini."
    };

    private string GetUniqueEvent(string[] events)
    {
        List<string> validEvents = new List<string>(events);

        foreach (string uniqueEvent in uniqueEvents)
    {
        if (!triggeredEvents.Contains(uniqueEvent))
        {
            validEvents.Add(uniqueEvent);
        }
    }
         if (validEvents.Count == 0)
        {
            return "Tidak ada peristiwa penting tahun ini.";
        }

        string selectedEvent = PickRandomEvent(validEvents.ToArray());

    // Tandai jika event unik telah terjadi
        if (uniqueEvents.Contains(selectedEvent))
        {
        MarkEventAsTriggered(selectedEvent);
        }

        return selectedEvent;
    }

    private string PickRandomEvent(string[] events)
    {
        int randomIndex = UnityEngine.Random.Range(0, events.Length); 
        return events[randomIndex];  
    }
    
    private bool IsEventTriggered(string eventName)
    {
        return triggeredEvents.Contains(eventName); // Cek apakah event sudah pernah terjadi
    }

    private void MarkEventAsTriggered(string eventName)
    {
        triggeredEvents.Add(eventName); // Tandai event sebagai sudah terjadi
    }
}
