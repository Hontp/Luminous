using Luminous.Core.IO.ContentProcessor.Data;
using Luminous.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Luminous.Asset
{
    public class AssetManager
    {
        // map of assets to used in game
        private Dictionary<string, IAsset> assetCollection = new Dictionary<string, IAsset>();

        // the root Asset path
        private string applicationRootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        // the root content folder
        private string rootAssetFolder = "Data";

        // the valid path to the assets folder
        private string rootDirectory;

        // asset id, if there are more than one copy the asset tag it with a number
        private int assetId = 1;

        private AssetManager() 
        {
            if (applicationRootDirectory != string.Empty && rootAssetFolder != string.Empty)
            {
                string tmp = $"{applicationRootDirectory}{rootAssetFolder}";
                
               if (Directory.Exists(tmp))
                {
                    rootDirectory = tmp;
                }
                else
                {
                    Debug.WriteLine($"Root Asset Directory Does Not Exist");
                }
            }
        }

        // Asset Manager instance
        private static readonly Lazy<AssetManager> instance = new Lazy<AssetManager>(() => new AssetManager());

        public static AssetManager Instance
        {
            get { return instance.Value; }
        }

        /*
         * Cache Assets into the assets collection
         */
        public void LoadAsset<T>(IContentProcessor contentProcessor, string filepath)
        {
            IAsset asset = null;

            string filename = Path.GetFileNameWithoutExtension(filepath);

            string contenPath = $"{rootDirectory}/{filepath}";

            switch (typeof(T))
            {
                case Type textData when textData == typeof(TextureData):
                    asset = new TextureData(contentProcessor, DataType.TEXTURE2D, contenPath);
                    break;

                case Type audioData when audioData == typeof(AudioData):
                    asset = new AudioData(contentProcessor, DataType.AUDIO, contenPath);
                    break;

                case Type shaderData when shaderData == typeof(ShaderData):
                    asset = new ShaderData(contentProcessor, DataType.SHADER, contenPath);
                    break;

                case Type customData when customData == typeof(CustomData):
                default:
                      asset = new CustomData(contentProcessor, contenPath); 
                    break;
            }

            if (!assetCollection.ContainsKey(filename))
            {
                assetCollection.Add(filename, asset);
            }
            else
            {
                assetCollection.Add($"{filename}_{assetId}", asset);
            }

        }

        /*
         * Get the assets from the collection, by its type and name
         */
        public T GetAsset<T>(string assetName)
        {
            T asset = default(T);

            if (assetCollection.ContainsKey(assetName))
            {
                asset = (T)assetCollection[assetName];
            }

            return asset;
        }

        /*
         * Get/Set the root Asset path
         */
        public string RootAssetPath
        {
            set{ applicationRootDirectory = value;}
            get { return applicationRootDirectory; }
        }

        /*
         * Get/Set the root Asset folder
         */
        public string RootAssetFolder
        {
            set { rootAssetFolder = value; }
            get { return rootAssetFolder; }
        }

    }
}
