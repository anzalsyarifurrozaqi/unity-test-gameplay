using UnityEngine;
using Character.Base;
using Character.Base.Dataset;
using Zombie.Function;

namespace Zombie {
    public class ZombieControl : MonoBehaviour, ICharacterControl {
        [Header("SubComponens")]
        public ZombieSetup ZombieSetup;
        public ZombieFunctionProcessor ZombieFunctionProcessor;
        public ZombieUpdateProcessor ZombieUpdateProcessor;
        public ZombieQueryProcessor ZombieQueryProcessor;
        public BoxCollider BOX_COLLIDER => throw new System.NotImplementedException();

        public IDataset DATASET => throw new System.NotImplementedException();

        public Rigidbody RIGID_BODY => throw new System.NotImplementedException();

        public Animator ANIMATOR => throw new System.NotImplementedException();

        public Vector2 MOVE => throw new System.NotImplementedException();

        public void InitializeCharacter() {
            throw new System.NotImplementedException();
        }
        public void CharacterUpdate() {
            throw new System.NotImplementedException();
        }

        public void CharacterFixedUpdate() {
            throw new System.NotImplementedException();
        }

        public void CharacterLateUpdate() {
            throw new System.NotImplementedException();
        }

    }
}
