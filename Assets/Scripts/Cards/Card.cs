public class Card
{
    public string name;
    public int c;
    public int bbdd;
    public int html;
    public string description;


    public Card(string name, int c, int bbdd, int html, string description){
        this.name = name;

        this.c= c;
        this.bbdd=bbdd;
        this.html=html;

        this.description= description;
    }

    public Card(){

    }

    public Card Clone(){
        return new Card(this.name, this.c, this.bbdd, this.html, this.description);
    }
}