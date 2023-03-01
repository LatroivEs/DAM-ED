using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardEquipoController : MonoBehaviour {
    public Button cardButton;
    public CardEquipoController me;
    public int NumController;
    public GameObject go;
    public TMP_Text CardName;
    public TMP_Text C;
    public TMP_Text BBDD;
    public TMP_Text HTML;
    public TMP_Text Descripcion;

    private Card actualCard;



    void Awake (){
        go.GetComponent<ExpositorDeepWEB>().ListaCartas[NumController]=this;
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

    public void ActiveCardXL(){
        CardXL.CargarCarta(actualCard);
        CardXL.SetVisibility(true);
    }
    public void DisableCardXL(){
        CardXL.SetVisibility(false);
    }
}   