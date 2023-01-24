using UnityEngine;
using System.Collections.Generic;

namespace AttackManager {
    public class AttackManager : Singleton<AttackManager> {
        public List<AttackCondition> CurrentCondition = new List<AttackCondition>();

        public void addCurrentCondition(AttackCondition attackCondition) {
            CurrentCondition.Add(attackCondition);
        }
    }
}
    
