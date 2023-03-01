using UnityEngine;
public class TrabajoNameLibrary{
    public static string[] FName= new string[]{
        "Clinica",
        "Base de Datos",
        "Web",
        "Red Social",
        "Tienda",
    };

    public static string[] Animales= new string[]{
        "de Tigres",
        "de Pinguinos",
        "de Perretes",
        "de Gatos",
        "de Ornitorrincos",
        "de Caballos",
        "de Pajaros",
        "de insectos"
    };

    public static string[] Tipo = new string[]{
        "Veterinaria",
        "Dental",
        "Relajante",
        "Simpatica",
    };

    public static string[] Tipo2 = new string[]{
        "Universitaria",
        "Parental",
        "de Trabajo",
        "Sinergica",
        "Fantastica",
        "de Deportes",
        "Dental"
    };

    public static string[] Personas = new string[]{
        "Femenina",
        "Folclorica",
        "Masculina",
        "Geriatrica",
        "Pediatrica",
        "General",
    };


    public static string GenerarNombre(){
        string Nombre = FName[Random.Range(0,FName.Length)];
        if(Random.Range(0,2)==0)
        {
            Nombre+=" "+Tipo[Random.Range(0,Tipo.Length)];
            Nombre+=" "+Animales[Random.Range(0,Animales.Length)]; 
        }else
        {
            Nombre+=" "+Tipo2[Random.Range(0,Tipo2.Length)];
            Nombre+=" "+Personas[Random.Range(0,Personas.Length)]; 
        }
        return Nombre;
    }

}