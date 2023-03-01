public class Exam(){
    private Pregunta[] ListaPreguntas = new Pregunta[3];
    private int indicePreguntas;

    public Exam(){
        indicePreguntas=0;

    }

    public bool AddPregunta(Pregunta pregunta){
        if(indicePreguntas> ListaPreguntas.Length){
            return false;
        }
        ListaPreguntas[indicePreguntas++]= pregunta;
    }
}