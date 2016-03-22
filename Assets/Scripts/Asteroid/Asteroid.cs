using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour
{
	private GameObject player;
	public Gradient g;
	public float dangerZone = 20f;
	public List<Material> materials = new List<Material> ();
	public List<Mesh> meshes = new List<Mesh> ();

	void Start ()
	{
		Material theMaterial = materials [Random.Range (0, materials.Count - 1)];
		Mesh theMesh = meshes [Random.Range (0, meshes.Count - 1)];

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		filter.mesh = theMesh;

		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer> ();
		renderer.sharedMaterial = theMaterial;

		MeshCollider collider = gameObject.AddComponent<MeshCollider> ();
		collider.convex = true;
		collider.isTrigger = true;
		collider.sharedMesh = theMesh;	

		player = GameObject.Find ("Player");
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * 0.5f;
	}

	void Update ()
	{
		if (player != null) {
			Color cl;
			float distance = Vector3.Distance (player.transform.position, gameObject.transform.position);
			if (distance < dangerZone) {
				cl = g.Evaluate (distance / dangerZone);
			} else {
				cl = Color.white;
			}
			gameObject.GetComponent<Renderer> ().material.color = cl;
		}
	}

	void onCleanupRange ()
	{
		if (player != null) {
			ScoreManager.score += 1;
		}
	}

	void DoExplode ()
	{
		ScoreManager.score += 1000;
	}
}
