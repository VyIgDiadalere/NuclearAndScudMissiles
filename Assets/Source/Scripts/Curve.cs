using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Scripts
{
    public class Curve : MonoBehaviour
    {
        [SerializeField] private Transform _lowerA;
        [SerializeField] private Transform _positionA;
        [SerializeField] private Transform _positionB;
        [SerializeField] private Transform _lowerB;
        [SerializeField] private Transform _upperPosition;

        public Vector3 Evaluate(float t)
        {
            Vector3 p0 = _lowerA.position;
            Vector3 p1 = _positionA.position;
            Vector3 p2 = _upperPosition.position;
            Vector3 p3 = _positionB.position;
            Vector3 p4 = _lowerB.position;
            
            Vector3 a = Vector3.Lerp(p0, p1, t);
            Vector3 b = Vector3.Lerp(p1, p2, t);
            Vector3 c = Vector3.Lerp(p2, p3, t);
            Vector3 d = Vector3.Lerp(p3, p4, t);
            
            Vector3 ab = Vector3.Lerp(a, b, t);
            Vector3 bc = Vector3.Lerp(b, c, t);
            Vector3 cd = Vector3.Lerp(c, d, t);
            
            Vector3 abbcc = Vector3.Lerp(ab, bc, t);
            Vector3 bccd = Vector3.Lerp(bc, cd, t);
            
            return Vector3.Lerp(abbcc, bccd, t);
        }
        
        private void OnDrawGizmos()
        {
            if (_positionA == null || _positionB == null || _upperPosition == null)
            {
                return;
            }
                
            for (int i = 0; i < 20; i++)
            {
                Gizmos.DrawWireSphere(Evaluate(i / 20f), 0.5f);
            }
        }
    }
}
