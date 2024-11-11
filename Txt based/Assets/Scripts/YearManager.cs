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
    public Button trainSTR;
    public Button trainINT; 
    public Button trainAGI;
    public ScrollRect scrollRect;
    public Transform content;
    public GameObject buttonTrain;
    public GameObject deathScreen;
    public GameObject mainScreen;
    public GameObject Notif;
    public Button fight;
    public Button run;
    private HashSet<string> triggeredEvents = new HashSet<string>();
    private Character statsPlayer;
    
    
    
    private int trainPoint = 10;
    private int age;
    private int currentAge;
    private int currentYear = 0;
    
    void Start()
    {
        statsPlayer = GetComponent<Character>();
        age = PlayerPrefs.GetInt("playerAge");
        UpdateUI();
        nextYear.onClick.AddListener(AdvanceYear);
        trainSTR.onClick.AddListener(TrainingSTR);
        trainINT.onClick.AddListener(TrainingINT);
        trainAGI.onClick.AddListener(TrainingAGI);
    }

    void AdvanceYear()
    {
        age++;
        currentYear++;
        trainPoint = 10;
        statsPlayer.IncreaseStats(2);
        Debug.Log($"Strength: {statsPlayer.GetStrength()}");
        
        string randomEvent = eventCheck();
        string newEventText = $"Tahun {currentYear}: {randomEvent} ";
        

        AddEventToLog(newEventText);
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;

        if(randomEvent == "Kamu bertemu naga di tahun ini."){
            NotifBattle();
        }

        UpdateUI();
        TrainingFeature();
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
        return triggeredEvents.Contains(eventName); 
    }
    private void MarkEventAsTriggered(string eventName)
    {
        triggeredEvents.Add(eventName); 
    }

    void TrainingFeature()
    {
        if (age < 6){
            buttonTrain.gameObject.SetActive(false);
            Debug.Log("Mati");
        }else if(age >= 6 ){
            buttonTrain.gameObject.SetActive(true);
            Debug.Log("Ada");
        }
    }

    void TrainingSTR(){
        if(trainPoint != 0){
            statsPlayer.StrTrain(1);
            trainPoint--;
            string trainingText = $"STR +1, training point {trainPoint}";
            AddEventToLog(trainingText);
        }else{
            string trainingText = "Kamu kehabisan train point";
            AddEventToLog(trainingText);
        }
        Debug.Log(trainPoint);
    }

    void TrainingINT(){
        if(trainPoint != 0){
            statsPlayer.INTTrain(1);
            trainPoint--;
            string trainingText = $"INT +1, training point {trainPoint}";
            AddEventToLog(trainingText);
        }else{
            string trainingText = "Kamu kehabisan train point";
            AddEventToLog(trainingText);
        }
        Debug.Log(trainPoint);
    }

    void TrainingAGI(){
        if(trainPoint != 0){
            statsPlayer.AGITrain(1);
            trainPoint--;
            string trainingText = $"AGI +1, training point {trainPoint}";
            AddEventToLog(trainingText);
            
        }else{
            string trainingText = "Kamu kehabisan train point";
            AddEventToLog(trainingText);
        }
        Debug.Log(trainPoint);
    }

    void NotifBattle(){
        Notif.gameObject.SetActive(true);
        fight.onClick.AddListener(Battle);
        run.onClick.AddListener(Run);
    }
   
    
    void Death(){
        deathScreen.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
    }

    void Battle(){
        int currentSTR = statsPlayer.GetStrength();
        int currentAGI = statsPlayer.GetAgility();
        int currentINT = statsPlayer.GetIntelligence();
        string randomEvent = eventCheck();
        if(randomEvent == "Kamu bertemu naga di tahun ini."){
            if(currentSTR < 50 && currentAGI < 50 && currentINT < 50){
                Death();
            }else{
                string trainingText = "Kamu berhasil mengalahkan monster";
                AddEventToLog(trainingText);
            }
        }
    }

    void Run(){

    }
}

