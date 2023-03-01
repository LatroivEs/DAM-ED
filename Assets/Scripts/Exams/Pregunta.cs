public class Pregunta(){
    public int c;
    public int bbdd;
    public int html;

    public int exce;

    public string pregunta;

    public Pregunta(int c, int bbdd, int html, string preg){
        this.c=c;
        this.bbdd= bbdd;
        this.html= html;

        this.Pregunta= preg;
        exce = c+bbdd+html+2;
    }
}