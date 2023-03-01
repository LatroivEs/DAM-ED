using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour {
    public GameObject deck;
    public GameObject cementery;
    public Button cardButton;
    public CardController me;
    private float velocidad = 600f; 
    private Vector3 posicionFinal;
    private Vector3 posicionDeck;
    private Vector3 posicionCementery;
    private Vector3 positionTarget;

    public TMP_Text CardName;
    public TMP_Text C;
    public TMP_Text BBDD;
    public TMP_Text HTML;
    public TMP_Text Descripcion;

    private Card actualCard;



    void Awake (){
       
    }
    void Start(){
       IniciarPosiciones();
    }

    void Update(){
        this.transform.position= Vector3.MoveTowards(this.transform.position, positionTarget,velocidad*Time.deltaTime);
    }

    private void IniciarPosiciones(){
        posicionFinal = this.transform.position;
        posicionFinal.z = 1f;
        posicionDeck = deck.transform.position;
        posicionCementery = cementery.transform.position;
        positionTarget=posicionFinal;
        this.transform.position = posicionFinal;
    }



    public void SacarCarta(){
        this.transform.position= posicionDeck;
        positionTarget=posicionFinal;
       
    }

    public void DescartarCarta(){
        positionTarget=posicionCementery;
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

    IEnumerator Loop(){
        yield return new WaitForSeconds(3f);
    }
}   