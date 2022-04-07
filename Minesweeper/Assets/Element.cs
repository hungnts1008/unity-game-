using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour
{
    public bool mine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    private int x;
    private int y;

    void Start()
    {
        mine = Random.value < 0.15;
        x = (int)transform.position.x;
        y = (int)transform.position.y;
        Playfield.elements[x, y] = this;

    }
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        //ShowLog();

        if (mine)
        { 
            Playfield.uncoverMines();
            print("you lose");
        }
        else
        {
            loadTexture(Playfield.adjacentMines(x, y));
            Playfield.FFuncover(x, y, new bool[Playfield.w, Playfield.h]);
            if (Playfield.isFinished())   print("you win");
        }
    }
    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }
}