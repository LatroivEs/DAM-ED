using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ExamController : MonoBehaviour{
    public List<Sprite> ListaSprite = new List<Sprite>();
    public TMP_Text Pregunta0;
    public TMP_Text Coste0;
    public TMP_Text Premio0;
    public Image Logo0;
    public TMP_Text Pregunta1;
    public TMP_Text Coste1;
    public TMP_Text Premio1;
    public Image Logo1;
    public GameObject go;
    private int indice;

    private Color selected = new Color(0.3897429f, 0.9245283f,0.1177465f, 1f);
    private Color noSelected = new Color(1f,1f,1f,0.6f);
    public Image[] Background = new Image[2];

    private Exam exam;
    private Pregunta[] preguntas = new Pregunta[2];

    private Pregunta SelectedPregunta;

    void Awake(){
        LoadExam(1);
    }

    public void LoadExam(int lvl){
        exam=ExamLibrary.CreateNewExam(lvl);
        indice=0;
        LoadPregunta(0,exam.GetPregunta(indice++));
        LoadPregunta(1,exam.GetPregunta(indice++));
    }

    public void LoadPregunta(int ind, Pregunta pr){
        switch(ind){
            case 0:
                Pregunta0.text= pr.pregunta;
                Coste0.text= ""+(pr.c+pr.bbdd+pr.html);
                Premio0.text= ""+pr.exce;
                Logo0.sprite = ListaSprite[pr.tipo];
                break;
            case 1:
                Pregunta1.text= pr.pregunta;
                Coste1.text= ""+(pr.c+pr.bbdd+pr.html);
                Premio1.text= ""+pr.exce;
                Logo1.sprite = ListaSprite[pr.tipo];
                break;
            default:
            break; 
        }
        preguntas[ind]= pr;
    }

    public void SelectPreguntaI(){
        SelectedPregunta= preguntas[0];
        Background[0].color = selected;
        Background[1].color = noSelected;
    }

    public void SelectPreguntaD(){
        SelectedPregunta= preguntas[1];
        Background[1].color = selected;
        Background[0].color = noSelected;
    }

    public bool Atack_Preguntas(int[] valores){
        if(SelectedPregunta != null){

        }
        return false;
    }



}