using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsController : MonoBehaviour {

    private static int COLUMNS_DELAY_MIN = 150;
    private static int COLUMNS_DELAY_MAX = 200;

    private ArrayList columns;
    private int columnDelay;

    public GameObject prefab;

    private void Awake()
    {
        columns = new ArrayList();
        columnDelay = 0;
    }

    void Update()
    {
        if (!GameController.instance.gameOver && !GameController.instance.pauseGame) MoveColumns();
    }

    void MoveColumns()
    {
        columnDelay--;

        if (columnDelay < 0)
        {
            columnDelay = Random.Range(COLUMNS_DELAY_MIN, COLUMNS_DELAY_MAX);
            GameObject column = null;

            foreach (GameObject col in columns)
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
                columns.Add(column);
            }
        }
    }

    private Vector3 getPosition()
    {
        return new Vector3(GameController.instance.screenParametrs.x + 1f, Random.Range(-1.5f, 3.3f), -1.0f);
    }

    public void Reset(GameObject col)
    {
        col.transform.position = getPosition();
    }
}
