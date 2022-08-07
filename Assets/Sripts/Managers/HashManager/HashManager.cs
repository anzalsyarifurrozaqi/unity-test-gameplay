using Enum;

namespace Manager {
    public class HashManager : Singleton<HashManager> {
        public int[] ArrMainParams = new int[HashTool.GetLength(typeof(MainParameterType))];

        private void Awake() {
            HashTool.AddNameHashToArray(typeof(MainParameterType), ArrMainParams);
        }
    }
}
