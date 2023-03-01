using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Storage : MonoBehaviour{
    public List<Equipo> FullEquipo;
    public List<Equipo> Cascos;
    public List<Equipo> Calculadoras;
    public List<Equipo> Teclados;
    public List<Equipo> Ordenadores;
    public List<Equipo> Monitores;
    public int __numListaActiva;
    public GameObject combatManager;
    public List<Equipo> ListaActiva;
    public Storage Me;
   
    public Expositor[] Expositores = new Expositor[9];

    public EquipadoPlayer EquipadoJugador;

    public int IndexLista;

    public Button Derecha;
    public Button Izquierda;
    
    void Awake(){
        Me = this;
        combatManager.GetComponent<CombatManager>().Almacen= this;
        InitializeListas();
        ListaActiva = FullEquipo;
        IndexLista=0;
    }

    void Start(){
        foreach(Expositor ex in Expositores){
            ex.storage = Me;
        }
    }

    public void AddEquipo(Equipo eq){
        FullEquipo.Add(eq);
        switch(eq.Typo){
            case TypoEquipo.CABEZA:
                Cascos.Add(eq);
                break;
            case TypoEquipo.CALCULADORA:
                Calculadoras.Add(eq);
                break;
            case TypoEquipo.TECLADO:
                Teclados.Add(eq);
                break;
            case TypoEquipo.ORDENADOR:
                Ordenadores.Add(eq);
                break;    
             case TypoEquipo.MONITOR:
                Monitores.Add(eq);
                break;
        }     
    }

    public void RemoveEquipo(Equipo eq){
                FullEquipo.Remove(eq);
        switch(eq.Typo){
            case TypoEquipo.CABEZA:
                Cascos.Remove(eq);
                break;
            case TypoEquipo.CALCULADORA:
                Calculadoras.Remove(eq);
                break;
            case TypoEquipo.TECLADO:
                Teclados.Remove(eq);
                break;
            case TypoEquipo.ORDENADOR:
                Ordenadores.Remove(eq);
                break;    
             case TypoEquipo.MONITOR:
                Monitores.Remove(eq);
                break;
        }  
    }
    public void EquiparItem(Equipo itemEquipar){
        EquipadoJugador.EquiparItem(itemEquipar);
    }

    public List<Card> GenerarMazo(){
        return EquipadoJugador.GenerarMazo();
    }

    public void InitializeListas(){
        FullEquipo = new List<Equipo>();
        Cascos = new List<Equipo>();
        Calculadoras = new List<Equipo>();
        Teclados = new List<Equipo>();
        Ordenadores = new List<Equipo>();
        Monitores = new List<Equipo>();
    }

    public void ExportarCartasVisor(Expositor expositor){
        CardXLViewer.CargarExpositor(expositor);
    }

    public void CargarListaEntera(){
        __numListaActiva=4;
        CargarListaStorage(FullEquipo);
    }
    public void CargarListaMonitores(){
        __numListaActiva=4;
        CargarListaStorage(Monitores);
    }
    public void CargarListaOrdenadores(){
        __numListaActiva=3;
        CargarListaStorage(Ordenadores);
    }
    public void CargarListaTeclados(){
        __numListaActiva=2;
        CargarListaStorage(Teclados);
    }
    public void CargarListaCalculadoras(){
        __numListaActiva=1;
        CargarListaStorage(Calculadoras);
    }
    public void CargarListaCascos(){
        __numListaActiva=0;
        CargarListaStorage(Cascos);
    }
    private void CargarListaStorage(List<Equipo> Li){
        ListaActiva  = Li;
        IndexLista=0;
        RefreshListaStorage();
    }
    private void RefreshListaStorage(){
        Izquierda.interactable=!(IndexLista==0);
        Derecha.interactable=!(ListaActiva.Count<IndexLista+9);

        for(int i = 0; i<9;i++){
            if(i+IndexLista>=ListaActiva.Count){
                Expositores[i].LimpiarExpositor(__numListaActiva);
            }else{
                Expositores[i].AlmacenarEnExpositor(ListaActiva[i+IndexLista]);
            }
        }
    }

    public void OnClickDerecha(){
        CardXLViewer.UnSelectExpositor();
        IndexLista+=9;
        RefreshListaStorage();
    }

    public void OnClickIzquierda(){
        CardXLViewer.UnSelectExpositor();
        IndexLista-=9;
        if(IndexLista<0){
            IndexLista=0;
        }
        RefreshListaStorage();
    }
}