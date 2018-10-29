using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Core;

namespace CSToU.Units {

    public class UnitManager {

        #region Properties

        /// <summary>
        /// Lista con i riferimenti a tutte le unità presenti nell'arena.
        /// </summary>
        List<UnitBase> units = new List<UnitBase>();

        public List<string> Factions { get { return factions; } }

        List<string> factions = new List<string>();

        #endregion

        #region Constructor

        public UnitManager() {
            for (int i = 0; i < GM.I.CurrentConfiguration.TotalUnits; i++) {
                UnitBase newUnit = GameObject.Instantiate<GameObject>(GM.I.CurrentConfiguration.UnitPrefab).GetComponent<UnitBase>();
                newUnit.CurrentFaction = GetRandomFaction();
            }
        }

        #endregion

        #region API
        public void UnitReady(UnitBase unitToAdd) {
            Debug.Log("Unit Ready " + unitToAdd.name);
            units.Add(unitToAdd);

            if (factions.Contains(unitToAdd.CurrentFaction) == false) {
                factions.Add(unitToAdd.CurrentFaction);
                GM.I.TextBoxFactionCounter.SetText(string.Format("Factions: {0}", factions.Count));
            }

        }

        public GameObject GetPrefab(UnitBase.Class unitBase) {
            GameObject returnGO = Resources.Load<GameObject>(@"Graphics\" + unitBase.ToString());
            return returnGO;
        } 
        #endregion

        #region Factions

        public List<Color> FactionColors { get { return GM.I.CurrentConfiguration.FactionColors; } }

        public Color GetColor(string factionName) {
            int index = -1;
            for (int i = 0; i < Factions.Count; i++) {
                if (Factions[i] == factionName) {
                    index = i;
                }
            }
            if (index < 0) {
                Debug.LogError("Facton " + factionName + " not found!");
                return Color.clear;
            }
            return FactionColors[index];
        }

        /// <summary>
        /// Restituisce il nome di una fazione scelta random tra quelle possibili.
        /// </summary>
        /// <returns></returns>
        private string GetRandomFaction() {
            return GM.I.CurrentConfiguration.Factions[UnityEngine.Random.Range(0, GM.I.CurrentConfiguration.Factions.Count)];
        }

        #endregion

    }
}