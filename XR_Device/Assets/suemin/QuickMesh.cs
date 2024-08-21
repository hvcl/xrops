using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class QuickMesh : MonoBehaviour
{
    void Start()
    {
        // JSON ���� ���
        string filePath = Path.Combine(Application.dataPath, "/suemin/mesh_data.json");
        if (File.Exists(filePath))
        {
            Debug.Log("file exist");
            // ���� �б�
            string dataAsJson = File.ReadAllText(filePath);
            // JSON �����͸� MeshData ��ü�� ��ȯ
            MeshData loadedData = JsonUtility.FromJson<MeshData>(dataAsJson);
            Debug.Log("loaded");

            CreateMesh(loadedData);
            Debug.Log("create mesh");

            /*
            Mesh mesh = new Mesh();

            mesh.vertices = loadedData.vertices.ToArray();
            mesh.triangles = faces;

            if (normals.Length < 1)
                mesh.RecalculateNormals();
            else
                mesh.normals = normals;

            int face_cnt = faces.Length;
            int num = face_cnt / 3;
            int[] wires = new int[num * 3 * 2];
            for (int iTria = 0; iTria < num; iTria++)
            {
                for (int iVertex = 0; iVertex < 3; iVertex++)
                {
                    wires[6 * iTria + 2 * iVertex] = faces[3 * iTria + iVertex];
                    wires[6 * iTria + 2 * iVertex + 1] = faces[3 * iTria + (iVertex + 1) % 3];
                }
            }

            bool isMade = false;
            GameObject MeshPrefab = null;
            


            if (isMade == false)
            {
                Vector3 pos = Camera.main.transform.position + Camera.main.transform.forward * 1;

                GameObject meshPrefab = Resources.Load("Marks/Mesh/MeshPrefab") as GameObject;
                if (meshPrefab == null)
                    Debug.Log("this is null");
                MeshPrefab = Instantiate(meshPrefab, pos, Quaternion.identity);
                MeshPrefab.name = trans_id.Trim(' ');

                MeshPrefab.transform.Find("Mesh").GetComponent<MeshFilter>().mesh = mesh;

                Mesh line_mesh = MeshPrefab.transform.Find("mesh_line").gameObject.GetComponent<MeshFilter>().mesh;
                line_mesh.vertices = points;
                line_mesh.SetIndices(wires, MeshTopology.Lines, 0);
                line_mesh.normals = mesh.normals;

                renderedMeshes.Add(MeshPrefab);
            }
            // ���⼭ loadedData�� ����Ͽ� ���𰡸� �� �� ����*/
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }


    void CreateMesh(MeshData data)
    {
        Mesh mesh = new Mesh();

        // ������ �迭�� �����մϴ�.
        Vector3[] vertices = new Vector3[data.vertices.Count];
        for (int i = 0; i < data.vertices.Count; i++)
        {
            vertices[i] = new Vector3(data.vertices[i][0], data.vertices[i][1], data.vertices[i][2]);
        }
        mesh.vertices = vertices;

        // �ﰢ�� �迭�� �����մϴ�.
        mesh.triangles = data.faces.ToArray();

        // ������ ���� �迭�� �����մϴ� (�ɼ�).
        Vector3[] normals = new Vector3[data.verticesNormals.Count];
        for (int i = 0; i < data.verticesNormals.Count; i++)
        {
            normals[i] = new Vector3(data.verticesNormals[i][0], data.verticesNormals[i][1], data.verticesNormals[i][2]);
        }
        mesh.normals = normals;

        // �޽� ���� ������Ʈ�� ������ �޽��� �Ҵ��մϴ�.
        GetComponent<MeshFilter>().mesh = mesh;

        // �޽� �ݶ��̴��� �߰��ϰų� ������Ʈ�մϴ� (�ɼ�).
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        if (meshCollider == null)
        {
            meshCollider = gameObject.AddComponent<MeshCollider>();
        }
        meshCollider.sharedMesh = mesh;
    }
}

[System.Serializable]
public class MeshData
{
    public List<int> faces;
    public List<List<float>> vertices;
    public List<List<float>> verticesNormals;
}
