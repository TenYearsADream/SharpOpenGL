using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Core;
using Core.Buffer;
using Core.OpenGLShader;
using Core.Texture;
using Core.VertexCustomAttribute;
using Core.MaterialBase;
using ZeroFormatter;
using ZeroFormatter.Formatters;
namespace SharpOpenGL.LightMaterial
{


[ZeroFormattable]
[StructLayout(LayoutKind.Explicit,Size=20)]
public struct VertexAttribute
{
	
	[Index(0)]
	[FieldOffset(0), ComponentCount(3), ComponentType(VertexAttribPointerType.Float)]
	public OpenTK.Vector3 VertexPosition;
		
	[Index(1)]
	[FieldOffset(12), ComponentCount(2), ComponentType(VertexAttribPointerType.Float)]
	public OpenTK.Vector2 VertexTexCoord;
	
	public static void VertexAttributeBinding()
	{
		GL.EnableVertexAttribArray(0);
		GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 20, new IntPtr(0));
		GL.EnableVertexAttribArray(1);
		GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 20, new IntPtr(12));
	}
}

}