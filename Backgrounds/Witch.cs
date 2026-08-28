using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgrounds
{
    public class PassiveAbility_WeeLasFriendsM : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            Singleton<StageController>.Instance.AddEgoMapByAssimilation("Latitia");
            SingletonBehavior<BattleCamManager>.Instance.SetCreatureFilter();
            MapManager component = Util.LoadPrefab("CreatureMaps/CreatureMap_BloodBath", SingletonBehavior<BattleSceneRoot>.Instance.transform).GetComponent<MapManager>();
            SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject.mapBgm = component.mapBgm;
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.SetAllyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.ChangeAllyTheme(0);
            component.gameObject.SetActive(false);
        }
    }
}
