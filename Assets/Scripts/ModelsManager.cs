using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelsManager : MonoBehaviour
{
    Mesh[] models;
    [SerializeField]
    MeshFilter _target;
    int modelIndex = 0;
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo($"{Application.dataPath}/Resources/Input");
        FileInfo[] files = dir.GetFiles("*.prefab");
        this.models = ModelsLoader(files);
        _target.mesh = models[modelIndex];
    }

    public void NextModel()
    {
        modelIndex++;
        if(modelIndex>=models.Length)
            modelIndex = 0;
        _target.mesh = models[modelIndex];
    }
    public void PrevModel()
    {
        modelIndex--;
        if(modelIndex<=0)
            modelIndex = models.Length-1;
        _target.mesh = models[modelIndex];
    }

    Mesh[] ModelsLoader(FileInfo[] files)
    {
        Mesh[] meshes;
        if (files.Length == 0)
        {
            meshes = new Mesh[0];
            Debug.LogWarning($"No object of type: prefab");
            return meshes;
        }
        meshes = new Mesh[files.Length];
        string fileName;
        for (int i = 0; i < files.Length; i++)
        {
            fileName = "Input/" + Path.GetFileNameWithoutExtension(files[i].Directory+"/"+files[i].Name);
            var prefab = Resources.Load(fileName) as GameObject;
            meshes[i] = prefab.GetComponent<MeshFilter>().sharedMesh;


        }
        return meshes;
    }
}
