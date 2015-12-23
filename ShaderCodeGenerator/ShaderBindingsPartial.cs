﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpOpenGL;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ShaderCompiler   
{
    public partial class ShaderBindings
    {
        public ShaderBindings(ShaderProgram program, int nBlockIndex)
        {
            MetaDataList = program.GetUniformVariableMetaDataList(nBlockIndex).OrderBy(x=>x.VariableOffset).ToList();
            BlockName = program.GetUniformBlockName(nBlockIndex);
            StructName = program.GetUniformBlockName(nBlockIndex);
            BlockDataSize = program.GetUniformBlockDataSize(nBlockIndex);
        }

        public ShaderBindings(ShaderProgram program, int nBlockIndex, string StructNamePrefix)
        {
            MetaDataList = program.GetUniformVariableMetaDataList(nBlockIndex).OrderBy(x=>x.VariableOffset).ToList();
            BlockName = program.GetUniformBlockName(nBlockIndex);
            StructName = StructNamePrefix + "_" + BlockName;
            BlockDataSize = program.GetUniformBlockDataSize(nBlockIndex);
        }

        List<UniformVariableMetaData> MetaDataList;

        int BlockDataSize = 0;

        string BlockName = "";
        string StructName = "";
    }
}