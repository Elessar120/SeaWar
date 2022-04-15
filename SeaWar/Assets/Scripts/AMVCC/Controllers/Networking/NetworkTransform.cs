﻿using System;
using AMVCC.Controllers.Player;
using UnityEngine;
using Utiliti.Attributes;

namespace AMVCC.Controllers.Networking
{
    [RequireComponent(typeof(NetworkIdentity))]
    public class NetworkTransform : MonoBehaviour
    {
        [SerializeField] [GreyOut] private Vector3 oldPosition;
        private NetworkIdentity networkIdentity;
        private Player.Player player;
        private float stillCounter = 0;

        private void Start()
        {
            oldPosition = transform.position;
            networkIdentity = GetComponent<NetworkIdentity>();
            player = new Player.Player();
            player.position = new Position();
            player.position.x = 0;
            player.position.y = 0;
            player.position.z = 0;
            if (!networkIdentity.IsControlling())
            {
                enabled = false;
            }
        }

        public void Update()
        {
            if (networkIdentity.IsControlling())
            {
                if (oldPosition != transform.position)
                {
                    oldPosition = transform.position;
                    stillCounter = 0;
                    SendData();
                }
                else
                {
                    stillCounter += Time.deltaTime;
                    if (stillCounter >= 1)
                    {
                        stillCounter = 0;
                        SendData();
                    }
                }
            }
        }
        private void SendData()
        {
            player.position.x = Mathf.Round(transform.position.x * 1000.0f) / 1000.0f;
            player.position.y = Mathf.Round(transform.position.y * 1000.0f) / 1000.0f;
            player.position.z = Mathf.Round(transform.position.z * 1000.0f) / 1000.0f;
            networkIdentity.GetSocket().Emit("updatePosition", new JSONObject(JsonUtility.ToJson(player)));
        }
    }
}