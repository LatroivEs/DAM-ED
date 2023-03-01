using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogPanel : MonoBehaviour
{
    protected static LogPanel current;
    public TMP_Text logLabel;

    void Awake(){
        current = this;
    }

    public static void Write(string msg){
        current.logLabel.text= msg;
    }

}