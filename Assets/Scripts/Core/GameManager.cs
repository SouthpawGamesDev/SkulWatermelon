using SkulWatermelon.Model;
using UnityEngine;

namespace SkulWatermelon.Core
{

    public class GameManager : Singletons.Singleton<GameManager>
    {
        [field: SerializeField]
        public GameResourceManager GameResourceManager { get; private set; }

        [SerializeReference, SubclassSelector]
        public IInput input;
    }
}
