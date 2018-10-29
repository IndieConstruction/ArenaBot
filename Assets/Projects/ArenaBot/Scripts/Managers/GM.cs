using System;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Units;
using CSToU.UI;

namespace CSToU.Core {

    public class GM : MonoBehaviour {

        #region Properties

        public UnitManager MngUnit { get { return mngUnit; }  }
        protected UnitManager mngUnit;

        public TextBox TextBoxFactionCounter;

        public AppConfiguration CurrentConfiguration;

        #endregion

        #region Sigleton
        public static GM I {
            get { return _instance; }
            set { _instance = value; }
        }
        private static GM _instance;
        #endregion

        #region Lifecycle
        private void Awake() {
            if (I == null) {
                I = this;
                DontDestroyOnLoad(this);
            } else {
                Destroy(this);
            }
        }

        void Start() {
            Setup();
        }
        #endregion

        #region Setup

        /// <summary>
        /// Logiche di setup dall'applicazione.
        /// </summary>
        void Setup() {
            // Evento pre setup
            if (GlobalEventManager.OnPreSetup != null)
                GlobalEventManager.OnPreSetup();
            // TODO: setup
            Debug.Log("Setup del GameManger");
            setupSpawnPoints();
            mngUnit = new UnitManager();
            // Evento setup done
            if (GlobalEventManager.OnPostSetup != null)
                GlobalEventManager.OnPostSetup();

            if (GlobalEventManager.OnGMSetupFinished != null)
                GlobalEventManager.OnGMSetupFinished();
        }

        #endregion

        #region SpawnPoints

        List<Vector3> spawnPositions = new List<Vector3>();

        void setupSpawnPoints() {
            GameObject[] SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

            for (int i = 0; i < SpawnPoints.Length; i++) {
                spawnPositions.Add(SpawnPoints[i].transform.position);
            }
             
        }

        /// <summary>
        /// Restituisce una posizione casuale tra quelle previste tra gli spawnpoints.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomSpownPosition(Vector3 positionToAvoid) {
            Vector3 returnValue = positionToAvoid;
            do {
                returnValue = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];

            } while (returnValue == positionToAvoid);
            return returnValue;
        }

        #endregion

    }

    [Serializable]
    public class AppConfiguration {

        public string AppName = "Arena Bot";
        public string AppVersion = "0.1";

        [Header("Factions")]
        public int TotalUnits = 10;
        public GameObject UnitPrefab;
        public List<string> Factions = new List<string>();
        public List<Color> FactionColors;

        [Header("Timing")]
        public float WaitTimeAverage = 1.5f;
        public float WaitTimeVariation = 1.5f;

        public float RotationSpeedAverage = 1.0f;
        public float RotationSpeedVariation = 0.5f;

        public float MoveSpeedAverage = 15.0f;
        public float MoveSpeedVariation = 3.5f;

    }    

}