using System.Collections;
using UnityEngine;

public class ColumnsController : MonoBehaviour 
{
    private static int COLUMNS_DELAY_MIN = 100;
    private static int COLUMNS_DELAY_MAX = 150;

    private static float COLUMNS_Y_MIN = -1.5f;
    private static float COLUMNS_Y_MAX = 3.3f;

    private static float COLUMNS_Z_POSITION = -1.0f;

    private ArrayList columnsArray;
    private int columnDelay;

    public GameObject prefab;

    private void Awake()
    {
        columnsArray = new ArrayList();
        columnDelay = 0;
    }

    void Update()
    {
        if (!GameManager.instance.gameOver && !GameManager.instance.pauseGame) 
            MoveColumns();
        if (GameManager.instance.restartGame)
            ResetColumns();
    }

    void MoveColumns()
    {
        columnDelay--;

        if (columnDelay < 0)
        {
            columnDelay = Random.Range(COLUMNS_DELAY_MIN, COLUMNS_DELAY_MAX);
            GameObject column = null;

            foreach (GameObject col in columnsArray)
            {
                if (col.transform.position.x < -13)
                {
                    column = col;
                    break;
                }
            }

            if (column)
            {
                Reset(column);
            }
            else
            {
                column = (GameObject)Instantiate(prefab, getPosition(), Quaternion.identity);
                columnsArray.Add(column);
            }
        }
    }

    private Vector3 getPosition()
    {
        return new Vector3(GameManager.instance.screenParametrs.x + 1f, Random.Range(COLUMNS_Y_MIN, COLUMNS_Y_MAX), COLUMNS_Z_POSITION);
    }

    private void Reset(GameObject col)
    {
        col.transform.position = getPosition();
    }

    public void ResetColumns()
    {
        foreach (GameObject col in columnsArray)
        {
            Destroy(col);
        }
        columnsArray = new ArrayList();
        columnDelay = 0;
    }

}
