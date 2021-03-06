﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CustomAttribute;
using Core.MaterialBase;
using OpenTK;

namespace SharpOpenGL.Light
{
    public class PointLight : LightBase
    {
        private static int PointLightCount = 0;
        public PointLight()
        : base("PointLight", PointLightCount++)
        {
            wireframesphere = new WireFrameSphere(3, 5, 5);
        }

        public override void Draw()
        {
            if (wireframesphere != null)
            {
                wireframesphere.Translation = this.Translation;
                wireframesphere.Draw();
            }
        }

        private WireFrameSphere wireframesphere = null;


        public override bool IsEditable { get; set; } = false;

        [ExposeUI]
        public Vector2 MinMaxRadius { get; set; } = new Vector2(1, 500);
    }
}
