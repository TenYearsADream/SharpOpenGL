﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using Core.OpenGLShader;

using OpenTK;
using OpenTK.Platform;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using System.IO;

namespace ShaderCompiler
{
    public static class Program
    {        
        public static void Main(string[] args)
        {
            if(args.Count() == 2)
            {
                Control c = new Control();
                IntPtr hWnd = c.Handle;
                
                using (OpenTK.Platform.IWindowInfo windowInfo = OpenTK.Platform.Utilities.CreateWindowsWindowInfo(hWnd))
                using (OpenTK.Graphics.GraphicsContext context = new OpenTK.Graphics.GraphicsContext(GraphicsMode.Default, windowInfo))
                {
                    context.MakeCurrent(windowInfo);

                    context.LoadAll();
                    
                    if (Directory.Exists(args[0]))
                    {
                        foreach(var fsFile in Directory.EnumerateFiles(args[0], "*.fs"))
                        {
                            FragmentShader fs = new FragmentShader();
                            ShaderProgram program = new ShaderProgram();

                            fs.CompileShader(File.ReadAllText(fsFile));
                            program.AttachShader(fs);

                            String result;
                            if(program.LinkProgram(out result))
                            {
                                var filename = Path.GetFileNameWithoutExtension(fsFile);

                                var FragmentShaderCodeGen = new FragmentShaderCodeGenerator(program, filename + ".FragmentShader");

                                File.WriteAllText(Path.Combine(args[1], "CompiledFragmentShader.cs"), FragmentShaderCodeGen.GetCode());
                            }
                        }

                        // generate code for vertex shader files
                        foreach (var vsFile in Directory.EnumerateFiles(args[0], "*.vs"))
                        {
                            VertexShader vs = new VertexShader();
                            ShaderProgram program = new ShaderProgram();                            

                            vs.CompileShader(File.ReadAllText(vsFile));
                            program.AttachShader(vs);

                            String result;
                            if (program.LinkProgram(out result))
                            {
                                var filename = Path.GetFileNameWithoutExtension(vsFile);

                                var gen = new VertexAttributeCodeGenerator(program, filename + ".VertexShader");

                                var test = gen.GetCode();

                                File.WriteAllText(Path.Combine(args[1], "CompiledVertexAttributes.cs"), test);

                                Console.Write(test);

                                var UniformCodeGen = new ShaderUniformCodeGenerator(program, filename + ".VertexShader");

                                var test2 = UniformCodeGen.GetCode();

                                File.WriteAllText(Path.Combine(args[1], "CompiledShaderVariables.cs"), UniformCodeGen.GetCode());

                                Console.Write(test2);

                                var VertexShaderCodeGen = new VertexShaderCodeGenerator(program, filename + ".VertexShader");

                                File.WriteAllText(Path.Combine(args[1], "CompiledVertexShader.cs"), VertexShaderCodeGen.GetCode());
                            }
                        }
                        
                    }
                }
            }
        }
    }
}
