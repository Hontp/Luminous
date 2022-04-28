using Luminous.API.MonoGame;
using Luminous.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luminous.Core.IO.ContentProcessor
{
    public class ShaderProcessor : IContentProcessor
    {
        private List<string> compilerInfo;
        private ShaderCompiler compiler = new ShaderCompiler();

        public byte[] ProcessData(string filename)
        {
            compilerInfo = new List<string>();
            byte[] result = null;

            string outputPath = compiler.CompileShader(filename, AppDomain.CurrentDomain.BaseDirectory + "/Data/Shaders",  ref compilerInfo);

            result = Encoding.UTF8.GetBytes(outputPath);

            return result;
        }

        public List<string> CompilerInfo
        {
            get { return compilerInfo; }
        }
    }
}
