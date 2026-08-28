using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backgrounds
{
    public class PassiveAbility_HeartLearnCheeseM : PassiveAbilityBase
    {
        private AudioClip[] _oldEnemytheme;
        private SephirahType sephirah;
        public override void OnWaveStart()
        {
            Singleton<StageController>.Instance.AddEgoMapByAssimilation("HeartOfAspiration");
            SingletonBehavior<BattleCamManager>.Instance.SetCreatureFilter();
            MapManager component = Util.LoadPrefab("CreatureMaps/CreatureMap_HeartOfAspiration", SingletonBehavior<BattleSceneRoot>.Instance.transform).GetComponent<MapManager>();
            SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject.mapBgm = component.mapBgm;
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.SetAllyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.ChangeAllyTheme(0);
            component.gameObject.SetActive(false);
        }
        public override void OnDie()
        {
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(_oldEnemytheme);
            Singleton<StageController>.Instance.RemoveEgoMapAll();
            SingletonBehavior<BattleSceneRoot>.Instance.ChangeToSephirahMap(sephirah, true);
        }
    }
}
