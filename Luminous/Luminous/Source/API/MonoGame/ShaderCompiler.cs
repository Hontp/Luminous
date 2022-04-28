using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Luminous.API.MonoGame
{
    public class ShaderCompiler
    {
        public string CompileShader(string source, string outputDir, ref List<string> compilerInfo)
        {
            string result;
            string filename = Path.GetFileNameWithoutExtension(source);
            string outdir = Path.GetDirectoryName($"{outputDir}/");

            ProcessStartInfo shaderCompiler = new ProcessStartInfo
            {
                FileName = AppDomain.CurrentDomain.BaseDirectory + "/Tools/mgfxc/mgfxc.exe",
                Arguments = $"{source} {outdir}/{filename}.lbin /Profile:OpenGL",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            Process process = new Process
            {
                StartInfo = shaderCompiler
            };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string errors = process.StandardError.ReadToEnd();

            if (output != string.Empty)
                compilerInfo.Add(output);

            if (errors != string.Empty)
                compilerInfo.Add(errors);

            result = $"{outdir}/{filename}.lbin";

            return result;
        }

    }
}
