using CodeMonkey.Utils;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Grid grid;
    private void Start()
    { 
        grid = new Grid(4, 4, 20, Vector3.zero);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(),55);
        }
    }
}