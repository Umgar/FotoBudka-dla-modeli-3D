using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelsManager : MonoBehaviour
{
    GameObject[] models;
    [SerializeField]
    Transform _target;
    int modelIndex = 0;
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo($"{Application.dataPath}/Resources/Input");
        FileInfo[] files = dir.GetFiles("*.prefab");
        this.models = ModelsLoader(files);
        models[0].SetActive(true);
        models[0].transform.SetParent(_target);
    }

    public void NextModel()
    {
        modelIndex++;
        if (modelIndex >= models.Length)
            modelIndex = 0;
        GameObject old = _target.GetChild(0).gameObject;
        old.SetActive(false);
        old.transform.SetParent(this.transform);
        models[modelIndex].SetActive(true);
        models[modelIndex].transform.SetParent(_target);
    }
    public void PrevModel()
    {
        modelIndex--;
        if (modelIndex < 0)
            modelIndex = models.Length - 1;
        GameObject old = _target.GetChild(0).gameObject;
        old.SetActive(false);
        old.transform.SetParent(this.transform);
        models[modelIndex].SetActive(true);
        models[modelIndex].transform.SetParent(_target);

    }

    GameObject[] ModelsLoader(FileInfo[] files)
    {
        GameObject[] meshes;
        if (files.Length == 0)
        {
            meshes = new GameObject[0];
            Debug.LogWarning($"No object of type: prefab");
            return meshes;
        }
        meshes = new GameObject[files.Length];
        string fileName;
        for (int i = 0; i < files.Length; i++)
        {
            fileName = "Input/" + Path.GetFileNameWithoutExtension(files[i].Directory + "/" + files[i].Name);
            var prefab = Resources.Load(fileName) as GameObject;
            meshes[i] = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, this.transform);
            meshes[i].SetActive(false);
        }
        return meshes;
    }
}
