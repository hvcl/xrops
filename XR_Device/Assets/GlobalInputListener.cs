using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class GlobalInputListener : MonoBehaviour, IMixedRealityInputHandler
{
    private void OnEnable()
    {
        // �����ʸ� �Է� �ý��ۿ� ���
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityInputHandler>(this);
    }

    private void OnDisable()
    {
        // �Է� �ý��ۿ��� �����ʸ� ����
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityInputHandler>(this);
    }

    public void OnInputDown(InputEventData eventData)
    {
        // Air Tap�� �ش��ϴ� �׼� ID�� Ȯ��
        //if (eventData.MixedRealityInputAction == MixedRealityInputAction.Get(TouchScreenInputSourceType.Touch))
        //{
            // Air Tap ������
        //    Debug.Log("Air Tap Detected");
        //}
    }

    public void OnInputUp(InputEventData eventData)
    {
        // �� �޼���� ���������� ������ ������, �ʿ信 ���� ������ �� ����
    }
}
