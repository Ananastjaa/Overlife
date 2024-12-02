using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float CameraYMin, CameraYMax, CameraXMin, CameraXMax;
    public int CurrentEnemyCounter;

    public IEnumerator EnemySpawnRoutine()
    {
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
