using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardXLViewer : MonoBehaviour {
    private static CardXLViewer me;
    
    public static CardViewController[] ListController = new CardViewController[3];
    public TMP_Text CardName;
    public TMP_Text C;
    public TMP_Text BBDD;
    public TMP_Text HTML;
    public TMP_Text Descripcion;

    private static IDeseleccionable ExpositorSeleccionado;

    public Canvas cardXLCanvas;

    private static Card actualCard;
    public static Card[] ListaCartas = new Card[3];

    void Awake (){
        me = this;
    }

    public static void CargarCarta(int num){
        if(ListaCartas[0] == null){
            Debug.Log("Cargando Carta Vacia");    
            return;     
        }
        if(num >=0  && num < ListaCartas.Length){
            actualCard = ListaCartas[num];
        }
        me.CardName.text = actualCard.name;
        me.C.text = ""+actualCard.c;
        me.BBDD.text = ""+actualCard.bbdd;
        me.HTML.text = ""+actualCard.html;
        me.Descripcion.text = actualCard.description;
    }

    public static void CargarLista(int[] listnum){
        for(int i = 0 ; i<3;i++){
            ListaCartas[i]=CardLibrary.CreateCard(listnum[i]);
            ListController[i].CargarCarta(ListaCartas[i]);
        }
        CargarCarta(0);
    }

    public static void UnSelectExpositor(){
         if(ExpositorSeleccionado!= null){
            ExpositorSeleccionado.UnSelect();
        }
    }
    
    public static void CargarExpositor(Expositor expositor){

        UnSelectExpositor();       
        ExpositorSeleccionado=expositor;
        List<Card> lista = expositor.EquipoAlmacenado.GetCards();
        Debug.Log("CargandoExpositor");
        if(lista == null){
            Debug.Log("Cargando Lista Vacia");         
        }else{
            for(int i = 0 ; i<3;i++){
                ListaCartas[i] = lista[i];
                ListController[i].CargarCarta(ListaCartas[i]);
            }
            CargarCarta(0);
        }
    }
}