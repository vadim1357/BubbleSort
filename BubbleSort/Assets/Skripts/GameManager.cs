using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public float minScale;
    public float maxScale;
    public MeshRenderer CubePrefab;
    int distance = 0;


    public MeshRenderer[] countCubes;
    private void Start()
    {
        RunBubbleSort();
    }
    public void RunBubbleSort()
    {

        for (int i = 0; i < countCubes.Length; i++)
        {
            Vector3 scale = new Vector3(1, Random.Range(minScale, maxScale), 1);
            Vector3 pos = new Vector3(i + distance, 0, 0);
            MeshRenderer curCube = Instantiate(CubePrefab, pos, Quaternion.identity) as MeshRenderer;
            curCube.transform.localScale = scale;

            countCubes[i] = curCube;
            distance++;


        }

        //Bubble();
        StartCoroutine(BubbleSortCoroutine());


    }


    IEnumerator BubbleSortCoroutine()
    {
        for (int i = 0; i < countCubes.Length; i++)
        {
            for (int j = i + 1; j < countCubes.Length; j++)
            {

                float yI = countCubes[i].transform.localScale.y;
                float yJ = countCubes[j].transform.localScale.y;


                if (yI > yJ)
                {

                    Vector3 cubeHelper = countCubes[i].transform.localPosition;
                    countCubes[i].transform.localPosition = countCubes[j].transform.localPosition;
                    countCubes[j].transform.localPosition = cubeHelper;
                    Color colorHelper = countCubes[i].material.color;
                    countCubes[i].material.color = Color.red;
                    MeshRenderer indHelper = countCubes[i];
                    countCubes[i] = countCubes[j];
                    countCubes[j] = indHelper;
                    yield return new WaitForSeconds(0.2f);
                    countCubes[j].material.color = colorHelper;
                }


            }
        }
    }
    public void Clear()
    {

        distance = 0;
        foreach (var x in countCubes)

        {
            Destroy(x.gameObject);
        }


    }
}





