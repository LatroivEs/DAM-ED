using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TrabajosHandler : MonoBehaviour{
    
    private Color yellow = new Color(0.7375147f, 0.7647059f, 0.08235294f, 1f);
    private Color black =  new Color(0.1019608f, 0.0862745f, 0.08627451f, 1f);
    private Color red =    new Color(0.8666667f, 0.1529412f, 0.15294120f, 1f);
    private Color selected = new Color(0.3897429f, 0.9245283f,0.1177465f, 1f);
    private Color noSelected = new Color(1f,1f,1f,0.6f);
    
    public Sprite SelectedBackground;
    public Sprite NoSelectedBackground;


    public TrabajosHandler current;
    public CombatManager combatManager;

    private Trabajos trabajoPrincipal;
    private Trabajos trabajoAuxiliar;

    public Button ButtonPrincipal;
    public Button ButtonAuxiliar;
    public Image background;
    
    public TMP_Text tPC;
    public TMP_Text tPBBDD;
    public TMP_Text tPHTML;
    public TMP_Text tPRExce;
    public TMP_Text tPRTutorial;
    public TMP_Text tPRGadget;

    public TMP_Text tAuxiliarC;
    public TMP_Text tAuxiliarBBDD;
    public TMP_Text tAuxiliarHTML;
    public TMP_Text tAuxiliarRExce;
    public TMP_Text tAuxiliarRTutorial;
    public TMP_Text tAuxiliarRGadget;

    public int index;

    public delegate void ButtonClick(TrabajosHandler tr);
    public event ButtonClick OnClickTrabajo;
    private bool auxUp;


    void Awake(){
        current = this;
        trabajoPrincipal= new Trabajos();
        trabajoAuxiliar= new Trabajos();

        ButtonPrincipal.onClick.AddListener(()=>{
            background.color=selected; 
            Bcolor(ButtonPrincipal, SelectedBackground);
            OnClickTrabajo(current);});
        ButtonAuxiliar.onClick.AddListener(()=>{
            auxUp=!auxUp;
            if(auxUp){
                background.color=selected; 
                Bcolor(ButtonPrincipal, SelectedBackground);
                Bcolor(ButtonAuxiliar, SelectedBackground);
                OnClickTrabajo(current);
            }else{
                Bcolor(ButtonAuxiliar, NoSelectedBackground);             
            }
            });
            
        ResSelectedTrabajo();
    }


    public void RellenarTrabajos(int lvl){
        ResetTrabajos();
        int randomPlus=Random.Range(0,3);
        for(int i = 0; i<(3+randomPlus);i++)
        {
            trabajoPrincipal.AddTrabajo(new Trabajo(lvl));
        }
        trabajoAuxiliar.AddTrabajo(new Trabajo(lvl));
        PintarTrabajos();
    }

    public void PintarTrabajos(){
        tPC.text = ""+trabajoPrincipal.c;
        tPBBDD.text = ""+trabajoPrincipal.bbdd;
        tPHTML.text = ""+trabajoPrincipal.html;
        tPRExce.text = ""+trabajoPrincipal.exce;
        tPRTutorial.text = ""+trabajoPrincipal.tutoriales;
        tPRGadget.text = ""+trabajoPrincipal.objetos;

        tAuxiliarC.text = ""+trabajoAuxiliar.c;
        tAuxiliarBBDD.text = ""+trabajoAuxiliar.bbdd;
        tAuxiliarHTML.text = ""+trabajoAuxiliar.html;
        tAuxiliarRExce.text = ""+trabajoAuxiliar.exce;
        tAuxiliarRTutorial.text = ""+trabajoAuxiliar.tutoriales;
        tAuxiliarRGadget.text = ""+trabajoAuxiliar.objetos;
    }

    private void Bcolor(Button b, Sprite c){
        b.image.sprite = c;
    }

    public void ResSelectedTrabajo(){
        auxUp=false;
        background.color=noSelected; 
        Bcolor(ButtonPrincipal, NoSelectedBackground);
        Bcolor(ButtonAuxiliar, NoSelectedBackground);
    }

    private void ResetTrabajos(){
        trabajoPrincipal.ResetTrabajos();
        trabajoAuxiliar.ResetTrabajos();
    }

    public int[] GetValue(){
        int[] valores = new int[6];

        valores[0] = trabajoPrincipal.c + (auxUp? trabajoAuxiliar.c: 0); 
        valores[1] = trabajoPrincipal.bbdd + (auxUp? trabajoAuxiliar.bbdd: 0); 
        valores[2] = trabajoPrincipal.html + (auxUp? trabajoAuxiliar.html: 0);
        valores[3] = trabajoPrincipal.exce + (auxUp? trabajoAuxiliar.exce: 0);  
        valores[4] = trabajoPrincipal.tutoriales + (auxUp? trabajoAuxiliar.tutoriales: 0); 
        valores[5] = trabajoPrincipal.objetos + (auxUp? trabajoAuxiliar.objetos: 0); 

        return valores;
    }

}