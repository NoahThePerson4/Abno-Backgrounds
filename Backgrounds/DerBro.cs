using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backgrounds
{
    public class PassiveAbility_DerBamHeadShotM : PassiveAbilityBase
    {
        private AudioClip[] _oldEnemytheme;
        private SephirahType sephirah;
        public override void OnWaveStart()
        {
            Singleton<StageController>.Instance.AddEgoMapByAssimilation("Freischutz");
            SingletonBehavior<BattleCamManager>.Instance.SetCreatureFilter();
            MapManager component = Util.LoadPrefab("CreatureMaps/CreatureMap_Mountain", SingletonBehavior<BattleSceneRoot>.Instance.transform).GetComponent<MapManager>();
            SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject.mapBgm = component.mapBgm;
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.SetAllyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.ChangeAllyTheme(0);
            component.gameObject.SetActive(false);
        }
    }
}
