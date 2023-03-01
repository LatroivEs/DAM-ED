using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardViewController : MonoBehaviour {
    public Button cardButton;
    public CardController me;
    public int NumController;

    public TMP_Text CardName;
    public TMP_Text C;
    public TMP_Text BBDD;
    public TMP_Text HTML;
    public TMP_Text Descripcion;

    private Card actualCard;



    void Awake (){
       CardXLViewer.ListController[NumController]=this;
    }
    void Start(){
       
    }

    public void CargarCarta(Card card){
        if(card == null || card.name==null){
            Debug.Log("Carta Vacia");
            return;
        }
        CardName.text = card.name;
        C.text = "" + card.c;
        BBDD.text = "" + card.bbdd;
        HTML.text = "" + card.html;
        Descripcion.text = card.description;
        actualCard = card;
    }

    public void LoadCardXL(){
        CardXLViewer.CargarCarta(NumController);
    }

}   