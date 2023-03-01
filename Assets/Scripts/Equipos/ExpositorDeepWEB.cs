using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class ExpositorDeepWEB : Expositor{

    public DeepWebEquipo GestorEquipo;
    public ExpositorDeepWEB Me;

    public CardEquipoController[] ListaCartas = new CardEquipoController[3];

    public override void Suscripcion(){
        StorageGO.GetComponent<DeepWebEquipo>().ListaExpositores[NumExpositor] = this;
        Me = this;
    }
    
    public override void AlmacenarEnExpositor(Equipo eq){
        this.EquipoAlmacenado=eq;
        Imagen.sprite = Resources.Load<Sprite>(EquipoAlmacenado.Imagen);
        Nombre.text = eq.Name;
        for(int i = 0 ; i<ListaCartas.Length;i++){
            ListaCartas[i].CargarCarta(eq.GetCards()[i]);
        }
        
    }
    public override void LimpiarExpositor(int indexTypo){
        EquipoAlmacenado = null;
        Imagen.sprite = Resources.Load<Sprite>(EquipoLibrary.ImagenName[NumExpositor]);
    }

    public void Select(){
        GestorEquipo.SelectEquipo(Me);
        Background.color=SelectedBackgroundColor;
    }

}