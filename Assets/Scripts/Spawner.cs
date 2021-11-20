using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] Sphere spherePrefab;
    private Sphere[] spheres;
    readonly int spawnCount = 10;
    private int counter = 0;
    [SerializeField] Button spawnButton;

    void Start()
    {
        spheres = new Sphere[spawnCount];
        Sphere sphere;
        for (int i = 0; i < spawnCount; i++)
        {
            sphere = Instantiate(spherePrefab, this.transform);
            spheres[i] = sphere;
        }

        spawnButton.onClick.AddListener(() => Spawn());
    }

    public void Spawn()
    {
        if (counter + 1 >= spawnCount) counter = 0;
        spheres[counter++].Spawn(); // Fake Spawn (Already spawned)
    }
}
