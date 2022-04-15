using System;
using SocketIO;
using UnityEngine;
using Utiliti.Attributes;


namespace AMVCC.Controllers.Networking
{
    public class NetworkIdentity : MonoBehaviour
    {
        [Header("Helpful Values")] 
        [SerializeField]
        [GreyOut]
        private string id;
        [SerializeField]
        [GreyOut]
        private bool isControlling;

        private SocketIOComponent socket;

        private void Awake()
        {
            isControlling = false;
        }

        public void SetControllerID(string Id)
        {
            id = Id;
            isControlling = (NetworkClient.ClientID == id) ? true : false;// check incoming id versus the one we have saved from the server
        }

        public void SetSocketReference(SocketIOComponent Socket)
        {
            socket = Socket;
        }

        public string GetID()
        {
            return id;
        }

        public bool IsControlling()
        {
            return isControlling;
        }

        public SocketIOComponent GetSocket()
        {
            return socket;
        }
    }
}