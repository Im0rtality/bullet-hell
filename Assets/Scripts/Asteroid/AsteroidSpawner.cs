using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{
	public List<Material> materials = new List<Material> ();
	public List<Mesh> meshes = new List<Mesh> ();
	public float interval = 2;
	public float area = 0;
	public GameObject asteroidBase;

	void Start ()
	{
		InvokeRepeating ("Spawn", 0f, interval);
	}

	void Spawn ()
	{
		Vector3 spawnPosition = area * Random.onUnitSphere + transform.position;

		Material theMaterial = materials [Random.Range (0, materials.Count - 1)];
		Mesh theMesh = meshes [Random.Range (0, meshes.Count - 1)];

		GameObject obj = Instantiate (asteroidBase, spawnPosition, transform.rotation) as GameObject;

		MeshFilter filter = obj.AddComponent<MeshFilter> ();
		filter.mesh = theMesh;

		MeshRenderer renderer = obj.AddComponent<MeshRenderer> ();
		renderer.material = theMaterial;

		MeshCollider collider = obj.AddComponent<MeshCollider> ();
		collider.convex = true;
		collider.isTrigger = true;
		collider.sharedMesh = theMesh;	
	}
}
