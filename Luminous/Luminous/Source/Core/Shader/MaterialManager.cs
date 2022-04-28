using Luminous.Asset;
using Luminous.Core.Graphics;
using Luminous.Core.IO.ContentProcessor;
using Luminous.Core.IO.ContentProcessor.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Luminous.Core.Shader
{
    public class MaterialManager
    {
        private static readonly Lazy<MaterialManager> shaderManger =
                new Lazy<MaterialManager>(() => new MaterialManager());

        private ShaderProcessor shaderProcessor = new ShaderProcessor();

        private string defaultFolder = $"{AppDomain.CurrentDomain.BaseDirectory}/Data/Shaders";

        private int shaderInstId = 0;
        private Dictionary<string, MaterialComponent> materials = new Dictionary<string, MaterialComponent>();

        public static MaterialManager Instance
        {
            get { return shaderManger.Value; }
        }

        public string ShaderDirectory { get; set; } = string.Empty;

        public void Initialize()
        {
            if (ShaderDirectory == string.Empty)
            {
                string[] shaderFilePaths = Directory.GetFiles(defaultFolder, "*.fx");

                for (int i = 0; i < shaderFilePaths.Length; i++)
                {
                    string shaderFile = Path.GetFileName(shaderFilePaths[i]);

                    AssetManager.Instance.LoadAsset<ShaderData>(shaderProcessor, $"Shaders/{shaderFile}");
                }
            }
        }

        public void CreateMaterial(string ShaderName, Texture2D Texture, Color Color, string Name = null)
        {
            ShaderData data = AssetManager.Instance.GetAsset<ShaderData>(ShaderName);
            string shaderBinary = data.Unpack();

            if (materials.ContainsKey(ShaderName))
            {
                string materialInst = $"{ShaderName}_{shaderInstId}";
                byte[] bin = File.ReadAllBytes(shaderBinary);

                MaterialComponent material;

                if (Name == null)
                    material = new MaterialComponent(bin, Texture, Color, ShaderName);
                else
                    material = new MaterialComponent(bin, Texture, Color, Name);

                materials.Add(materialInst, material);

                shaderInstId++;
            }
            else
            {
                byte[] bin = File.ReadAllBytes(shaderBinary);

                MaterialComponent material;

                if (Name == null)
                    material = new MaterialComponent(bin, Texture, Color, ShaderName);
                else
                    material = new MaterialComponent(bin, Texture, Color, Name);

                materials.Add(ShaderName, material);
            }
        }

        public MaterialComponent? GetMaterial(string MaterialName)
        {
            MaterialComponent? material = null;
            if (materials.ContainsKey(MaterialName))
            {
                material = materials[MaterialName].Instance();
            }

            return material;
        }
    }
}
