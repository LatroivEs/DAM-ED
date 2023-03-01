using System.Collections;
using UnityEngine;

public class Trabajo
{
    public int reqtype;
    public int reqCantidad;
    public int rewtutorial;
    public int rewObjetos;

    private int[][] lvl = new int[3][];

    public Trabajo(int level){
        StartArrays();

        this.reqtype = Random.Range(1,4);
        int[] matriz = lvl[level-1];
        this.reqCantidad = matriz[Random.Range(0,matriz.Length)];

        rewtutorial = reqCantidad*20>Random.Range(0,101) ? 1 : 0;
        rewObjetos = reqCantidad*10>Random.Range(0,101) ? 1 : 0;     
    }

    private void StartArrays(){
        lvl[0]= new int[]{1,1,1,2,2,3};
        lvl[1]= new int[]{2,2,2,3,4,4,5,5};
        lvl[2]= new int[]{2,2,3,3,5,5,6,6};
    }
}

