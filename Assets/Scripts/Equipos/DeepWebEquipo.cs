using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DeepWebEquipo : MonoBehaviour{

    public DeepWebEquipo me;
    public CombatManager combatManager;
    public int DeepWEBExpositor;
    public ExpositorDeepWEB[] ListaExpositores= new ExpositorDeepWEB[3];
    private ExpositorDeepWEB SelectedEquipment;

    void Awake(){
        this.me = this;
        combatManager.GetComponent<CombatManager>().Mercado=this;
    }

    void Start(){
        foreach(ExpositorDeepWEB ex in ListaExpositores){
            ex.GestorEquipo = me;
        }
        RefreshMercado(1);
    }

    public void SelectEquipo(ExpositorDeepWEB ex){
        if(SelectedEquipment != null)
        {
           UnSelect();
        }
        SelectedEquipment=ex;
    }

    public void UnSelect(){
        SelectedEquipment.UnSelect();
    }

    private void ResetSelection(){
        SelectedEquipment= null;
    }

    public void RefreshMercado(int lvl){
        ResetSelection();
        foreach(ExpositorDeepWEB ex in ListaExpositores){
            ex.AlmacenarEnExpositor(EquipoLibrary.CreateEquipo(lvl));
        }
    }

    public Equipo PickEquipment(){        
        if(SelectedEquipment!= null){
            return SelectedEquipment.GetEquipo();
        }
        return null;
    }

}