using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquipadoPlayer : MonoBehaviour{
    public Equipo Casco;
    public Equipo Calculadora;
    public Equipo Teclado;
    public Equipo Ordenador;
    public Equipo Monitor;
    public Expositor[] Expositores = new Expositor[5];
    private List<Card>[] EquipoDefecto = new List<Card>[3];
    public GameObject Storage;

    void Awake(){
        Storage.GetComponent<Storage>().EquipadoJugador= this;
        for(int i=0;i<3;i++){
            EquipoDefecto[i] = new List<Card>();
            EquipoDefecto[i].Add(CardLibrary.CreateCard(i));
            EquipoDefecto[i].Add(CardLibrary.CreateCard(i+14));
            EquipoDefecto[i].Add(CardLibrary.CreateCard(i+25));
        }
    }
    void Start(){
        
    }

    public List<Card> GenerarMazo(){
        List<Card> Mazo = new List<Card>();
        AddCartas(Mazo, Monitor);
        AddCartas(Mazo, Ordenador);
        AddCartas(Mazo, Teclado);
        AddCartas(Mazo, Calculadora);
        AddCartas(Mazo, Casco);
        return Mazo;
    }    

    private void AddCartas(List<Card> Lc, Equipo eq){
        List<Card> origen;
        if (eq == null){
            origen = EquipoDefecto[Random.Range(0,3)];
        }else{
            origen = eq.GetCards();
        }
        foreach(Card card in origen){
            Lc.Add(card);
        }
    }

    public void EquiparItem(Equipo item){
        switch(item.Typo){
            case TypoEquipo.CABEZA:
                Casco=item;
                break;
            case TypoEquipo.CALCULADORA:
                Calculadora=item;
                break;
            case TypoEquipo.TECLADO:
                Monitor=item;
                break;
            case TypoEquipo.ORDENADOR:
                Ordenador=item;
                break;
            case TypoEquipo.MONITOR:
                Monitor=item;
                break;
            }
        Expositores[(int)item.Typo].AlmacenarEnExpositor(item);
    }

    public void ClickMonitor(){
        ClickEquipo(Monitor);
    }
    public void ClickOrdenador(){
        ClickEquipo(Ordenador);
    }
    public void ClickTeclado(){
        ClickEquipo(Teclado);
    }
    public void ClickCalculadora(){
        ClickEquipo(Calculadora);
    }
    public void ClickCasco(){
        ClickEquipo(Casco);
    }
    public void ClickEquipo(Equipo eq){
    //    CardXLViewer.CargarLista(eq.GetCards());
    }
    

}