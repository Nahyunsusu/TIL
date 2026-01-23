using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    private Coroutine _fooCoroutine;

    private void Start()
    {
        //StartCoroutine(Foo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_fooCoroutine == null)
                _fooCoroutine = StartCoroutine(Foo());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_fooCoroutine != null)
            {
                StopCoroutine(_fooCoroutine);
                _fooCoroutine = null;
            }
        }

    }

    private IEnumerator Foo()
    {
        Debug.Log("Foo 실행");

        while (true)
        {
            yield return YieldContainer.WaitForSeconds(1.5f);
            Debug.Log("Foo 실행중");
        }
    }

}
