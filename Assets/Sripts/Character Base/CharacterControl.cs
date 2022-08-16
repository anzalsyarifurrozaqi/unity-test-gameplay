using UnityEngine;
using Dataset;
using Character.Function;
using Character.Query;
using Character.Update;

namespace Character
{
    public class CharacterControl : MonoBehaviour {

        void OnAnimationMove() {
            Debug.Log("test");
        }
        [Header("Debug Object")]
        public GameObject target;

        [Header("Input")]
        public Vector2 Move;
        public bool Attack;
        public bool Dash;

        [Header("SubComponens")]
        public CharacterSetup characterSetup;
        public CharacterFunctionProcessor characterFunctionProcessor;
        public CharacterUpdateProcessor characterUpdateProcessor;
        public CharacterQueryProcessor characterQueryProcessor;

        public Datasets DATASET
        {
            get
            {
                if (_characterDatasets == null)
                {
                    _characterDatasets = GetComponent<Datasets>();                    
                }

                return _characterDatasets;
            }
        }

        private Datasets _characterDatasets;

        public Rigidbody RIGID_BODY
        {
            get
            {
                if (_rigidBody == null)
                {
                    _rigidBody = GetComponent<Rigidbody>();
                }

                return _rigidBody;
            }
        }

        private Rigidbody _rigidBody;

        public Animator ANIMATOR
        {
            get
            {
                if (_skinnedMeshAnimator == null)
                {
                    _skinnedMeshAnimator = GetComponentInChildren<Animator>();
                }

                return _skinnedMeshAnimator;
            }
        }
        private Animator _skinnedMeshAnimator;

        public BoxCollider BOX_COLLIDER
        {
            get
            {
                if (_rootCollider == null)
                {
                    _rootCollider = GetComponent<BoxCollider>();
                }

                return _rootCollider;
            }
        }
        private BoxCollider _rootCollider;        

        public CharacterUpdate GetUpdater(System.Type UpdaterType)
        {
            if (characterUpdateProcessor.DicUpdaters.ContainsKey(UpdaterType))
            {
                return characterUpdateProcessor.DicUpdaters[UpdaterType];
            }
            else
            {
                return null;
            }
        }
        
        public void InitalizeCharacter()
        {
            RunFunction(typeof(InitCharacter), this);

            characterUpdateProcessor.InitUpdaters();
        }

        public void CharacterUpdate()
        {            
            characterUpdateProcessor.RunCharacterUpdate();
        }

        public void CharacterFixedUpdate()
        {
            characterUpdateProcessor.RunCharacterFixedUpdate();
        }
        public void CharacterLateUpdate()
        {
            characterUpdateProcessor.RunCharacterLateUpdate();
        }        

        #region Functions
        public void RunFunction(System.Type FunctionType) {
            characterFunctionProcessor.DicFunctions[FunctionType].RunFunction();
        }
        public void RunFunction(System.Type FunctionType, CharacterControl characterControl)
        {
            if (characterFunctionProcessor == null)
            {
                characterFunctionProcessor = GetComponentInChildren<CharacterFunctionProcessor>();                
            }
            
            characterFunctionProcessor.DicFunctions[FunctionType].RunFunction(characterControl);
        }

        public void RunFunction(System.Type FunctionType, float value) {
            characterFunctionProcessor.DicFunctions[FunctionType].RunFunction(value);
        }

        public void RunFunction(System.Type FunctionType, Vector2 vector2) {
            characterFunctionProcessor.DicFunctions[FunctionType].RunFunction(vector2);
        }
        #endregion

        #region Queries
        #endregion        
    }
}