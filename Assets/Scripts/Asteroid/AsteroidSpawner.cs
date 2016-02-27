using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
	public List<Material> materials = new List<Material> ();
	public List<Mesh> meshes = new List<Mesh> ();
	public float interval = 2;
	public float area = 0;
	public Gradient dangerGradient;

	void Start ()
	{
		InvokeRepeating ("Spawn", 0f, interval + Random.Range (-0.5f, 0.5f));
	}

	void Spawn ()
	{
		Vector3 spawnPosition = area * Random.onUnitSphere + transform.position;

		AsteroidGenerator.NewAsteroid (materials, meshes, dangerGradient, spawnPosition);
	}
}
