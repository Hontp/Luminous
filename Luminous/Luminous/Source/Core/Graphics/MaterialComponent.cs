using Luminous.API.MonoGame;
using Luminous.Core.ECS.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Luminous.Core.Graphics
{
    public class MaterialComponent : IComponent
    {
        public string Name { get; private set; }
        public Effect Effect { get; private set; }     
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public ulong Id { get ; set; }

        public Type Type => throw new NotImplementedException();

        public MaterialComponent(byte[] shader, Texture2D texture, Color color, string name = "")
        {
            Name = name;
            Effect = new Effect(Graphics2D.Instance.GraphicsDevice, shader);
            Effect.Name = name;
            Texture = texture;
            Color = color;
        }

        
        public MaterialComponent Instance()
        {
            MaterialComponent other = (MaterialComponent)MemberwiseClone();
            other.Name = new string(Name);
            other.Effect = Effect.Clone();
            other.Texture = Texture;

            return other;
        }

        public void SetParameter<T>(string name, T value)
        {
            switch (typeof(T))
            {
                case Type vector2Data when vector2Data == typeof(Vector2):
                    Vector4 vec2 = (Vector4)Convert.ChangeType(value, typeof(Vector4));
                    Effect.Parameters[name].SetValue(vec2);
                    break;

                case Type vector3Data when vector3Data == typeof(Vector3):
                    Vector3 vec3 = (Vector3)Convert.ChangeType(value, typeof(Vector3));
                    Effect.Parameters[name].SetValue(vec3);
                    break;

                case Type vector4Data when vector4Data == typeof(Vector4):
                    Vector4 vec4 = (Vector4)Convert.ChangeType(value, typeof(Vector4));
                    Effect.Parameters[name].SetValue(vec4);
                    break;

                case Type floatData when floatData == typeof(float):
                    float single = (float)Convert.ChangeType(value, typeof(float));
                    Effect.Parameters[name].SetValue(single);
                    break;

                case Type intData when intData == typeof(int):
                    int integer = (int)Convert.ChangeType(value, typeof(int));
                    Effect.Parameters[name].SetValue(integer);
                    break;

                case Type boolData when boolData == typeof(bool):
                    bool boolean = (bool)Convert.ChangeType(value, typeof(bool));
                    Effect.Parameters[name].SetValue(boolean);
                    break;

                case Type texData when texData == typeof(Texture):
                    Texture tex = (Texture)Convert.ChangeType(value, typeof(Texture));
                    Effect.Parameters[name].SetValue(tex);
                    break;

                case Type matrix when matrix== typeof(Matrix):
                    Matrix mat = (Matrix)Convert.ChangeType(value, typeof(Matrix));
                    Effect.Parameters[name].SetValue(mat);
                    break;

                case Type quatern when quatern == typeof(Quaternion):
                    Quaternion quat = (Quaternion)Convert.ChangeType(value, typeof(Quaternion));
                    Effect.Parameters[name].SetValue(quat);
                    break;
            }

        }
    }
}
