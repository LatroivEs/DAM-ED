using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPanel : MonoBehaviour
{
    protected static PlayerPanel current;
    public TMP_Text namePlayer;
    
    public TMP_Text cLabel;
    
    public TMP_Text bbddLabel;
    
    public TMP_Text htmlLabel;
    
    public TMP_Text exceLabel;
    
    public TMP_Text vuelLabel;

    void Awake(){
        current = this;
    }

    public static void setName(string name){
        current.namePlayer.text= name;
    }

    public static void setBbdd(int cantidad){
        current.bbddLabel.text= "+"+cantidad;
    }

    public static void setHtml(int cantidad){ 
        current.htmlLabel.text= "+"+cantidad;
    }
    public static void setC(int cantidad){
        current.cLabel.text= "+"+cantidad;
    }
    public static void setVuel(int cantidad){
        current.vuelLabel.text= ""+cantidad;
    }
    
    public static void setExce(int cantidad){
        current.exceLabel.text= ""+cantidad;
    }
    

}