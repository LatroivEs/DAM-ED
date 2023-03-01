using System;
using UnityEngine;

public class ExamLibrary(){
    private static string[] ListaPreguntasC = new string[]{
        "¿Que es un tipo basico?",
        "¿Como se hereda una clase?",
        "¿Que harias para ordenar una lista?",
        "¿Como harias para tener varias clases distintas en la misma Lista?",
        "¿Los Arrays pueden contener distintos tipos de datos a la vez?",
        "¿Que significa && en una comparacion?",
        "¿Para que sirven los metodos estaticos?",
        "¿Como implementarias una interfaz en java?",
        "¿Diferencias entre un For y un Foreach?",
        "¿Como se sobrescribe un metodo en una clase heredada?",
        "¿Como nos podemos suscribir a un evento?"
    };

    private static string[] ListaPreguntasBBDD = new string[]{
        "¿Primera ley formal?",
        "¿Como indicamos un campo de texto en MySQL?",
        "¿Como podemos obtener todos los registros de una tabla?",
        "¿Inner join explica para que se usa?",
        "¿Que dispara a un Trigger?, ¿es configurable?",
        "¿Di 3 maneras de importar datos entre BBDD distintas?",
        "¿Que es una Clave primaria?",
        "¿Como establecerias una Clave Foranea?",
        "¿Diferencia entre BBDD relacionales y No-relacionales?",
        "¿Como podemos comprobar la integridad de un dato dentro de nuestra BBDD?",
        "¿Que es una Vista, para que nos sirve?",
    };

    private static string[] ListaPreguntasHTML = new string[]{
        "¿Que es un H1?";
        "¿Como podemos cambiar el color del texto?";
        "¿Que es SASS?";
        "¿Que significa responsive?";
        "¿Que es una mediaquery?";
        "¿Se puede insertar texto desde CSS?";
        "¿Diferencias entre GRID y FLEX?";
        "¿Como harias una tabla?";
        "¿Que es un gradiant?";
        "¿Como insertarias un enlace a otra pagina?";
        "¿Diferencias entre POST y GET en un formulario?";
    };

    private static int[][] Lvl= int[][]{
        new int[]{1,1,1,1,2},
        new int[]{2,2,2,2,3},
        new int[]{2,2,3,3,4}
    };

    public static Exam CreateNewExam(int lvl){
        Exam exam = new Exam();
        for(int =0; i<3;i++){
            exam.AddPregunta(CreateNewPregunta(lvl));
        }        
    }

    public static Pregunta CreateNewPregunta(int lvl){
        int[] valor = new int[]{0,0,0};

        int indice = UnityEngine.Random.Range(0,3);
        valor[indice]= Lvl[lvl][UnityEngine.Random.Range(0,Lvl[lvl].Length)];
        switch(indice){
            case 0:
                string preg = ListaPreguntasC[UnityEngine.Random.Range(0,ListaPreguntasC.Length)];
                break;
            case 1:
                string preg = ListaPreguntasBBDD[UnityEngine.Random.Range(0,ListaPreguntasBBDD.Length)];
                break;
            case 2:
                string preg = ListaPreguntasHTML[UnityEngine.Random.Range(0,ListaPreguntasHTML.Length)];
                break;
        }
        Pregunta pr = new Pregunta(valor[0],valor[1],valor[2], preg);
        return pr;
    }

}