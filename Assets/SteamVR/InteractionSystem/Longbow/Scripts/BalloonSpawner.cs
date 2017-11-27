//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Spawns balloons
//
//=============================================================================

using UnityEngine;
using System.Collections;
using System;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class BalloonSpawner : MonoBehaviour
	{
		public float minSpawnTime = 5f;
		public float maxSpawnTime = 15f;
        public int balloonsToSpawn = 30;
        private int spawnedBalloons = 0;
		private float nextSpawnTime;
		public GameObject balloonPrefab;

		public bool autoSpawn = false;
		public bool spawnAtStartup = true;

		public bool playSounds = true;
		public SoundPlayOneshot inflateSound;
		public SoundPlayOneshot stretchSound;

		public bool sendSpawnMessageToParent = false;

		public float scale = 1f;

		public Transform spawnDirectionTransform;
		public float spawnForce;

		public bool attachBalloon = false;

		public Balloon.BalloonColor color = Balloon.BalloonColor.Random;


		//-------------------------------------------------
		void Start()
		{
			if ( balloonPrefab == null )
			{
				return;
			}

			if ( autoSpawn && spawnAtStartup )
			{
				SpawnBalloon( color );
				nextSpawnTime =UnityEngine.Random.Range( minSpawnTime, maxSpawnTime ) + Time.time;
			}
		}


		//-------------------------------------------------
		void Update()
		{
			if ( balloonPrefab == null )
			{
				return;
			}

			if ( ( Time.time > nextSpawnTime ) && autoSpawn && spawnedBalloons + 1 <= balloonsToSpawn )
			{
				SpawnBalloon( color );
				nextSpawnTime = UnityEngine.Random.Range( minSpawnTime, maxSpawnTime ) + Time.time;
                spawnedBalloons++;
			}
		}


		//-------------------------------------------------
		public GameObject SpawnBalloon( Balloon.BalloonColor color = Balloon.BalloonColor.Red )
		{
            autoSpawn = true;

			if ( balloonPrefab == null )
			{
				return null;
			}
			GameObject balloon = Instantiate( balloonPrefab, transform.position, transform.rotation ) as GameObject;
			balloon.transform.localScale = new Vector3( scale, scale, scale );
			if ( attachBalloon )
			{
				balloon.transform.parent = transform;
			}

			if ( sendSpawnMessageToParent )
			{
				if ( transform.parent != null )
				{
					transform.parent.SendMessage( "OnBalloonSpawned", balloon, SendMessageOptions.DontRequireReceiver );
				}
			}

			if ( playSounds )
			{
				if ( inflateSound != null )
				{
					inflateSound.Play();
				}
				if ( stretchSound != null )
				{
					stretchSound.Play();
				}
			}
			balloon.GetComponentInChildren<Balloon>().SetColor( color );
			if ( spawnDirectionTransform != null )
			{
				balloon.GetComponentInChildren<Rigidbody>().AddForce( spawnDirectionTransform.forward * spawnForce );
			}

			return balloon;
		}


		//-------------------------------------------------
		public void SpawnBalloonFromEvent( int color )
		{
            //int balloonsToSpawn = 30;
            //for (int i = 0; i < balloonsToSpawn; i++)
            //{

                //Copy of SpawnBalloon using int because we can't pass in enums through the event system

            SpawnBalloon( (Balloon.BalloonColor)color );
                //StartCoroutine(WaitForSpawn());
            //}
        }

        

        //IEnumerator  WaitForSpawn()
        //{
        //    yield return new WaitForSeconds(0.25f);
        //}
    }
}
