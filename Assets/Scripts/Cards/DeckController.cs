using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeckController : MonoBehaviour{
    private Deck MazoClase;
    public GameObject[] ListaCartas;
    public GameObject combatManager;
    private List<Card> Mano;
    private int tamMano;


    void Awake(){
        MazoClase = new Deck();
        tamMano = 5; 
        combatManager.GetComponent<CombatManager>().MazoController=this;  
    }

    public void CrearNuevoMazo(){
        MazoClase.Enjuego = new List<Card>();
        MazoClase.Descarte = new List<Card>();
        MazoClase.Mazo = new List<Card>();
    }  

    public void AddListCards(int[] listaCartas){
        foreach(int carta in listaCartas){
            MazoClase.AddCard(CardLibrary.CreateCard(carta));
        }
    }
    public void AddListCards(List<Card> listaCartas){
        foreach(Card carta in listaCartas){
            MazoClase.AddCard(carta);
        }
    }

    public int[] RobarCartas() {
        int[] resultadoMano = new int[]{0,0,0};
        Mano = MazoClase.NewMano();
        Debug.Log(Mano.Count);
        for(int i = 0 ; i < tamMano; i++){
            ListaCartas[i].GetComponent<CardController>().CargarCarta(Mano[i]);
            ListaCartas[i].GetComponent<CardController>().SacarCarta();
            
            resultadoMano[0]+=Mano[i].c;
            resultadoMano[1]+=Mano[i].bbdd;
            resultadoMano[2]+=Mano[i].html;
        }
        return resultadoMano;
    }

    public void DescartarMano(){
        foreach(GameObject go in ListaCartas){
            go.GetComponent<CardController>().DescartarCarta();
        }
    }

}