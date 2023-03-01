using System.Collections;
using UnityEngine;

public class Trabajos
{
    public Trabajo[] listTrabajo;

    public string NombreTrabajo;
    
    private Color blue =   new Color(0.2253026f, 0.6446108f, 0.78301890f, 1f);
    private Color green =  new Color(0.1000715f, 0.7641510f, 0.08290318f, 1f);
    private Color pink =   new Color(0.7264151f, 0.1336330f, 0.47431240f, 1f);
    private Color red =    new Color(0.8666667f, 0.1529412f, 0.15294120f, 1f);
    private Color yellow = new Color(0.7375147f, 0.7647059f, 0.08235294f, 1f);

    public int c;
    public int bbdd;
    public int html;

    public int tutoriales;
    public int objetos;

    public int exce;


    public Trabajos(){
        this.ResetTrabajos();
    }

    public void AddTrabajo(Trabajo t)
    {
      switch(t.reqtype){
          case 1:
            c+=t.reqCantidad;
            break;
          case 2:
            bbdd+=t.reqCantidad;
            break;
          case 3:
            html+=t.reqCantidad;
            break;    
      }
      this.tutoriales+=t.rewtutorial;
      this.objetos+=t.rewObjetos;
      this.exce=(c+bbdd+html+1)/2;
    }

    public void ResetTrabajos(){
        c=0;
        bbdd=0;
        html=0;
        tutoriales=0;
        objetos=0;
        exce=0;
    }
}