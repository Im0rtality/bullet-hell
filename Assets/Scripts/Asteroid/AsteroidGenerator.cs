using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AsteroidGenerator
{
	public static GameObject NewAsteroid (List<Material> materials, List<Mesh> meshes, Gradient dangerGrad, Vector3 position)
	{
		Material theMaterial = materials [Random.Range (0, materials.Count - 1)];
		Mesh theMesh = meshes [Random.Range (0, meshes.Count - 1)];

		GameObject obj = new GameObject ("Asteroid");
		obj.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
		obj.transform.position = position;

		MeshFilter filter = obj.AddComponent<MeshFilter> ();
		filter.mesh = theMesh;

		MeshRenderer renderer = obj.AddComponent<MeshRenderer> ();
		renderer.material = theMaterial;

		MeshCollider collider = obj.AddComponent<MeshCollider> ();
		collider.convex = true;
		collider.isTrigger = true;
		collider.sharedMesh = theMesh;

		AsteroidController ctrl = obj.AddComponent<AsteroidController> ();
		ctrl.dangerZone = 20f;
		ctrl.g = dangerGrad;

		Rigidbody rb = obj.AddComponent<Rigidbody> ();
		rb.mass = 0.2f;
		rb.drag = 0f;
		rb.angularDrag = 0f;
		rb.AddTorque (Random.rotation.eulerAngles * Random.Range (-2f, 2f));

		return obj;
	}
}
