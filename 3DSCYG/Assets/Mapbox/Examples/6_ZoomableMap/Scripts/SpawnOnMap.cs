﻿namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		[Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;

		List<GameObject> _spawnedObjects;
		
		// [SerializeField]
		// GameObject _eventPrefab;

		// [SerializeField]
		// float _maxEvents = 3;
		 
		// private float targetTime = 2.0f;
		
		// public float _spawnedEvents;
		
		void Start()
		{
			_locations = new Vector2d[_locationStrings.Length];
			_spawnedObjects = new List<GameObject>();
			for (int i = 0; i < _locationStrings.Length; i++)
			{
				var locationString = _locationStrings[i];
				_locations[i] = Conversions.StringToLatLon(locationString);
				var instance = Instantiate(_markerPrefab);

				//Workaround
				instance.GetComponent<MarcadorEvento>().eventPos = _locations[i];
				instance.GetComponent<MarcadorEvento>().eventID = i+1;

				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				_spawnedObjects.Add(instance);
			}
		}

		private void Update()
		{
			// targetTime -= Time.deltaTime;
			// if (targetTime < 0)
			// {
			// 	if (_spawnedEvents < 2) //Maximo de duas missoes na area
			// 	{
			// 		if (_spawnedEvents < _maxEvents) 
			// 		{
			// 			SpawnRandomMisson();
			// 			_spawnedEvents += 1;
			// 		}

			// 	} 
			// 	targetTime = Random.Range(3, 6);
			// 	//Debug.Log(targetTime);
			// }

			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			}
		}

		// Spawn random ball at random x position at top of play area
		//https://forum.unity.com/threads/how-to-spawn-at-random-times.1041733/
		// void SpawnRandomEvent()
		// {
		// 	//int RandEventID = Random.Range(0, 3);
		// 	//int MissonID = Random.Range(0, eventPrefabs.Length);
		// 	_locations = new Vector2d[_locationStrings.Length];

		// 	spawnedEvent = Instantiate(_eventPrefab);
		// 	spawnedEvent.GetComponent<MarcadorEvento>().eventPos =
		// 	spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
		// 	// instantiate ball at random spawn location
        	
			
		// }
	}
}