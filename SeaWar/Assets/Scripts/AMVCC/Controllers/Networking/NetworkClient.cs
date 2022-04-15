using System.Collections.Generic;
using UnityEngine;
using SocketIO;
namespace AMVCC.Controllers.Networking
{
    public class NetworkClient : SocketIOComponent
    {
        [Header("Network Client")] 
        [SerializeField] private Transform networkContainer;

        [SerializeField] private GameObject playerPrefab;
        public static string ClientID {get; private set;}

        private Dictionary<string, NetworkIdentity> serverObjects;
        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();
            Initialize();
            SetUpEvents();
        }

        private void Initialize()
        {
            serverObjects = new Dictionary<string, NetworkIdentity>();
        }

        private void SetUpEvents()
        {
            On("open", (E) => { Debug.Log("connection made to the server"); });
            On("register", (E) =>
            {
                ClientID = E.data["id"].ToString();
                Debug.LogFormat("Our Clients ID ({0})", ClientID);
            });
            On("spawn", (E) =>
            {
                string id = E.data["id"].ToString();
                GameObject go = Instantiate(playerPrefab,networkContainer);
                go.name = string.Format("Player ({0})" + id);
                NetworkIdentity ni = go.GetComponent<NetworkIdentity>();
                ni.SetControllerID(id);
                ni.SetSocketReference(this);
                serverObjects.Add(id,ni);
            });
            On("disconnected" , (E) =>
            {
                string id = E.data["id"].ToString();
                GameObject go = serverObjects[id].gameObject;
                Destroy(go);
                serverObjects.Remove(id);
                
            });
            On("updatePosition", (E) =>
            {
                string id = E.data["id"].ToString();
                float x = E.data["position"]["x"].f;
                float y = E.data["position"]["y"].f;
                float z = E.data["position"]["z"].f;
                NetworkIdentity ni = serverObjects[id];
                ni.transform.position = new Vector3(x,y,z);

            });
            
        }


        public override void Update()
        {
            base.Update();
        }
    }
}
