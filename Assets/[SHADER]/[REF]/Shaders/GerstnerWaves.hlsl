#ifndef GERSTNER_WAVES_INCLUDED
#define GERSTNER_WAVES_INCLUDED

uniform uint    _WaveCount; // how many waves, set via the water component

struct Wave {

};

#if defined(USE_STRUCTED_BUFFER)
StructuredBuffer<Wave> _WaveDataBuffer;
#else
half4 waveData[20]; // 0-9 amplitude, direction, wavelength, omni, 10-19 origin.xy
#endif

struct WaveStruct {

};

WaveStruct GerstnerWave(half2 pos, float waveCountMulti, half amplitude, half direction, half wavelength, half omni, half2 omniPos) {

}

inline void SampleWaves(float3 position, half opacity, out WaveStruct waveOut) {

}

#endif // GERSTNER_WAVES_INCLUDED