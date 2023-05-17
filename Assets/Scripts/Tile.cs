using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] List<Transform> m_marker = new List<Transform>();

    private int m_tapNum = 0;

    // Start is called before the first frame update
    public void DoStart()
    {
        m_tapNum = 0;
        ClearMarkers();
    }

    public void ClearMarkers()
    {
        foreach (var marker in m_marker)
        {
            marker.gameObject.SetActive(false);
        }
    }

    public void ShowMarker()
    {
        ClearMarkers();
        m_marker[m_tapNum].gameObject.SetActive(true);
    }

    public void OnTileTapped()
    {
        m_tapNum++;
        m_tapNum = m_tapNum % m_marker.Count;
        ShowMarker();
    }
}
