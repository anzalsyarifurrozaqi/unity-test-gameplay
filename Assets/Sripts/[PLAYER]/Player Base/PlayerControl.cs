using UnityEngine;
using Character.Base;
using Dataset;
using Player.Function;
using Player.Query;
using Player.Update;
using Character.Base.Dataset;

namespace Player
{
    public class PlayerControl : MonoBehaviour, ICharacterControl {

        // void OnAnimationMove() {
        //     Debug.Log("test");
        // }
        [Header("Debug Object")]
        public GameObject target;

        [Header("Input")]
        public Vector2 Move;
        public Vector2 MOVE => Move;
        
        public Vector2 Look;
        public bool IsShoot;

        [Header("SubComponens")]
        public PlayerSetup PlayerSetup;
        public PlayerFunctionProcessor PlayerFunctionProcessor;
        public PlayerUpdateProcessor PlayerUpdateProcessor;
        public PlayerQueryProcessor PlayerQueryProcessor;

         public BoxCollider BOX_COLLIDER {
            get {
                if (_rootCollider == null) {
                    _rootCollider = GetComponent<BoxCollider>();
                }
                return _rootCollider;
            }
        }
        private BoxCollider _rootCollider;

        public PlayerDatasets DATASET {
            get {
                if (_zombieDataset == null) {
                    _zombieDataset = GetComponent<PlayerDatasets>();
                }
                return _zombieDataset;
            }
        }

        private PlayerDatasets _zombieDataset;
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


        // public PlayerUpdate GetUpdater(System.Type UpdaterType)
        // {
        //     if (PlayerUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
        //     {
        //         return PlayerUpdateProcessor.DicUpdaters[UpdaterType];
        //     }
        //     else
        //     {
        //         return null;
        //     }
        // }
        
        public void InitializeCharacter()
        {
            RunFunction(typeof(InitPlayer), this);

            PlayerUpdateProcessor.InitUpdaters();
        }

        public void CharacterUpdate()
        {            
            PlayerUpdateProcessor.RunCharacterUpdate();
        }

        public void CharacterFixedUpdate()
        {
            PlayerUpdateProcessor.RunCharacterFixedUpdate();
        }
        public void CharacterLateUpdate()
        {
            PlayerUpdateProcessor.RunCharacterLateUpdate();
        }        

        #region Functions
        public void RunGlobalFunction(System.Type FunctionType) {
            PlayerFunctionProcessor.DicGlobalFunctions[FunctionType].RunGlobalFunction();
        }
        public void RunGlobalFunction(System.Type FunctionType, float value1) {
            PlayerFunctionProcessor.DicGlobalFunctions[FunctionType].RunGlobalFunction(value1);
        }


        public void RunFunction(System.Type FunctionType) {
            PlayerFunctionProcessor.DicFunctions[FunctionType].RunFunction();
        }
        public void RunFunction(System.Type FunctionType, PlayerControl PlayerControl)
        {
            if (PlayerFunctionProcessor == null)
            {
                PlayerFunctionProcessor = GetComponentInChildren<PlayerFunctionProcessor>();                
            }
            
            PlayerFunctionProcessor.DicFunctions[FunctionType].RunFunction(PlayerControl);
        }

        public void RunFunction(System.Type FunctionType, float value) {
            PlayerFunctionProcessor.DicFunctions[FunctionType].RunFunction(value);
        }

        public void RunFunction(System.Type FunctionType, Vector2 vector2) {
            PlayerFunctionProcessor.DicFunctions[FunctionType].RunFunction(vector2);
        }

        public void RunFunction(System.Type FunctionType, Vector3 value, Quaternion value2) {
            PlayerFunctionProcessor.DicFunctions[FunctionType].RunFunction(value, value2);
        }
        #endregion

        #region Queries
        #endregion        
    }
}