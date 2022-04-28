using System;
using System.Collections.Generic;
using System.Text;

namespace Luminous.API
{
    public interface IMainLoop
    {
        void Start();
        void Load();
        void Update(double dt);
        void Draw(double dt);
    }
}
