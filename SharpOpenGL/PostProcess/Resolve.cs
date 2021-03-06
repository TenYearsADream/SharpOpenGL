﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompiledMaterial.ResolveMaterial;
using Core;
using Core.CustomEvent;
using Core.Texture;


namespace SharpOpenGL.PostProcess
{
    public class ResolvePostProcess : PostProcessBase
    {

        public ResolvePostProcess()
            : base()
        {
        }
        
        public override void OnGLContextCreated(object sender, EventArgs e)
        {
            base.OnGLContextCreated(sender, e);

            PostProcessMaterial = ShaderManager.Get().GetMaterial<ResolveMaterial>();
        }

        public override void Render(TextureBase colorTex, TextureBase motionTex)
        {
            Output.BindAndExecute(PostProcessMaterial,
                () =>
                {
                    var resolveMaterial = (ResolveMaterial) PostProcessMaterial;
                    resolveMaterial.ColorTex2D = colorTex;
                    resolveMaterial.MotionTex2D = motionTex;

                    BlitToScreenSpace();
                }
            );
        }
    }
}
