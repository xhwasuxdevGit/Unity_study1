using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastStudy : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    [SerializeField] private float _checkDistance = 8f;

    private void Update()
    {
        DrawCheckRay();
        CheckSight();

    }

    private void DrawCheckRay()
    {
        Debug.DrawRay(transform.position, transform.forward * _checkDistance, Color.green);
    }

    private void CheckSight()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _checkDistance))
        {
            ReportSight(hit);
        }
    }

    private void ReportSight(RaycastHit hit)
    {
        if (hit.collider.CompareTag(TAG_PLAYER))
        {
            Debug.Log("sightChecker: 앞에서 플레이어를 봤습니다.");
        }
    }
}
