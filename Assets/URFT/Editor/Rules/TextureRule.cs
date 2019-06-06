using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace URFT
{
    public enum MaxTextureSize
    {
        Max32 = 32,
        Max64 = 64,
        Max128 = 128,
        Max256 = 256,
        Max512 = 512,
        Max1024 = 1024,
        Max2048 = 2048,
        Max4096 = 4096,
        Max8192 = 8192,
    }

    //贴图规则
    public class TextureRule : BaseRule
    {
        [SerializeField]
        public TextureImporterType TextureType = TextureImporterType.Default;

        [SerializeField]
        public bool sRGB = true;

        [SerializeField]
        public TextureImporterAlphaSource AlphaSource = TextureImporterAlphaSource.FromInput;

        [SerializeField]
        public bool AlphaIsTransparency = false;

        [SerializeField]
        public TextureImporterNPOTScale NonPower = TextureImporterNPOTScale.None;

        [SerializeField]
        public bool ReadWrite = false;

        [SerializeField]
        public bool GenerateMipMaps = false;

        [SerializeField]
        public TextureWrapMode WM = TextureWrapMode.Repeat;

        [SerializeField]
        public FilterMode FM = FilterMode.Bilinear;

        [SerializeField]
        public MaxTextureSize MaxSize = MaxTextureSize.Max2048;
    }
}
