using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class ExpositorPlayer : Expositor{

    public override void Suscripcion(){
        StorageGO.GetComponent<EquipadoPlayer>().Expositores[NumExpositor] = this;
    }
    
    public override void AlmacenarEnExpositor(Equipo eq){
        this.EquipoAlmacenado=eq;
        Imagen.sprite = Resources.Load<Sprite>(EquipoAlmacenado.Imagen);
    }

    public override void LimpiarExpositor(int indexTypo){
        EquipoAlmacenado = null;
        Imagen.sprite = Resources.Load<Sprite>(EquipoLibrary.ImagenName[NumExpositor]);
    }

    public void RevisarEquipo2(){
        Debug.Log("Entrando"+ (EquipoAlmacenado != null));
        if(EquipoAlmacenado !=null){
            CardXLViewer.CargarExpositor(this);
            Background.color = SelectedBackgroundColor;
            Debug.Log("Seleccionado "+EquipoAlmacenado.Name);
        }
    }

}