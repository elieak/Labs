using System.Collections.Generic;

namespace BackgammonLogic.Components
{
    public class Scene
    {
        public Scene(List<Drawable> items, int[] _possibleSources, Dictionary<int, int[]> _possibleTargets)
        {
            Items = items;
            PossibleSources = _possibleSources;
            PossibleTargets = _possibleTargets;
        }

        public List<Drawable> Items { get; }

        public readonly int[] PossibleSources;
        public readonly Dictionary<int, int[]> PossibleTargets;
    }
}
