using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSToU.Core;
using CSToU.Units;
using System.Linq;
using System;

namespace CSToU.UI {

    public class FactionsPointsCounter : MonoBehaviour {

        TextBox textBox;

        List<FactionPoints> points = new List<FactionPoints>();

        private void OnEnable() {
            GlobalEventManager.OnGMSetupFinished += Setup;
            GlobalEventManager.OnUnitCollisionPositive += OnPositiveCollision;
            GlobalEventManager.OnUnitCollisionNegative += OnNegativeCollision;
        }

        private void OnDisable() {
            GlobalEventManager.OnGMSetupFinished -= Setup;
            GlobalEventManager.OnUnitCollisionPositive -= OnPositiveCollision;
            GlobalEventManager.OnUnitCollisionNegative -= OnNegativeCollision;
        }

        private void Setup() {
            textBox = GetComponent<TextBox>();

            foreach (string faction in GM.I.MngUnit.Factions) {
                points.Add(new FactionPoints() { Faction = faction, Points = 0 });
            }

            updateTextbox();
        }

        void AddPointToFaction(string faction, int pointsToAdd = 1) {
            points.Find(fp => fp.Faction == faction).Points += pointsToAdd;
        }

        private void OnNegativeCollision(UnitBase unit) {
            AddPointToFaction(unit.CurrentFaction, -1);
            updateTextbox();
        }

        private void OnPositiveCollision(UnitBase unit) {
            AddPointToFaction(unit.CurrentFaction, +3);
            updateTextbox();
        }



        void updateTextbox() {
            string textToShow = "";

            foreach (FactionPoints point in points.OrderByDescending(fp => fp.Points)) {
                textToShow += string.Format("{0}: {1}{2}", point.Faction, point.Points, System.Environment.NewLine);
            }

            textBox.SetText(textToShow);
        }


        public class FactionPoints {
            public string Faction;
            public int Points;
        }
    }
}