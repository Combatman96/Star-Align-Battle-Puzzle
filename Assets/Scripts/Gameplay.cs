using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private LayerMask m_tileLayer;
    [SerializeField] private Vector2Int m_boardSize;
    [SerializeField] private float m_distance;
    [SerializeField] private Transform m_boardOrigin;
    [SerializeField] private Tile m_tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBoard();
    }

    void SetUpBoard()
    {
        Vector2 origin = m_boardOrigin.position;
        for (int i = 0; i < m_boardSize.x; i++)
        {
            for (int j = 0; j < m_boardSize.y; j++)
            {
                Vector2 pos = new Vector2(i, j) * m_distance + origin;
                Tile tile = Instantiate(m_tilePrefab, pos, Quaternion.identity, transform);
                tile.DoStart();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero, 1000f, m_tileLayer);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit)
            {
                Tile tile = hit.transform.GetComponent<Tile>();
                tile.OnTileTapped();
            }
        }
    }
}
