using UnityEngine;
using Character.Base;
using Character.Base.Dataset;
using Zombie.Function;
using Zombie.Update;
using Zombie.Dataset;

namespace Zombie {
    public class ZombieControl : MonoBehaviour, ICharacterControl {
        [Header("SubComponens")]
        public ZombieSetup ZombieSetup;
        public ZombieFunctionProcessor ZombieFunctionProcessor;
        public ZombieUpdateProcessor ZombieUpdateProcessor;
        public ZombieQueryProcessor ZombieQueryProcessor;
        public BoxCollider BOX_COLLIDER {
            get {
                if (_rootCollider == null) {
                    _rootCollider = GetComponent<BoxCollider>();
                }
                return _rootCollider;
            }
        }
        private BoxCollider _rootCollider;

        public ZombieDataset DATASET {
            get {
                if (_zombieDataset == null) {
                    _zombieDataset = GetComponent<ZombieDataset>();
                }
                return _zombieDataset;
            }
        }

        private ZombieDataset _zombieDataset;
        IDataset ICharacterControl.DATASET => DATASET;

        public Rigidbody RIGID_BODY {
            get {
                if (_rigidBody == null) {
                    _rigidBody = GetComponent<Rigidbody>();
                }
                return _rigidBody;
            }
        }
        private Rigidbody _rigidBody;

        public Animator ANIMATOR {
            get {
                if (_animator == null) {
                    _animator = GetComponentInChildren<Animator>();
                }
                return _animator;
            }
        }
        private Animator _animator;

        public Vector2 MOVE => throw new System.NotImplementedException();

        public void InitializeCharacter() {
            RunFunction(typeof(InitZombie), this);

            ZombieUpdateProcessor.InitUpdaters();
        }
        public void CharacterUpdate() {
            ZombieUpdateProcessor.RunCharacterUpdate();
        }

        public void CharacterFixedUpdate() {
            ZombieUpdateProcessor.RunCharacterFixedUpdate();
        }

        public void CharacterLateUpdate() {
            ZombieUpdateProcessor.RunCharacterLateUpdate();
        }

        public void RunGlobalFunction(System.Type type) {
            ZombieFunctionProcessor.DicGlobalFunctions[type].RunGlobalFunction();
        }

        public void RunFunction(System.Type type, ZombieControl zombieControl) {
            if (ZombieFunctionProcessor == null) {
                ZombieFunctionProcessor = GetComponentInChildren<ZombieFunctionProcessor>();
            }
            ZombieFunctionProcessor.DicFunctions[type].RunFunction(zombieControl);
        }

        public void RunFunction(System.Type type) {
            ZombieFunctionProcessor.DicFunctions[type].RunFunction();
        }
    }
}
