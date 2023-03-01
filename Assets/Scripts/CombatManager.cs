using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public enum FaseStatus
{
    CREANDO_TRABAJOS,
    SELECT_TRABAJOS,
    CREANDO_TUTORIAL,
    SELECT_TUTORIAL,
    CREANDO_GADGET,
    BONUS_GADGET,
    SELECT_BGADGET,
    SELECT_GADGET,
    DESCARTANDO_MANO,
    ROBANDO_MANO,
    SELECT_EQUIPO,
    ATACK_EXAM,
    FIN_CURSO
}
public enum CanvasTrabajo
{
    TRABAJOS,
    TUTORIAL,
    GADGET,
    SEQUIPO,
    EXAM
}


public class CombatManager : MonoBehaviour
{
    public GameObject[] ListTR;
    public GameObject[] ListTutoriales;
    public GameObject NextButton;
    public GameObject PlayerScript;
    public Storage Almacen;
    public DeepWebEquipo Mercado;
    public DeckController MazoController;
    private bool prueba;
    private bool isCursoActive;

    private FaseStatus faseStatus;

    private PlayerUI player;

    private int TutorialRewards;
    private int DeepWebGadget;
    private int numWork;
    private int trimestre;

    public TMP_Text NumTrabajoLabel;
    public TMP_Text trimestreLabel;

    private string[] trimestresText = new string[]{"Primer Trimestre", "Segundo Trimestre", "Tercer Trimestre"};

    private TrabajosHandler SelectedTrabajo;
    private Tutorial SelectedTutorial;
    private Equipo SelectedGadget;

    public Canvas tutorial;
    public Canvas trabajos;
    public Canvas deepWebAdquisition;
    public Canvas seleccionEquipo;
    public Canvas XLViewer;
    
    void Start(){
        LogPanel.Write("Empezamos");

        foreach(GameObject go in ListTR){
                go.GetComponent<TrabajosHandler>().combatManager= this;
                go.GetComponent<TrabajosHandler>().OnClickTrabajo += SelectTrabajo;
        }
        foreach(GameObject go in ListTutoriales){
                go.GetComponent<Tutorial>().combatManager= this;
                go.GetComponent<Tutorial>().OnClickTutorial += SelectTutorial;
        }
        player = PlayerScript.GetComponent<PlayerUI>();

        NextButton.GetComponent<NextPanel>().OnNextClick+=Next;

        isCursoActive=true;
        
        this.faseStatus=FaseStatus.ROBANDO_MANO;
        trimestre=1;
        numWork=1;
        CargarDeck();
        StartCoroutine(this.CursoLoop());
    }

    IEnumerator CursoLoop(){
        yield return new WaitForSeconds(1f);

        while (this.isCursoActive){
            switch(faseStatus){
                case FaseStatus.SELECT_TRABAJOS:                  
                    yield return null;
                    break;
                case FaseStatus.SELECT_TUTORIAL:
                    yield return null;
                    break;  
                case FaseStatus.SELECT_GADGET:
                    yield return null;
                    break;  
                case FaseStatus.SELECT_BGADGET:
                    yield return null;
                    break;
                case FaseStatus.SELECT_EQUIPO:
                    yield return null;
                    break;    
                case FaseStatus.DESCARTANDO_MANO:
                    MazoController.DescartarMano();
                    yield return new WaitForSeconds(1.5f);
                    this.faseStatus = FaseStatus.ROBANDO_MANO;
                    break;
                case FaseStatus.ROBANDO_MANO:
                    int[] recursos = MazoController.RobarCartas();
                    player.RecargarConocimientosFull(recursos[0], recursos[1],recursos[2]);
                    this.faseStatus=FaseStatus.CREANDO_TRABAJOS;
                    break;
                case FaseStatus.CREANDO_TRABAJOS:
                    if(trimestre>3){
                        this.faseStatus=FaseStatus.FIN_CURSO;
                        break;
                    }
                    NumTrabajoLabel.text=numWork+"/3";
                    trimestreLabel.text=trimestresText[trimestre-1];
                    NuevosTrabajos(trimestre);
                    this.faseStatus= FaseStatus.SELECT_TRABAJOS;
                    LogPanel.Write("Selecciona un Trabajo para hacer.");
                    break;
                  
                case FaseStatus.CREANDO_TUTORIAL:
                    if(TutorialRewards-- > 0){
                        NuevoTutorial();
                        this.faseStatus=FaseStatus.SELECT_TUTORIAL;
                    }else{
                        this.faseStatus=FaseStatus.CREANDO_GADGET;
                        SetCanvasActive(CanvasTrabajo.GADGET);
                    }                
                    break;   
                case FaseStatus.CREANDO_GADGET:
                    if(DeepWebGadget-- > 0){
                        NuevoGadget();
                        this.faseStatus=FaseStatus.SELECT_GADGET;
                    }else{
                        if(numWork++>2){
                            trimestre++;
                            numWork=1;
                            this.faseStatus=FaseStatus.SELECT_EQUIPO;
                            Almacen.CargarListaEntera();
                            SetCanvasActive(CanvasTrabajo.SEQUIPO);
                            break;
                        }                     
                        this.faseStatus=FaseStatus.CREANDO_TRABAJOS;
                        SetCanvasActive(CanvasTrabajo.TRABAJOS);
                    }
                    break;
                case FaseStatus.BONUS_GADGET:
                    BonusGadget();
                    this.faseStatus=FaseStatus.SELECT_BGADGET;
                    break;            
                case FaseStatus.FIN_CURSO:
                    FinCurso();
                    break;
                default:
                break;         
            }
        }
    }

    private void Next(){
        switch(faseStatus){
                case FaseStatus.CREANDO_TRABAJOS:
                    break;
                case FaseStatus.SELECT_TRABAJOS:
                    if(SelectedTrabajo != null){
                       int[] valores = SelectedTrabajo.GetValue();
                       player.RealizarTrabajos(valores[0],valores[1],valores[2],valores[3]);
                       TutorialRewards=valores[4];
                       DeepWebGadget=valores[5];
                       SelectedTrabajo=null;
                       DeselectTrabajos();
                       this.faseStatus=FaseStatus.CREANDO_TUTORIAL;
                       SetCanvasActive(CanvasTrabajo.TUTORIAL);
                    }
                    break;
                case FaseStatus.SELECT_TUTORIAL:
                if(SelectedTutorial!=null){  
                    int[] valores = SelectedTutorial.GetValue();
                    player.MejorarConocimientos(valores[0],valores[1],valores[2]);
                    SelectedTutorial=null;
                    DeselectTutorial();
                    CrearTutoriales();
                    this.faseStatus=FaseStatus.CREANDO_TUTORIAL;
                }
                    break;
                case FaseStatus.SELECT_GADGET:
                    SelectedGadget= Mercado.PickEquipment();
                    if(SelectedGadget!= null){
                        Mercado.UnSelect();
                        Almacen.AddEquipo(SelectedGadget);
                        this.faseStatus=FaseStatus.CREANDO_GADGET;
                    }
                    break;
                case FaseStatus.SELECT_BGADGET:
                    SelectedGadget= Mercado.PickEquipment();
                    if(SelectedGadget!= null){                        
                        Mercado.UnSelect();
                        Almacen.AddEquipo(SelectedGadget);
                        this.faseStatus=FaseStatus.SELECT_EQUIPO;
                        LogPanel.Write("Selecciona 1 Equipo Gratis");
                        SetCanvasActive(CanvasTrabajo.SEQUIPO);
                    }
                    break;
                case FaseStatus.SELECT_EQUIPO:
                    CargarDeck();
                    MazoController.TestMazo();
                    LogPanel.Write("Selecciona el equipo que deseas llevar.");
                    this.faseStatus=FaseStatus.DESCARTANDO_MANO;
                    SetCanvasActive(CanvasTrabajo.TRABAJOS);
                    break;
                default:
                break;          
            }
    }

    private void SelectTrabajo(TrabajosHandler th){
        if(SelectedTrabajo!=th){
            SelectedTrabajo = th;
            DeselectTrabajos();
        }
    }
    private void DeselectTrabajos(){
        foreach(GameObject go in ListTR){
            if(SelectedTrabajo== null || go.GetComponent<TrabajosHandler>().current!=SelectedTrabajo){
                //Debug.Log(go);
                go.GetComponent<TrabajosHandler>().ResSelectedTrabajo();
            }
        }
    }
    
    private void SelectTutorial(Tutorial tutorial){
        if(SelectedTutorial!=tutorial){
            SelectedTutorial = tutorial;
            DeselectTutorial();
        }
    }
    private void DeselectTutorial(){
        foreach(GameObject go in ListTutoriales){
            if(SelectedTutorial== null || go.GetComponent<Tutorial>().me!=SelectedTutorial){
                go.GetComponent<Tutorial>().ResSelectedTutorial();
            }
        }
    }

    private void NuevosTrabajos(int lvl){
        foreach(GameObject go in ListTR){
                go.GetComponent<TrabajosHandler>().RellenarTrabajos(lvl);
        }
    }
    private void CrearTutoriales(){
        foreach(GameObject go in ListTutoriales){
                go.GetComponent<Tutorial>().RefreshTutorial();
        }
    }    

    private void NuevoTutorial(){
        LogPanel.Write("Escoge el tutorial para ver"+(TutorialRewards==0?"(queda solo 1).":("(quedan "+(TutorialRewards+1)+")")));
    }

    private void NuevoGadget(){
        Mercado.RefreshMercado(trimestre);
        LogPanel.Write("Escoge el objeto"+(DeepWebGadget==0?"(queda solo 1).":("(quedan "+(DeepWebGadget+1)+")")));
    }

    private void FinCurso(){
        LogPanel.Write("Excelencia: "+ player.excelencia+" Vueltecitas: "+player.vuelta);
        isCursoActive=false;
    }

    private void SetCanvasActive(CanvasTrabajo ct){
        
        switch(ct){
            case CanvasTrabajo.TRABAJOS:
                trabajos.enabled = true;
                tutorial.enabled = false;
                deepWebAdquisition.enabled = false;
                seleccionEquipo.enabled = false;
                XLViewer.enabled = false;
                break;
            case CanvasTrabajo.TUTORIAL:
                trabajos.enabled = false;
                tutorial.enabled = true;
                deepWebAdquisition.enabled = false;
                seleccionEquipo.enabled = false;
                XLViewer.enabled = false;
                break;
            case CanvasTrabajo.GADGET:
                trabajos.enabled = false;
                tutorial.enabled = false;
                deepWebAdquisition.enabled = true;
                seleccionEquipo.enabled = false;
                XLViewer.enabled = false;
                break;
            case CanvasTrabajo.SEQUIPO:
                trabajos.enabled = false;
                tutorial.enabled = false;
                deepWebAdquisition.enabled = false;
                seleccionEquipo.enabled = true;
                XLViewer.enabled = true;
                break;
        }

    }
    private void BonusGadget(){

    }

    
    private void CargarDeck(){
        MazoController.CrearNuevoMazo();
        List<Card> newDeck= Almacen.GenerarMazo();
        MazoController.AddListCards(newDeck);
    }

}