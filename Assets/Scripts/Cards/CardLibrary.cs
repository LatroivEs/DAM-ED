using System;
using UnityEngine;
public class CardLibrary{
    public static string[][] library= new string[][]{
        new string[]{"For","1","0","0","Se empieza por lo basico"},
        new string[]{"While","1","0","0","Se empieza por lo basico"},
        new string[]{"Do-While","1","0","0","Se empieza por lo basico"}, //(2)
        new string[]{"Short","2","0","0","La gente se pone muy sensible con su manera de ordenar"},
        new string[]{"Interface", "2","0","0","Perros y triangulos ¿que tienen en comun?"},
        new string[]{"Atributo de Clase", "2","0","0","Es obvio que un dentista necesita 'becarios' a su cargo"}, //5
        new string[]{"Clase abstracta","3","0","0","Esta no hace nada por si misma"},
        new string[]{"Equals","3","0","0","Para comparar cadenas necesitamos esto... en C# con un == basta"}, //7
        new string[]{"Servlet","2","0","2","¿De verdad en 2023 la gente usa esto?"},
        new string[]{"JDBC Driver","2","2","0","Sencillo y para toda la familia.... ¿o no?"}, 
        new string[]{"Import mysql2","2","2","1","Javascript, BBDD, HTML... el pack completo"},
        new string[]{"Execute Update","3","2","0","Transaccion, Rollback... Beneficios"},       //10
        new string[]{"JavaFX","3","1","2","Facil y sencillo.... ¿como que no es sencillo?"},
        new string[]{"Swing","4","1","3","Lo tiene todo, es peor y mas dificil"},               //13
        new string[]{"SELECT","0","1","0","Se empieza por lo basico"},
        new string[]{"WHERE","0","1","0","Se empieza por lo basico"},
        new string[]{"ORDER BY","0","1","0","Se empieza por lo basico"},     //16
        new string[]{"GROUP BY","0","2","0","Agrupar es como montar en bici, salvo que no tiene nada que ver"},
        new string[]{"INNER JOIN","0","2","0","Es antinatural, si las dos tablas estaban separadas sera por algo"},
        new string[]{"UNION ALL","0","2","0","Spoiler. Si no tienes cuidado Sale Mal"}, //19
        new string[]{"Leyes Formales","0","3","0","Mucho Texto, para decirte que no repitas datos"},
        new string[]{"Oracle","0","4","0","Dice la leyenda que un tipo de Elche tiene toda sus certificaciones..."}, //21
        new string[]{"Procedure","2","3","0","¿Programar en BBDD? Que FELICIDAD¡¡¡"},
        new string[]{"Trigger","3","3","0","Cuando alguien compre jabones, metemos el numero de perros que tiene en esta tabla"},
        new string[]{"Prisma","2","4","2","Es muy facil de instalar... ¿Puedes venir un momento, Carlos?"}, //24
        new string[]{"HTML <H1>","0","0","1","Se empieza por lo basico"},
        new string[]{"HTML <Div>","0","0","1","Se empieza por lo basico"},
        new string[]{"HTML <p>","0","0","1","Se empieza por lo basico"}, //27
        new string[]{".CSS","0","0","2","SOY UN DIOS puedo cambiar el color del texto"},
        new string[]{":Hover","0","0","2","Esto se ilumina, como mi corazon cuando te veo"},
        new string[]{"HTML <TR>","0","0","2","Ya se hacer TABLAS, ...como que esto no se utiliza"}, //30
        new string[]{"Flotar <DIV>","0","0","4","Todavia tengo pesadillas..."},
        new string[]{"GRID","0","0","3","AHORA SI SE HACER TABLAS¡¡¡¡¡¡"},
        new string[]{"Node.js","2","0","2","Hacer Paginas Web nunca fue tan sencillo"}, //33
        new string[]{"React-native","3","1","3","Sin un State no eres nada"},
        new string[]{"Javascript","3","2","4","¿ENSERIO TAMBIEN TENGO QUE PROGRAMAR EN HTML?"},
        new string[]{"MongoDB","2","4","3","¿Imposible de almacenar dices? Agarrame el cubata...."}, //36
    };
    public static Card CreateCard(int page){
        if(page>=0 && page < library.Length){
            try{
                int c = Int32.Parse(library[page][1]);
                int bbdd = Int32.Parse(library[page][2]);
                int html = Int32.Parse(library[page][3]);
                return new Card(library[page][0],c,bbdd,html,library[page][4]);
            }catch(Exception e){                ;
                Debug.Log(e);
            }
        }
        return new Card();
    }

    public static Card RandomCard(){
        return CreateCard(UnityEngine.Random.Range(0,library.Length));
    }

}