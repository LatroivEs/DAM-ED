using System.Collections.Generic;
using UnityEngine;

public class Equipo
{
    private string InternalName;
    public int[] Cartas;

    public TypoEquipo Typo;

    public string Name;
    public string Imagen;

    private ModEquipo Mod;
    private List<Card> ListaCartas;

    public Equipo(string name, int[] cartas, string imagen, TypoEquipo typo){
        this.InternalName=name;
        this.Cartas=cartas;
        this.Imagen= imagen;
        this.Typo = typo;
    }

    public void AddMod(ModEquipo newMod){
        this.Mod = newMod;
        ListaCartas = new List<Card>();
        ListaCartas.Add(CardLibrary.CreateCard(Cartas[0]));
        ListaCartas.Add(CardLibrary.CreateCard(Cartas[1]));
        ListaCartas.Add(CardLibrary.CreateCard(Mod.Carta));
        Name = InternalName+" "+newMod.Name;
    }

    public List<Card> GetCards(){
        return ListaCartas;
    }

}