using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardXL : MonoBehaviour {
    private static CardXL me;
  
    public TMP_Text CardName;
    public TMP_Text C;
    public TMP_Text BBDD;
    public TMP_Text HTML;
    public TMP_Text Descripcion;

    public Canvas cardXLCanvas;

    private Card actualCard;

    void Awake (){
        me = this;
        CardXL.SetVisibility(false);
        //suscribir eventos?
    }

    public static void SetVisibility(bool visibility){
        me.cardXLCanvas.enabled = visibility;
    }

    public static void CargarCarta(Card card){
        if(card == null || card.name==null){
            Debug.Log("Carta Vacia");
            return;
        }
        me.CardName.text = card.name;
        me.C.text = ""+card.c;
        me.BBDD.text = ""+card.bbdd;
        me.HTML.text = ""+card.html;
        me.Descripcion.text = card.description;
    }
}