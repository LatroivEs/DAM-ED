using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI: MonoBehaviour{
    public int c;
    public int bbdd;
    public int html;
    public int excelencia;
    public int vuelta;

    public int resC;
    public int resBBDD;
    public int resHTML;

    public TMP_Text labelC;
    public TMP_Text labelBBDD;
    public TMP_Text labelHTML;

    void Awake(){
        JugadorInicial();
    }

    public void RealizarTrabajos(int c, int bbdd, int html, int excelencia){
        this.resC=CheckVuelta(resC,c);
        this.resBBDD=CheckVuelta(resBBDD,bbdd);
        this.resHTML=CheckVuelta(resHTML,html);
        this.excelencia+= excelencia;
        PintarPlayer();
        PintarReserva();
    }

    private int CheckVuelta(int total, int restar){
        if(restar>total){
            vuelta+=(restar-total);
            return 0;
        }
        return total-restar;
    }

    public void MejorarConocimientos(int addC, int addBbdd, int addHtml){
        this.c+=addC;
        this.bbdd+=addBbdd;
        this.html+=addHtml;
        PintarPlayer();
    }

    public void RecargarConocimientosFull(int recC, int recBbdd, int recHtml){
        this.resC= recC+this.c;
        this.resBBDD=recBbdd+this.bbdd;
        this.resHTML=recHtml+this.html;
        PintarReserva();
    }

    public void PintarReserva(){
        labelC.text= "+"+resC;
        labelBBDD.text="+"+resBBDD;
        labelHTML.text="+"+resHTML;
    }
    public void PintarPlayer(){
        PlayerPanel.setC(c);
        PlayerPanel.setBbdd(bbdd);
        PlayerPanel.setHtml(html);
        PlayerPanel.setExce(excelencia);
        PlayerPanel.setVuel(vuelta);
    }


    public void JugadorInicial(){
        this.c=2;
        this.bbdd=2;
        this.html=2;
        this.excelencia=0;
        this.vuelta=0;
        PintarPlayer();
    }
}