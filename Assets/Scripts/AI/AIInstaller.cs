using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace Alija.Big2.Client.AI
{
    public class AIInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<RandomComputeSubmittable>(Lifetime.Singleton)
                .As<IComputeSubmittable>();
        }
    }
}
