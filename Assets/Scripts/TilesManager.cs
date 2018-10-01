using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [Range(1, 10)]
    public int Size = 1;

    [Range( 0.0f, 1.0f)]
    public float DistanceBetweenTwoCells = 0.1f;
    List<Hexa> hexas = new List<Hexa>();

    void Start()
    {
        generateTiles();            
    }

    void generateTiles()
    {
        //up
        int upSize = Size + 1;
        for (int j = 1; j <= Size; j++)
        {
            for (int i = 0; i <= upSize; i++)
            {
                GameObject hexa = new GameObject("Hexa", typeof(Hexa));
                hexa.transform.position = new Vector3( (Hexa.OUTER_RADIUS) * i - (Hexa.OUTER_RADIUS) * (upSize * 0.5f), 
                                                       0.0f, 
                                                       (Hexa.INNER_RADIUS) * j);
            }
            upSize--;
        }

        //center
        for (int i = -Size; i < Size + 1; i++)
        {
            GameObject hexa = new GameObject("Hexa", typeof(Hexa));
            hexa.transform.position = new Vector3( ( Hexa.OUTER_RADIUS) * i, 0.0f, 0.0f);
        }

        //down
        int downSize = Size + 1;
        for (int j = 1; j <= Size; j++)
        {
            for (int i = 0; i <= downSize; i++)
            {
                GameObject hexa = new GameObject("Hexa", typeof(Hexa));
                hexa.transform.position = new Vector3( (Hexa.OUTER_RADIUS) * i - (Hexa.OUTER_RADIUS) * (downSize * 0.5f),
                                                       0.0f,
                                                       ( -Hexa.INNER_RADIUS) * j);
            }
            downSize--;
        }
    }
}
