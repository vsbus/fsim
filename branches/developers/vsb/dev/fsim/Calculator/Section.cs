using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Section
    {
        private List<Module> m_modules = new List<Module>();

        public void AddModule(Module module)
        {
            m_modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            m_modules.Remove(module);
        }
    }
}
