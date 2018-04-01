﻿#version 430 core

layout(location=0) in vec3 InPosition;
layout(location=1) in vec2 InTexCoord;
layout(location=2) in vec3 InNormal;
layout(location=3) in vec3 InTangent;
layout(location=4) in vec3 InBinormal;

layout (location = 0) out vec4 PositionColor;
layout (location = 1) out vec4 DiffuseColor;
layout (location = 2) out vec4 NormalColor;

uniform float time;

{uniformVariableDeclaration}

{sampler2DVariableDeclaration}

vec4 GetDiffuseColor()
{
    return {diffuseColorCode};
}

void main()
{   
    DiffuseColor = GetDiffuseColor();
    NormalColor.xyz = InNormal.xyz;
    PositionColor = vec4(InPosition, 0);
}