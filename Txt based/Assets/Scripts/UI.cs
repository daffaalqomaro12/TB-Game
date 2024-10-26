using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    
    public GameObject buttonTrain;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Training()
    {
        if (PlayerPrefs.GetInt("currentAge") < 6){
            buttonTrain.gameObject.SetActive(false);
            Debug.Log("Mati");
        }else if(PlayerPrefs.GetInt("currentAge") >= 6 ){
            buttonTrain.gameObject.SetActive(true);
            Debug.Log("Ada");
        }

        
    }

    void Update(){
    }
}
