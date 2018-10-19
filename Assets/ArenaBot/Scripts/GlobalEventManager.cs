using CSToU.Units;

namespace CSToU.Core {

    /// <summary>
    /// Classe statica che contiene tutti gli event delegates di interesse pubblico per l'app.
    /// </summary>
    public static class GlobalEventManager {

        public delegate void GlobalEvent();

        /// <summary>
        /// Evento scatenato prima del setup del GM.
        /// </summary>
        public static GlobalEvent OnPreSetup;

        /// <summary>
        /// Evento scatenato dopo il setup del GM.
        /// </summary>
        public static GlobalEvent OnPostSetup;

        public static GlobalEvent OnGMSetupFinished;

        

        public static GlobalEvent OnPause;
        public static GlobalEvent OnPauseResume;

        public delegate void GlobalUnitEvent(UnitBase unit);

        public static GlobalUnitEvent OnUnitCollisionPositive;
        public static GlobalUnitEvent OnUnitCollisionNegative;
    }
}
