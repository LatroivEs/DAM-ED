using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextPanel : MonoBehaviour
{
    protected static NextPanel current;
    public Button NextButton;
    public TMP_Text buttonLabel;
    public delegate void NextClick();
    public event NextClick OnNextClick;

    void Awake(){
        current = this;

        NextButton.onClick.AddListener(()=>{
        OnNextClick();});
    }

    public static void Write(string msg){
        current.buttonLabel.text= msg;
    }

}