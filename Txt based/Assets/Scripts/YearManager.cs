using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearManager : MonoBehaviour
{
    public Transform content;        // Content dari ScrollView
    public GameObject eventPrefab;   // Prefab untuk setiap event log
    public TMP_Text yearCount;       // Teks tahun saat ini
    public TMP_Text ageCount;        // Teks umur
    public Button nextYear;          // Tombol untuk tahun berikutnya
    public ScrollRect scrollRect;    // ScrollRect untuk log event

    private int age;
    private int currentYear = 0;

    void Start()
    {
        // Ambil umur dari PlayerPrefs
        age = PlayerPrefs.GetInt("playerAge", 18); // Default umur jika tidak ada data

        UpdateUI();
        nextYear.onClick.AddListener(AdvanceYear);
    }

    void AdvanceYear()
    {
        age++;
        currentYear++;
        string newEvent = $"Tahun {currentYear}: {GetRandomEvent()}";

        // Tambahkan event baru ke log
        AddEventToLog(newEvent);

        // Scroll otomatis ke bawah agar event terbaru terlihat
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;

        UpdateUI();
    }

    void AddEventToLog(string eventText)
    {
        // Instansiasi prefab dan tambahkan ke Content
        GameObject newEvent = Instantiate(eventPrefab, content);

        // Set teks pada prefab
        TMP_Text eventTMP = newEvent.GetComponent<TMP_Text>();
        eventTMP.text = eventText;

        // Pastikan event baru muncul di bawah (atur sebagai child terakhir)
        newEvent.transform.SetAsLastSibling();
    }

    void UpdateUI()
    {
        yearCount.text = $"Tahun: {currentYear}";
        ageCount.text = $"Umur: {age}";
    }

    string GetRandomEvent()
    {
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
