using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler instance;
	[SerializeField] private GameObject pooledObject;
	[SerializeField] private int pooledAmount;
	[SerializeField] private bool willGrow;

	List<GameObject> pooledObjects;

	void Awake() {
		instance = this;	
	}
	
	void Start () {
		pooledObjects = new List<GameObject>();
		for(int i = 0; i < pooledAmount; i++)
			Create();
	}

	void Create(){
		GameObject obj = (GameObject) Instantiate(pooledObject, parent: transform);
		obj.SetActive(false);
		pooledObjects.Add(obj);
	}

	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeSelf){
				return pooledObjects[i];
			}
		}

		if(willGrow){
			GameObject obj = (GameObject) Instantiate(pooledObject, parent: transform);
			pooledObjects.Add(obj);
			return obj;
		}
		return null;
	}
    public void StopAllBalls()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeSelf)
            {
                pooledObjects[i].GetComponent<Rigidbody2D>().drag = 100;
            }
        }
    }
   

}
