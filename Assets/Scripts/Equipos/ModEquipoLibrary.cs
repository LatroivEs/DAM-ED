using System;
using UnityEngine;
public class ModEquipoLibrary{
    public static string[][] Modlibrary= new string[][]{
        new string[]{"de la Abstraccion","6"},
        new string[]{"del Master-Equalizador","7"},
        new string[]{"del Regulador","20"},
        new string[]{"de la Masoneria","21"},
        new string[]{"de la Levitacion","31"},
        new string[]{"de la Cuadricula-Mortal","32"}, //5

        new string[]{"del Hacedor de Pantallas","8"},
        new string[]{"del Data-Aprendiz","9"},
        new string[]{"del Freelance","10"},
        new string[]{"del Ejecutor","11"},
        new string[]{"del Loop Infinito","22"},
        new string[]{"del Percutor-Mortal","23"},
        new string[]{"del Novato","33"},  //12

        new string[]{"del Interface-Lord","12"},
        new string[]{"del Maestro Torturador","13"},
        new string[]{"del Rayo Prismatico","24"},
        new string[]{"del Movil.Izador","34"},
        new string[]{"del WEB OverLord","35"},
        new string[]{"de Genghis-Khan","36"}, //18
        
    };
    private static int[][] ModxLvl = new int[3][]{
        new int[]{0,0,1,1,2,2,3,3,4,4,5,5,-1},
        new int[]{6,6,7,7,8,8,9,9,10,10,11,11,12,12,-1},
        new int[]{13,14,15,16,17,18}
    };


    public static ModEquipo CreateNewMod(int lvl){
        int mod = GetNumberMod(lvl);
         if(mod>=0 && mod < Modlibrary.Length){
            try{
                return new ModEquipo((string)Modlibrary[mod][0],Int32.Parse(Modlibrary[mod][1]));
            }catch(Exception e){                ;
                Debug.Log(e);
            }
        }
        return new ModEquipo();
    }

    private static int GetNumberMod(int lvl){
        int newLvl =lvl-1;
        if(newLvl<0 || newLvl>2){
            newLvl=0;
        }
        int mod =-1;
        while (mod<0)
        {
            mod = UnityEngine.Random.Range(0,ModxLvl[newLvl].Length);
            if(newLvl<2){
                newLvl++;
            }       
        }
        return mod;
    }
}