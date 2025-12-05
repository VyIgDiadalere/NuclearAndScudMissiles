using Reflex.Core;
using Source.Scripts.GENERAL.InputService;
using UnityEngine;

namespace Source.Scripts.GENERAL.Di_Installer
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton<IInputService>(_ =>
            {
                    return new MouseInputService();
            });
        }
    }
}