using UnityEngine;
using UnityEngine.UI;

public class ChangeGlassColor : MonoBehaviour
{


    public Color LiqueurColor;
    public Color TequilaColor;
    public Color ScotchColor;
    public Color BrandyColor;
    public Color WhiskeyColor;
    public Color VodkaColor;
    public Color TransparentColor;

    public Image[] Images;

    private int currentCount = 0;

    public void ClearCup()
    {
        foreach (var image in Images)
        {
            image.color = TransparentColor;
        }
        currentCount = 0;
    }

    public void Add(int id, int count)
    {
        Color tempColor;
        switch (id)
        {
            case 1:
                tempColor = WhiskeyColor;
                break;
            case 2:
                tempColor = TequilaColor;
                break;
            case 3:
                tempColor = VodkaColor;
                break;
            case 4:
                tempColor = ScotchColor;
                break;
            case 5:
                tempColor = BrandyColor;
                break;
            case 6:
                tempColor = LiqueurColor;
                break;
            default:
                tempColor = TransparentColor;
                break;
        }

        for (int i = currentCount; i < currentCount + count; i++)
        {
            Images[i].color = tempColor;
        }
        
        currentCount += count;
    }

}