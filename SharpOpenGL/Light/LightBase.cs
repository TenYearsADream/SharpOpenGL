﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CustomAttribute;
using Core.Primitive;
using OpenTK;
using OpenTK.Graphics;

namespace SharpOpenGL.Light
{
    enum LightChannel
    {
        SkyBoxChannel = 0,
        StaticMeshChannel = 1,
    }
    public abstract class LightBase : SceneObject
    {
        protected LightBase(string name, int count)
        : base(name, count)
        {   
        }

        [ExposeUI]
        public Vector3 Color { get; set; }= new Vector3(1, 1, 1);
    }
}
