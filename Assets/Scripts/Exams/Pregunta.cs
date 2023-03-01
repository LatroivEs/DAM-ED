public class Pregunta{

    public int c;
    public int bbdd;
    public int html;
    public int tipo;

    public int exce;

    public string pregunta;

    public Pregunta(int c, int bbdd, int html, string preg, int indice){
        this.c=c;
        this.bbdd= bbdd;
        this.html= html;
        this.tipo = indice;

        this.pregunta= preg;
        exce = c+bbdd+html+2;
    }
}