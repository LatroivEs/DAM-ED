public class Exam{
    private Pregunta[] ListaPreguntas = new Pregunta[5];
    private int indicePreguntas;

    public Exam(){
        indicePreguntas=0;
    }

    public bool AddPregunta(Pregunta pregunta){
        if(indicePreguntas>= ListaPreguntas.Length){
            return false;
        }
        ListaPreguntas[indicePreguntas++]= pregunta;
        return true;
    }

    public Pregunta[] GetListaPreguntas(){
        return ListaPreguntas;
    }

    public Pregunta GetPregunta(int indice){
        if(indice>=0 && indice<ListaPreguntas.Length){
            return ListaPreguntas[indice];
        }
        return ListaPreguntas[0];
    }
}