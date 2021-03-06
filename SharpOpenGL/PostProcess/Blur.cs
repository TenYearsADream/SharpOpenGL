﻿using Core;
using Core.Texture;
using OpenTK;
using System;
using System.Collections.Generic;
using CompiledMaterial.Blur;

namespace SharpOpenGL.PostProcess
{
    public class BlurPostProcess : SharpOpenGL.PostProcess.PostProcessBase
    {
        public BlurPostProcess()
            : base()
        {
            this.bCreateCustomRenderTarget = true;
        }

        protected override void CreateCustomRenderTarget()
        {
            Output = new RenderTarget(1024, 768, 1, false, 1.0f, false);
            Output.Initialize();
        }

        public override void OnGLContextCreated(object sender, EventArgs e)
        {
            base.OnGLContextCreated(sender, e);

            PostProcessMaterial = ShaderManager.Get().GetMaterial<Blur>();
        }

        public override void Render(TextureBase input)
        {
            TempOutput.BindAndExecute(PostProcessMaterial, () =>
            {
                var blurMaterial = (Blur) (PostProcessMaterial);
                blurMaterial.Horizontal = false;
                blurMaterial.ColorTex2D = input;
                BlitToScreenSpace();
            });

            Output.BindAndExecute(PostProcessMaterial, () =>
            {
                var blurMaterial = (Blur) (PostProcessMaterial);
                blurMaterial.Horizontal = true;
                blurMaterial.ColorTex2D = TempOutput.ColorAttachment0;
                BlitToScreenSpace();
            });
        }

        protected List<OpenTK.Vector2> offset = new List<Vector2>();
        protected List<OpenTK.Vector2> weight = new List<Vector2>();
        

        protected RenderTarget TempOutput = new RenderTarget(1024, 768, 1);

    }
}
