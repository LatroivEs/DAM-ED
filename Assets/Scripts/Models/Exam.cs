public class Exam
{
    private string name;
    private int c;
    private int bbdd;
    private int html;
    private string description;


    public Exam(string name, int c, int bbdd, int html, string description){
        this.name = name;

        this.c= c;
        this.bbdd=bbdd;
        this.html=html;

        this.description= description;
    }

    public Exam Clone(){
        return new Exam(this.name, this.c, this.bbdd, this.html, this.description);
    }
}