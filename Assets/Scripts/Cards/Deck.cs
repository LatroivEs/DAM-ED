using System.Collections.Generic;
using UnityEngine;
public class Deck{
    public List<Card> Mazo;
    public List<Card> Descarte;
    public List<Card> Enjuego;
    public int tamaMano;

    public Deck(){
        Mazo = new List<Card>();
        Descarte = new List<Card>();
        Enjuego = new List<Card>();
        tamaMano = 5;
    }

    public Deck(List<Card> ListC) : this(){
        foreach(Card c in ListC){
            Mazo.Add(c);
        }
    }

    public void AddCard(Card card){
        Mazo.Add(card);
    }

    public void RemoveCard(Card card){
        List<Card>[] pilas = new List<Card>[]{Mazo,Descarte,Enjuego};
        for(int x= 0; x<pilas.Length;x++){
            for(int i = 0 ; i< pilas[x].Count; i++){
                if (card.name == pilas[x][i].name){
                    pilas[x].RemoveAt(i);
                    return ;
                }            
            }
        }       
    }

    public List<Card> NewMano(){
        return NewMano(tamaMano);
        
    }
    public List<Card> NewMano(int n){
        DescartarJuego();
        for(int i = 0 ; i< n; i++){
            RobarUna();
        }
        return Enjuego;
    }

    public void RobarUna(){
        if(Mazo.Count==0){
            Barajar();
        }
        int numRandom = Random.Range(1,Mazo.Count)-1;
        Enjuego.Add(Mazo[numRandom]);
        Mazo.RemoveAt(numRandom);
    }

    private void Barajar(){
         foreach(Card c in Descarte){
            Mazo.Add(c);
        }
        Descarte = new List<Card>();
    }

    private void DescartarJuego(){
        foreach(Card c in Enjuego){
            Descarte.Add(c);
        }
        Enjuego = new List<Card>();
    }
}