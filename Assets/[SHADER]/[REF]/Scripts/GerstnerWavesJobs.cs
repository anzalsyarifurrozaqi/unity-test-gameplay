using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine.Rendering.Universal;
using WaterSystem.Data;

namespace WaterSystem {
    public class GerstnerWaveJobs {
        public static bool Initialized;
        private static bool _firstFrame = true;
        private static bool _processing;
        private static bool _waveCount;
        private static NativeArray<Wave> _waveData; // Wave data from the water system

        // Details for Buoyant
        private static NativeArray<float3> _positions;
        private static int _positionsCount;
        private static NativeArray<float3> _wavePos;
        private static NativeArray<float3> _waveNormal;
        private static JobHandle _waterHeightHandle;
        static readonly Dictionary<int, int2> Registry = new Dictionary<int, int2>();

        public static void Init() {

        }

        public static void Cleanup() {

        }

        public static void UpdateSamplePoints(ref NativeArray<float3> samplePoints, int guid) {

        }

        public static void GetData(int guid, ref float3[] outPos, ref float3[] outNorm) {

        }

        public static void UpdateHeight() {

        }

        private static void CompleteJobs() {

        }

        // Gerstner Heigh C# Job
        [BurstCompile]
        private struct HeightJob : IJobParallelFor {
            [ReadOnly]
            public NativeArray<Wave> WaveData; // wave data stored in vec4's like the shader version but packed into one
            [ReadOnly]
            public NativeArray<float3> Position;

            [WriteOnly]
            public NativeArray<float3> OutPosition;
            [WriteOnly]
            public NativeArray<float3> OutNormal;

            [ReadOnly]
            public float Time;
            [ReadOnly]
            public int2 OffsetLength;

            // The Code actually running on the job
            public void Execute(int index)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}