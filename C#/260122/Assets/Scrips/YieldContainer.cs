using System.Collections.Generic;
using UnityEngine;

public static class YieldContainer
{
    // 이미 생성된 WaitForSeconds 객체들을 저장하는 저장소
    private static readonly Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        // 딕셔너리에 해당 시간이 없으면 새로 만들어서 저장하고, 있으면 있는 것을 반환
        if (!_timeInterval.TryGetValue(seconds, out var waitForSeconds))
        {
            waitForSeconds = new WaitForSeconds(seconds);
            _timeInterval.Add(seconds, waitForSeconds);
        }
        return waitForSeconds;
    }
}