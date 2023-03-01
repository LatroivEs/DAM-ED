using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

public interface IDeseleccionable
{
    void UnSelect();
}

public class Expositor : MonoBehaviour, IDeseleccionable{
    public Equipo EquipoAlmacenado;
    public TMP_Text Nombre;

    public GameObject StorageGO;
    public Storage storage;
    public Image Imagen;
    public int NumExpositor;

    public Image Background;
    protected Color SelectedBackgroundColor = new Color(0.3897429f, 0.9245283f,0.1177465f, 1f);
    protected Color NoSelectedBackgroundColor = new Color(1f,1f,1f,0.6f);

    //para el dobleClick
    private float clicked =0;
    private float clicktime =0;
    private float clickdelay = 0.5f;
    void Awake(){
        Suscripcion();
    }

    public virtual void Suscripcion(){
        StorageGO.GetComponent<Storage>().Expositores[NumExpositor] = this;
    }
    public virtual void LimpiarExpositor(int indexTypo){
        EquipoAlmacenado = null;
        Nombre.text = "";
        Imagen.sprite = Resources.Load<Sprite>(EquipoLibrary.ImagenName[indexTypo]);
        
    }
    public void GetAlmacen(){
        storage = StorageGO.GetComponent<Storage>().Me;
    }

    public Equipo GetEquipo(){
        return EquipoAlmacenado;
    }

    public virtual void AlmacenarEnExpositor(Equipo eq){
        if(storage == null){
            GetAlmacen();
        }
        this.EquipoAlmacenado=eq;
        Nombre.text=EquipoAlmacenado.Name;
        Imagen.sprite = Resources.Load<Sprite>(EquipoAlmacenado.Imagen);
    }

    public void Revisar(){
        if(EquipoAlmacenado !=null){
            CardXLViewer.CargarExpositor(this);
            Background.color = SelectedBackgroundColor;
            Debug.Log("Seleccionado "+EquipoAlmacenado.Name);
        }
    }

    public void Equipar(){
        if(EquipoAlmacenado !=null){
            Debug.Log("p "+storage.__numListaActiva);
            storage.EquiparItem(EquipoAlmacenado); 
            Debug.Log("Equipado "+EquipoAlmacenado.Name);
        }
    }

    public void UnSelect(){
        Background.color = NoSelectedBackgroundColor;
    }

    public void OnClickorDoubleClick(){
        clicked+=1;
        if (clicked == 1) {
            clicktime = Time.time;
            Revisar();
        }
        else if (clicked > 1 && (Time.time - clicktime < clickdelay))
        {
            Debug.Log("DobleClick");
            clicked = 0;
            clicktime = 0;
            Revisar();
            Equipar();
        }
        else  {
            clicked = 0;
        }
    }
}
