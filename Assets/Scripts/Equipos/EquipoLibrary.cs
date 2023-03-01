using System;
using UnityEngine;



public class EquipoLibrary{
    public static string[][] Namelibrary = new string[][]{
        new string[]{"TapaPelos","GucciCap", "Cap-ERST","MasterCap","CubreIdeas","CapXXXL"},
        new string[]{"Tornado 3000","Appel-Cal 2Mano","Calc-Sientifica","C++Hp-230","BlackEdition-Casio200","Z-Graph456"},
        new string[]{"RedTunder 65%","HelloKitty 70%","Snap 65%","SilverThunder 100%","Nurse XL 75%","NoPrint 70%"},
        new string[]{"Pc Robao","HP-Pavillion 2012","Lenovo XS","Laptop de la Junta","IBM-SERVER PIV","WareAlien 100%No-Fake"},
        new string[]{"Monitor 14\"","Monitor 16\"","Pantallamatic 3000","24\"MonsterView","CRT-RetroLumen","MagmaTron"}
    };

    public static int[][] Cardlibrary = new int[3][]{
        new int[]{3,3,4,4,5,5,6,7,17,17,18,18,19,19,20,21,28,28,29,29,30,30,31,32,-1},
        new int[]{6,6,7,7,8,8,9,9,10,10,20,20,21,21,22,22,23,23,31,31,32,32,33,33,34,-1},
        new int[]{9,10,11,11,12,12,22,23,24,24,36,36,33,34,35,35} 
    };
    public static string[] ImagenName= new string[]{
        "Objetos/Top/Top",
        "Objetos/Calculadora/Calc",
        "Objetos/Teclados/Key",
        "Objetos/Ordenadores/Ord",
        "Objetos/Monitores/Mon"
    };

    public static Equipo CreateEquipo(int lvl){
        return CreateEquipo(lvl,(TypoEquipo)UnityEngine.Random.Range(0,5));
    }

    public static Equipo CreateEquipo(int lvl, TypoEquipo tipo){
            //Nombre
            string name = Namelibrary[(int)tipo][UnityEngine.Random.Range(0,Namelibrary[(int)tipo].Length)];
            //Cartas
            int[] cartas = new int[3];
            cartas[0] = GetRandomCARD(lvl);
            cartas[1] = GetRandomCARD(lvl);
            
            string imagen = ImagenName[(int)tipo]+UnityEngine.Random.Range(1,5);
            //Creamos Equipo
            Equipo newEquipo = new Equipo(name,cartas,imagen,tipo);
            //Añadimos el mod
            newEquipo.AddMod(ModEquipoLibrary.CreateNewMod(lvl));
            return newEquipo;
    }
    public static int GetRandomCARD(int lvl){
        int newLvl =lvl-1;
        if(newLvl<0 || newLvl>2){
            newLvl=0;
        }
        int card =-1;
        while (card<0)
        {
            card = Cardlibrary[newLvl][UnityEngine.Random.Range(0,Cardlibrary[newLvl].Length)];
            if(newLvl<2){
                newLvl++;
            }       
        }
        return card;
    }

}