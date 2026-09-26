using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeQueue : MonoBehaviour
{
    [SerializeField] private float _intervalSeconds = 1f;

    private Queue<string> _notices = new Queue<string>();
    private float _elapsed;

    private void Start()
    {
        SendStartNotices();
    }

    private void Update()
    {
        CountInterval();
    }

    public void Send(string notice)
    {
        _notices.Enqueue(notice);
        Debug.Log($"NoticeQueue: 담음 {notice}, 대기 {_notices.Count}");
    }

    private void SendStartNotices()
    {
        Send("퀘스트를 받았습니다");
        Send("레벨이 올랐습니다");
        Send("새 스킬을 배웠습니다");
    }

    private void CountInterval()
    {
        _elapsed += Time.deltaTime;

        if (_elapsed >= _intervalSeconds)
        {
            _elapsed = 0f;
            ShowNext();
        }
    }

    private void ShowNext()
    {
        if (_notices.Count > 0)
        {
            string notice = _notices.Dequeue();
            Debug.Log($"NoticeQueue: 처리 {notice}, 남은 대기 {_notices.Count}");
        }
    }
}
