using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgrounds
{
    public class PassiveAbility_RedShoesStepStompM : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            //You put the abnormality map you want here.
            Singleton<StageController>.Instance.AddEgoMapByAssimilation("RedShoes");
            SingletonBehavior<BattleCamManager>.Instance.SetCreatureFilter();
            //You then put the music you want here.
            //I used BloodBath for First Warning.
            MapManager component = Util.LoadPrefab("CreatureMaps/CreatureMap_BloodBath", SingletonBehavior<BattleSceneRoot>.Instance.transform).GetComponent<MapManager>();
            SingletonBehavior<BattleSceneRoot>.Instance.currentMapObject.mapBgm = component.mapBgm;
            SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.SetAllyTheme(component.mapBgm);
            SingletonBehavior<BattleSoundManager>.Instance.ChangeAllyTheme(0);
            component.gameObject.SetActive(false);
        }
    }
}
