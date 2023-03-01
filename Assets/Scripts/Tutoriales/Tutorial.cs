using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Tutorial : MonoBehaviour{

    public Sprite[] ListImagen;
    public int[] intArray;
    public Tutorial me;
    public string myNombre;
    public CombatManager combatManager;
    private Image myImagen;
    public Image background;
    private Color selectedBorder = new Color(0.3897429f, 0.9245283f,0.1177465f, 1f);
    private Color noSelectedBorder = new Color(1f,1f,1f,0.6f);
    public Button button;
    
    public delegate void ButtonClick(Tutorial tutorial);
    public event ButtonClick OnClickTutorial;

    void Awake(){
        this.me = this;  
        myImagen=GameObject.Find(myNombre).GetComponent<Image>(); 
        RefreshTutorial();

        button.onClick.AddListener(()=>{
            background.color=selectedBorder; 
            OnClickTutorial(me);});
    }

    public int[] GetValue(){        
        return intArray;
    }

    public void RefreshTutorial(){
        myImagen.sprite= ListImagen[Random.Range(0,ListImagen.Length)];
    }

    public void ResSelectedTutorial(){
        background.color=noSelectedBorder; 
    }

}