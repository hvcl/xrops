using System.Collections;

using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;


public class tempCapture : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    public string key = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator sendActionTrue()
    {

        string url = "https://vience.io:6040/holoSensor/sensor/action/true/" + key;
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
            webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + webRequest.error);


        }
        else
        {
            Debug.Log("good");
        }
    }


    public void generateSign()
    {
        //text.text += "air tap";
        StartCoroutine(sendActionTrue());

        // �޼� �Ǵ� �����տ� ���� �ε��� �հ��� ���� ��ġ�� ����
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
        {
            // �ε��� �հ��� ���� ��ġ�� ����Ͽ� ���ϴ� �۾� ����
            // ��: �ε��� �հ��� ���� ��ġ�� GameObject�� ��ġ
            //text.text += "\n" + pose.Position.ToString();
        }
        

    }
}
