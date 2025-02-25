using System.Reflection;

namespace CtrlAltQuest.Common.UI
{
    public static class RoutingAssemblies
    {
        public static IList<Assembly> Assemblies = new List<Assembly>();

        public static void AddAssembly(Assembly assembly)
        {
            if (!Assemblies.Contains(assembly))
            {
                Assemblies.Add(assembly);
            }
        }
    }
}
