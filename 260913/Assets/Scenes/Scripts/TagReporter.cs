
using UnityEngine;

public class TagReporter : MonoBehaviour
{
    private void Start()
    {
        ReportCount();
        
    }

    private void Update()
    {
        ResetTagCount();
    }

    private void ReportCount()
    {
        CubeTag.GetTagCount();
    }

    private void ResetTagCount()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            CubeTag.ResetTagCount();
        }
    }
}
